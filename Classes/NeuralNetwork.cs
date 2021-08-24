using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using System.Diagnostics;

namespace VisualizedNeuralNetwork.Classes.NeuralNetworkAlgorithm
{
    class NeuralNetwork
    {
        private float[] inputLayer;
        private Neuron[][] neuralLayers;
        public NetworkStractureIndexer NetworkStracture { get { return networkStracture; } }

        private string networkFilePath;
        private string trainingDataSetFilePath;
        private string testingDataSetFilePath;

        public struct Neuron
        {
            public Neuron(float value)
            {
                this.value = value;
                bias = 0f;
                error = 0f;
                weights = new float[0];
            }

            public float value;
            public float bias;
            public float error;
            public float[] weights;
        };

        public NeuralNetwork(string fileName, string delimChar = ",")
        {
            networkStracture = new NetworkStractureIndexer(this);

            networkFilePath =
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                VisualizedNeuralNetwork.Properties.Settings.Default.NetworksPath +
                fileName;

            using (var parser = new TextFieldParser(networkFilePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(delimChar);

                string[] networkStracture = parser.ReadFields();
                int numNeuralLayers = int.Parse(networkStracture[1]) + 1; // Hidden layers + Output
                neuralLayers = new Neuron[numNeuralLayers][];
                for (int layerIndex = 0; layerIndex < numNeuralLayers; layerIndex++)
                {
                    int layerSize = int.Parse(networkStracture[layerIndex + 2]);
                    neuralLayers[layerIndex] = new Neuron[layerSize];

                    int numConnections;
                    if (layerIndex == 0) numConnections = int.Parse(networkStracture[0]);
                    else numConnections = int.Parse(networkStracture[layerIndex + 1]);

                    for (int neuronIndex = 0; neuronIndex < layerSize; neuronIndex++)
                    {
                        neuralLayers[layerIndex][neuronIndex].weights = new float[numConnections];
                    }
                }

                int numInputs = int.Parse(networkStracture[0]);
                inputLayer = new float[numInputs];

                for (int layerIndex = 0; layerIndex < neuralLayers.Length; layerIndex++)
                {
                    for (int neuronIndex = 0; neuronIndex < neuralLayers[layerIndex].Length; neuronIndex++)
                    {
                        if (parser.EndOfData)
                        {
                            throw new Exception("Incorrect network file format"); // TODO: show error message and go back to file selection
                        }
                        string[] fields = parser.ReadFields();

                        int numConnections;
                        if (layerIndex == 0) numConnections = inputLayer.Length;
                        else numConnections = neuralLayers[layerIndex - 1].Length;

                        for (int connectionIndex = 0; connectionIndex < numConnections; connectionIndex++)
                        {
                            neuralLayers[layerIndex][neuronIndex].weights[connectionIndex] = float.Parse(fields[connectionIndex]);
                        }
                        neuralLayers[layerIndex][neuronIndex].bias = float.Parse(fields[numConnections]);

                    }
                }
            }
            Debug.WriteLine("Info: Network \"" + fileName + "\" has been successfully opened");
        }

        public static void InitializeAndSaveNetwork(
            string fileName,
            int numInputNeurons,
            int numOutputNeurons,
            List<int> hiddenLayerSizes)
        {
            // TODO: alert if file exists and will be erased

            string filePath = 
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                VisualizedNeuralNetwork.Properties.Settings.Default.NetworksPath +
                fileName;

            var networkStracture = new List<int>();
            networkStracture.AddRange(hiddenLayerSizes);
            networkStracture.Add(numOutputNeurons);

            const char delimChar = ',';
            using (StreamWriter sw = new StreamWriter(new FileStream(filePath, FileMode.Create, FileAccess.Write)))
            {
                // Input layer
                sw.Write(numInputNeurons.ToString() + delimChar);
                // Hidden layer count
                sw.Write(hiddenLayerSizes.Count.ToString() + delimChar);
                // Hidden layer sizes
                foreach (int layerSize in hiddenLayerSizes)
                    sw.Write(layerSize.ToString() + delimChar);
                // Output layer
                sw.Write(numOutputNeurons.ToString());

                var rand = new Random();
                for (int layerIndex = 0; layerIndex < networkStracture.Count; layerIndex++)
                {
                    for (int neuronIndex = 0; neuronIndex < networkStracture[layerIndex]; neuronIndex++)
                    {
                        int numConnections;
                        if (layerIndex == 0) numConnections = numInputNeurons;

                        else numConnections = networkStracture[layerIndex - 1];

                        sw.WriteLine();
                        for (int connectionIndex = 0; connectionIndex < numConnections; connectionIndex++)
                        {
                            // Rand weights
                            float randWeight = (float)rand.NextDouble() * 2 - 1;
                            sw.Write(randWeight.ToString() + delimChar);
                        }
                        // Bias
                        sw.Write("0");
                    }
                }
            }

            Debug.WriteLine("Info: New network \"" + fileName + "\" has been created");
        }
        public void TrainNetwork(
            string trainingDataSetFileName,
            string testingDataSetFileName,
            int epochNum,
            float learningRate = 0.2f,
            string delimChar = ",")
        {
            trainingDataSetFilePath = 
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                VisualizedNeuralNetwork.Properties.Settings.Default.DataSetsPath +
                trainingDataSetFileName;

            testingDataSetFilePath = 
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                VisualizedNeuralNetwork.Properties.Settings.Default.DataSetsPath +
                trainingDataSetFileName;

            int lastLayerIndex = neuralLayers.Length - 1;
            float[] expected = new float[neuralLayers[lastLayerIndex].Length];


            int dataExampleCount = 0;

            for (int epoch = 1; epoch <= epochNum; epoch++)
            {

                float sumError = 0;
                dataExampleCount = 0;
                using (var parser = new TextFieldParser(trainingDataSetFilePath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(delimChar);


                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();

                        int expectedOutputIndex = AssignInputsReturnExpectedIndex(fields);
                        if (expectedOutputIndex != -1 && expected.Length >= expectedOutputIndex)
                        {
                            expected[expectedOutputIndex] = 1;
                        }
                        else throw fileFormatEx;

                        ForwardPropagate();
                        sumError += CalculateErrorSum(expected);
                        BackwardPropagateErrors(expected);
                        UpdateWeights(learningRate);

                        dataExampleCount++;
                    }
                    float averageError = 0;
                    if (dataExampleCount != 0) averageError = sumError / dataExampleCount;  // TODO: display averageError
                    float testRunSuccessRate = RunTestingDataSet() * 100;

                    Debug.WriteLine("Error: {0}\tTest success rate: {1}%", averageError, testRunSuccessRate);
                    
                }
            }
            OnNetworkNeedsRedrawing();
        }

        //void saveCurrentNetwork(string saveFileName, char delimChar = ',')
        //  {

        //  }

        private float RunTestingDataSet(string delimChar = ",")
        {
            int correctResultCount = 0;
            int dataExampleCount = 0;

            int lastLayerIndex = neuralLayers.Length - 1;
            float[] expected = new float[neuralLayers[lastLayerIndex].Length];

            using (var parser = new TextFieldParser(testingDataSetFilePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(delimChar);

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    int expectedOutputIndex = AssignInputsReturnExpectedIndex(fields);
                    ForwardPropagate();

                    if (GetResultIndex() == expectedOutputIndex)
                    {
                        correctResultCount++;
                    }
                    dataExampleCount++;
                }
            }
            if (dataExampleCount != 0) return (float)correctResultCount / dataExampleCount;
            else return 0;
        }

        private int AssignInputsReturnExpectedIndex(string[] fields)
        {
            int expectedIndex = -1;
            if (fields.Length == inputLayer.Length + 1)
            {
                for (int inputIndex = 0; inputIndex < inputLayer.Length; inputIndex++)
                {
                    if (!float.TryParse(fields[inputIndex], out inputLayer[inputIndex]))
                        throw fileFormatEx;
                }

                if (!int.TryParse(fields[inputLayer.Length], out expectedIndex))
                    throw fileFormatEx;
            }
            else throw fileFormatEx;

            return expectedIndex;
        }

        private int GetResultIndex()
        {
            int maxElIndex = -1;
            float maxEl = -1;
            int lastLayerIndex = neuralLayers.Length - 1;
            for (int i = 0; i < neuralLayers[lastLayerIndex].Length; i++)
            {
                if (neuralLayers[lastLayerIndex][i].value > maxEl)
                {
                    maxEl = neuralLayers[lastLayerIndex][i].value;
                    maxElIndex = i;
                }
            }
            return maxElIndex;
        }

        private void ForwardPropagate()
        {
            for (int layerIndex = 0; layerIndex < neuralLayers.Length; layerIndex++)
            {
                for (int neuronIndex = 0; neuronIndex < neuralLayers[layerIndex].Length; neuronIndex++)
                {
                    float calculatedValue = 0;
                    for (int connectionIndex = 0; connectionIndex < neuralLayers[layerIndex][neuronIndex].weights.Length; connectionIndex++)
                    {
                        float weight = neuralLayers[layerIndex][neuronIndex].weights[connectionIndex];
                        float value = 0;

                        if (layerIndex == 0) value = inputLayer[connectionIndex];
                        else value = neuralLayers[layerIndex - 1][connectionIndex].value;

                        calculatedValue += weight * value;
                    }
                    calculatedValue += neuralLayers[layerIndex][neuronIndex].bias;

                    neuralLayers[layerIndex][neuronIndex].value = (float)(1 / (1 + Math.Exp(-calculatedValue)));
                }
            }

        }
        private float CalculateErrorSum(float[] expected)
        {
            float errorSum = 0;
            int lastLayerIndex = neuralLayers.Length - 1;
            for (int neuronIndex = 0; neuronIndex < neuralLayers[lastLayerIndex].Length; neuronIndex++)
            {
                float valueDifference = neuralLayers[lastLayerIndex][neuronIndex].value - expected[neuronIndex];
                errorSum += valueDifference * valueDifference;
            }
            return errorSum;
        }
        private void BackwardPropagateErrors(float[] expected)
        {
            int lastLayerIndex = neuralLayers.Length - 1;
            if (expected.Length == neuralLayers[lastLayerIndex].Length)
            {
                for (int layerIndex = lastLayerIndex; layerIndex >= 0; layerIndex--)
                {
                    if (layerIndex == lastLayerIndex)
                    {
                        for (int neuronIndex = 0; neuronIndex < neuralLayers[layerIndex].Length; neuronIndex++)
                        {
                            float curValue = neuralLayers[layerIndex][neuronIndex].value;
                            neuralLayers[layerIndex][neuronIndex].error = (curValue - expected[neuronIndex]);
                        }
                    }
                    else
                    {
                        for (int neuronIndex = 0; neuronIndex < neuralLayers[layerIndex].Length; neuronIndex++)
                        {
                            float errorSum = 0;

                            for (int nextLayerNeuronIndex = 0; nextLayerNeuronIndex < neuralLayers[layerIndex + 1].Length; nextLayerNeuronIndex++)
                            {
                                float error = neuralLayers[layerIndex + 1][nextLayerNeuronIndex].error;
                                float weight = neuralLayers[layerIndex + 1][nextLayerNeuronIndex].weights[neuronIndex];

                                errorSum += error * weight;
                            }
                            neuralLayers[layerIndex][neuronIndex].error = errorSum;
                        }
                    }
                    for (int neuronIndex = 0; neuronIndex < neuralLayers[layerIndex].Length; neuronIndex++)
                    {
                        float curValue = neuralLayers[layerIndex][neuronIndex].value;
                        neuralLayers[layerIndex][neuronIndex].error *= curValue * (1 - curValue);
                    }
                }
            }
            else
            {
                throw new Exception("Incorrect expected output format");
            }

        }
        private void UpdateWeights(float learningRate)
        {
            for (int layerIndex = 0; layerIndex < neuralLayers.Length; layerIndex++)
            {
                for (int neuronIndex = 0; neuronIndex < neuralLayers[layerIndex].Length; neuronIndex++)
                {
                    float error = neuralLayers[layerIndex][neuronIndex].error;

                    for (int connectionIndex = 0; connectionIndex < neuralLayers[layerIndex][neuronIndex].weights.Length; connectionIndex++)
                    {
                        float connectedNeuronValue = 0;

                        if (layerIndex == 0) connectedNeuronValue = inputLayer[connectionIndex];
                        else connectedNeuronValue = neuralLayers[layerIndex - 1][connectionIndex].value;

                        neuralLayers[layerIndex][neuronIndex].weights[connectionIndex] -= learningRate * error * connectedNeuronValue;

                    }
                    neuralLayers[layerIndex][neuronIndex].bias -= learningRate * error;
                }
            }
        }

        private Exception fileFormatEx = new Exception("Incorrect data set file format or network structure");

        public delegate void NetworkNeedsRedrawingEventHandler(object sender, EventArgs e);
        public event NetworkNeedsRedrawingEventHandler NetworkNeedsRedrawing;
        protected virtual void OnNetworkNeedsRedrawing()
        {
            if (NetworkNeedsRedrawing != null)
            {
                NetworkNeedsRedrawing(this, EventArgs.Empty);
            }
        }

        private NetworkStractureIndexer networkStracture;
        public class NetworkStractureIndexer
        {
            private NeuralNetwork arrayOwner;

            public NetworkStractureIndexer(NeuralNetwork arrayOwner)
            {
                this.arrayOwner = arrayOwner;
            }

            public Neuron this[int layerIndex, int neuronIndex]
            { 
                get
                {
                    if (layerIndex == 0)
                    {
                        return new Neuron(arrayOwner.inputLayer[neuronIndex]);
                    }
                    return arrayOwner.neuralLayers[layerIndex - 1][neuronIndex];
                }
            }

            public int Length
            {
                get { return arrayOwner.neuralLayers.Length + 1; }
            }

            public int LayerLength(int layerIndex)
            {
                if (layerIndex == 0)
                {
                    return arrayOwner.inputLayer.Length;
                }
                return arrayOwner.neuralLayers[layerIndex - 1].Length;
            }

        }

    }
}
