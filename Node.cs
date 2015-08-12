using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSBN_V._2._1
{
    /// <summary>
    /// resembles a single node in an agents network, handles the updating of itself according to its inputs
    /// </summary>
    
    class Node
    {
        public int InitialOutputValue;
        private List<int> IncommingNodeIDs = new List<int>(); // list of incomming connections
        public byte[] Table; // table to calculate its output accodring to its input signals
        public int CurrentOutput; // current output
        private int newOutput; // output after updating
        public int ID; // unique id of the node within an agent
        private int K = 0; // number of input signals
        Random random;
        int maxK; // maximal number of input signals

        public Node(int ID, byte[] TableValues, int InitialOutputValue, List<int> IncommingNodeIDs, Random random)
        {
            this.random = random;
            this.InitialOutputValue = InitialOutputValue;
            this.ID = ID;
            this.IncommingNodeIDs = IncommingNodeIDs;
            CurrentOutput = InitialOutputValue;
            Table = TableValues;
            K = IncommingNodeIDs.Count;
        }

        public int[][] CheckForNeutralConnection() // calculate the amount of table entrys where one or more incomming signals are neutral (which means that there value does not effect the output giving that the other signals remain the same)
        {
            // create array
            int[][] returnValue = new int[IncommingNodeIDs.Count][];
            for (int i = 0; i < returnValue.Length; i++)
            {
                returnValue[i] = new int[] { 0, 0 };
            }

            // for each input signal
            for (int inputSignalIndex = 0; inputSignalIndex < IncommingNodeIDs.Count; inputSignalIndex++) // check for each incomming node
            {
                for (int key = 0; key < Table.Length; key++) // for all of the other signal combinations (keys) wheter this node (i) matters
                {
                    int onlyIndexBit = (int)Math.Pow(2, inputSignalIndex);
                    if ((key & onlyIndexBit) > 0)
                    {
                        if (Table[key] != Table[key - onlyIndexBit]) // if inverting the input signal matters
                        {
                            returnValue[inputSignalIndex][1]++;
                        }
                        else
                        {
                            returnValue[inputSignalIndex][0]++;
                        }
                    }
                }
            }
            return returnValue; // [[neutral][does matter], ..... ]
        }

        public void ProcesInputs(int[] InputValues) // combine all of the input signals to get the key and use this key to get the new output
        {
            int[] inputValues = InputValues;
            long combinedInputs = 0;

            if (IncommingNodeIDs.Count == 0)
            {
                newOutput = CurrentOutput;
            }
            else
            {
                for (int i = 0; i < inputValues.Length; i++)
                {
                    combinedInputs += checked((long)inputValues[i] * (long)Math.Pow(2, i));
                }
                newOutput = Table[combinedInputs];
            }
        }

        public void SetNewOutput()
        {
            CurrentOutput = newOutput;
        }

        public Node copySelf() // create a deep copy of the node
        {
            List<int> IncommingNodeIDsCopy = new List<int>(IncommingNodeIDs);
            byte[] tableCopy = null;
            if (Table != null)
            {
                tableCopy = new byte[Table.Length];
                for (int i = 0; i < Table.Length; i++)
                {
                    tableCopy[i] = Table[i];
                }
            }
            return new Node(ID, tableCopy, InitialOutputValue, IncommingNodeIDsCopy, random);
        }

        private void ExtentTable() // extent the table to include a new connection
        {
            if (Table != null)
            {
                byte[] newTable = new byte[Table.Length * 2]; // create a new table double the size of the old one

                for (int i = 0; i < Table.Length; i++) // copy the original table to the first half of the new table
                {
                    newTable[i] = Table[i];
                }

                for (int i = Table.Length; i < Table.Length * 2; i++) // copy the orignal table again but now to the second half of the new table
                {
                    newTable[i] = Table[i - Table.Length];
                }

                Table = newTable;
            }

            else // if there was no table to begin with create a new one
            {
                byte[] newTable = new byte[2];
                newTable[0] = (byte)random.Next(0, 2);
                newTable[1] = (byte)random.Next(0, 2);
                Table = newTable;
            }
        }

        public void MutateTable(int MutationChance) // invert each output of the table with a certain chance
        {
            if (Table != null)
            {
                for (int i = 0; i < Table.Length; i++)
                {
                    if (random.Next(0, 10000) < MutationChance)
                    {
                        if (Table[i] == 0) Table[i] = 1;
                        else Table[i] = 0;
                    }
                }
            }
        }

        public bool AddIncommingNode(int ID) // add incomming node/connection
        {
            if (!IncommingNodeIDs.Exists(x => x == ID))
            {
                ExtentTable(); // extent table
                MutateTable(1000); // make the connection non neutral by mutation
                IncommingNodeIDs.Add(ID); // add the connection to the list of connection
                K++;
                return true;
            }
            return false;
        }

        public List<int> getIncommingNodeIDs()
        {
            return IncommingNodeIDs;
        }

        public int GetK()
        {
            return K;
        }

        public void RemoveIncommingNode(int indexOfID)
        {
            if (Table.Length > 2) // if the table holds entrys for more then one connection
            {
                int highBitsLeftOfIndex = 0; // holds only 1's left of the index
                for (int i = IncommingNodeIDs.Count - 1; i >= 0; i--)
                {
                    if (i > indexOfID)
                    {
                        highBitsLeftOfIndex = highBitsLeftOfIndex * 2 + 1;
                    }
                    else
                    {
                        highBitsLeftOfIndex = highBitsLeftOfIndex * 2;
                    }
                }

                int highBitsRightOfIndex = 0; // holds only ones right of index
                for (int i = 0; i < indexOfID; i++)
                {
                    highBitsRightOfIndex = highBitsRightOfIndex * 2 + 1;
                }

                int onlyIndexBitHigh = (int)Math.Pow(2, indexOfID); // an int with only the index bit high

                byte[] newTable = new byte[Table.Length / 2];
                for (int i = 0; i < Table.Length; i++)
                {
                    if ((onlyIndexBitHigh & i) > 0) // if the key has a 1 at the index place
                    {
                        int newKey = ((i & highBitsLeftOfIndex) >> 1) + (i & highBitsRightOfIndex); // remove the index bit
                        if (random.Next(0, 2) == 0) // 50% chance of taking the entry where the index was a 0
                        {
                            byte newValue = Table[(byte)(i - Math.Pow(2, indexOfID))]; // get the output for the entry where the index was a 0
                            newTable[newKey] = newValue;
                        }
                        else
                        {
                            newTable[newKey] = Table[i];
                        }
                    }
                }
                Table = newTable;
            }
            else // if the removed connection whas the only connection
            {
                Table = null;
            }
            IncommingNodeIDs.RemoveAt(indexOfID);
            K--;
        }

        public void SwitchIncommingNode(int nodeCount, int chance) // remove random connection and add a new random connection
        {
            if (random.Next(0, 10000) < chance & K > 0 & K < maxK)
            {
                RemoveRandomIncommingNode();
                AddRandomConnection(nodeCount);
            }
        }

        public void MutateRemoveIncommingNode(int chance) // remove connection(s) with a given chance
        {
            int passes = 10;
            for (int z = 0; z < passes; z++)
            {
                if (random.Next(0, 10000) < chance / passes & K > 0)
                {
                    RemoveRandomIncommingNode();
                }
            }
        }

        public void RemoveRandomIncommingNode()
        {
            if (K > 0)
            {
                RemoveIncommingNode(random.Next(0, IncommingNodeIDs.Count));
            }
        }

        public void MutateAddIncommingNode(int nodeCount, int chance) // add random connection with a given chance
        {
            // add a new connection
            if (random.Next(0, 10000) < chance)
            {
                AddRandomConnection(nodeCount);
            }
        }

        public bool AddRandomConnection(int nodeCount)
        {
            // make a randomly ordered list of all nodeIDs
            List<int> allNodes = new List<int>();
            for (int i = 0; i < nodeCount; i++)
            {
                allNodes.Add(i);
            }
            allNodes = allNodes.OrderBy(i => random.Next()).ToList();

            int index = 0;
            bool KeepLooking = true;
            bool connectionMade = false;
            // keep looking for a new not yet present connection until found or all possible connection are checked
            while (KeepLooking)
            {
                if (index < allNodes.Count)
                {
                    if (!AddIncommingNode(allNodes[index]))
                    {
                        index++;
                    }
                    else
                    {
                        connectionMade = true;
                        KeepLooking = false;
                    }
                }
                else
                {
                    KeepLooking = false;
                }
            }
            return connectionMade;
        }
    }
}
