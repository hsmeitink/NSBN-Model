using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSBN_V._2._1
{
    /// <summary>
    /// holds all of the individual agent functions and parameters
    /// </summary>
    
    class Agent
    {
        public int X; // x position in the world
        public int Y; // y position in the world
        public int Food;
        public int ID;
        public int Direction;
        public Node[] nodes; // the agents network

        // mutation chances
        public int MutateTableChance;
        public int MutateAddNodeConnectionChance;
        public int MutateRemoveNodeConnectionChance;
        public int MutateSwitchNodeChance;

        public int Age = 0;

        // currently not used for anything
        public double Red;
        public double Green;
        public double Blue;

        public bool Alive = true;
        Random random;
        public int CarnivorePercentage = 0;
        bool CarnivorPercentageEnabled;
        public bool StrictK;


        public Agent(Node[] Nodes, int X, int Y, int StartDirection, int food, int ID, int MutateTableChance, int MutateAddNodeConnectionChance, int MutateRemoveNodeConnectionChance, int MutateSwitchNodeChance, double Red, double Green, double Blue, Random random, int carnivorePercentage, bool strictK, bool carnivorPercentageEnabled)
        {
            this.MutateSwitchNodeChance = MutateSwitchNodeChance;
            this.StrictK = strictK;
            this.CarnivorePercentage = carnivorePercentage;
            this.random = random;
            this.ID = ID;
            this.Red = Red;
            this.Blue = Blue;
            this.Green = Green;
            Food = food;
            Direction = StartDirection;
            this.nodes = Nodes;
            this.X = X;
            this.Y = Y;
            this.MutateTableChance = MutateTableChance;
            this.MutateAddNodeConnectionChance = MutateAddNodeConnectionChance;
            this.MutateRemoveNodeConnectionChance = MutateRemoveNodeConnectionChance;
            this.CarnivorPercentageEnabled = carnivorPercentageEnabled;
        }

        /* this function does the actual updating / executing of the agent, which starts by setting the output values of its input nodes according to the surrounding.
         list of all nodes:
        - 0 = turn left
        - 1 = turn right
        - 2 = turn left
        - 3 = turn right 
        - 4 = move
        - 5 = reproduce
        - 6 = food left
        - 7 = food count left ahead
        - 8 = food count straight ahead
        - 9 = food count right ahead
        - 10 = food right
        - 11 = agent left
        - 12 = agent right ahead
        - 13 = agent right ahead
        - 14 = agent right ahead
        - 15 = agent right
        */
        public int[] Execute(int[] surrounding) // sourounding[foodleft, foodLeftAhead, foodStraightAhead, foodRightAhead, foodRight, agentLeft, AgentLeftAhead, AgentStraightAhead, AgentRightAhead, agentRight]
        {
            int[] output = new int[3];
            for (int i = 0; i < nodes.Length; i++)
            {
                int[] inputValues = new int[nodes[i].getIncommingNodeIDs().Count];
                for (int x = 0; x < inputValues.Length; x++) // for each inputcomming signal check wheter its from an input node, in which case its replaced by the appropriate value depending the current surrounding of the agent
                {
                    if (nodes[i].getIncommingNodeIDs()[x] == 6)
                    {
                        inputValues[x] = 0;
                        if (surrounding[0] > 0)
                        {
                            inputValues[x] = 1;
                        }
                    }
                    else if (nodes[i].getIncommingNodeIDs()[x] == 7)
                    {
                        inputValues[x] = 0;
                        if (surrounding[1] > 0)
                        {
                            inputValues[x] = 1;
                        }
                    }
                    else if (nodes[i].getIncommingNodeIDs()[x] == 8)
                    {
                        inputValues[x] = 0;
                        if (surrounding[2] > 0)
                        {
                            inputValues[x] = 1;
                        }
                    }
                    else if (nodes[i].getIncommingNodeIDs()[x] == 9)
                    {
                        inputValues[x] = 0;
                        if (surrounding[3] > 0)
                        {
                            inputValues[x] = 1;
                        }
                    }
                    else if (nodes[i].getIncommingNodeIDs()[x] == 10)
                    {
                        inputValues[x] = 0;
                        if (surrounding[4] > 0)
                        {
                            inputValues[x] = 1;
                        }
                    }
                    else if (nodes[i].getIncommingNodeIDs()[x] == 11)
                    {
                        inputValues[x] = 0;
                        if (surrounding[5] > 0)
                        {
                            inputValues[x] = 1;
                        }
                    }
                    else if (nodes[i].getIncommingNodeIDs()[x] == 12)
                    {
                        inputValues[x] = 0;
                        if (surrounding[6] > 0)
                        {
                            inputValues[x] = 1;
                        }
                    }
                    else if (nodes[i].getIncommingNodeIDs()[x] == 13)
                    {
                        inputValues[x] = 0;
                        if (surrounding[7] > 0)
                        {
                            inputValues[x] = 1;
                        }
                    }
                    else if (nodes[i].getIncommingNodeIDs()[x] == 14)
                    {
                        inputValues[x] = 0;
                        if (surrounding[8] > 0)
                        {
                            inputValues[x] = 1;
                        }
                    }
                    else if (nodes[i].getIncommingNodeIDs()[x] == 15)
                    {
                        inputValues[x] = 0;
                        if (surrounding[9] > 0)
                        {
                            inputValues[x] = 1;
                        }
                    }
                    else // signals from none input nodes are simply passed allong
                    {
                        inputValues[x] = nodes[nodes[i].getIncommingNodeIDs()[x]].CurrentOutput;
                    }
                }
                nodes[i].ProcesInputs(inputValues); // have the current node proces its inputs (set its output according to the incomming signals and its table)
            }

            // after all nodes have been updated set there output to the newly calculated output value
            foreach (Node node in nodes)
            {
                node.SetNewOutput();
            }

            // set the new direction
            Direction = ValidateDirection(Direction - nodes[0].CurrentOutput + nodes[1].CurrentOutput - nodes[2].CurrentOutput + nodes[3].CurrentOutput);

            output[1] = nodes[4].CurrentOutput; // move
            output[2] = nodes[5].CurrentOutput; // reproduce

            return output;
        }

        public int ValidateDirection(int direction) // convert values larger then 8 or smaller then 1 to values in the range of 1 til 8 to keep the orientation valid
        {
            int temp = direction;
            if (temp < 1)
            {
                if (temp <= -8)
                {
                    temp = temp % 8;
                }
                temp = 8 + temp;
            }
            else if (temp > 8)
            {
                temp = temp % 8;
            }
            return temp;
        }

        public Node[] CopyNodes() // deep copy of the nodes
        {
            Node[] copy = new Node[nodes.Length];
            for (int i = 0; i < nodes.Length; i++)
            {
                copy[i] = nodes[i].copySelf();
            }
            return copy;
        }

        public Agent CreateMutantCopy() // creates a mutated copy of itself
        {
            // mutate the carnivor percentage by adding or substracting with a certain chance
            int MutatedCarnivorePercentage = CarnivorePercentage;
            if (random.Next(0, 100) < 2 & CarnivorPercentageEnabled)
            {
                MutatedCarnivorePercentage += random.Next(0, 7) - 3;
                if (MutatedCarnivorePercentage > 100) MutatedCarnivorePercentage = 100;
                else if (MutatedCarnivorePercentage < 0) MutatedCarnivorePercentage = 0;
            }

            // create new agent (child)
            Agent newAgent = new Agent(CopyNodes(), X, Y, random.Next(1, 9), 5, ID, MutateTableChance, MutateAddNodeConnectionChance, MutateRemoveNodeConnectionChance, MutateSwitchNodeChance, Red, Green, Blue, random, MutatedCarnivorePercentage, StrictK, CarnivorPercentageEnabled);
            
            // mutate each node with a certain chance
            for (int i = 0; i < newAgent.nodes.Length; i++)
            {
                if (!StrictK)
                {
                    nodes[i].MutateRemoveIncommingNode(MutateRemoveNodeConnectionChance);
                    nodes[i].MutateAddIncommingNode(nodes.Length, MutateAddNodeConnectionChance);
                }
                else
                {
                    nodes[i].SwitchIncommingNode(nodes.Length, MutateSwitchNodeChance);
                }
                newAgent.nodes[i].MutateTable(newAgent.MutateTableChance);
            }
            //PercentageOfNonNeutralConnectoins();
            return newAgent;
        }

        // calculates the amount of connections that are neutral for each node given a specific combination of the other incomming connection values
        public int[][] PercentageOfNonNeutralConnectoins() // [node][incommingnote percentage neutral in table]
        {
            int[][] returnValue = new int[nodes.Length][];
            for (int i = 0; i < nodes.Length; i++)
            {
                int[][] neutrality = nodes[i].CheckForNeutralConnection();
                int[] percentages = new int[nodes[i].getIncommingNodeIDs().Count];
                for (int p = 0; p < nodes[i].getIncommingNodeIDs().Count; p++)
                {
                    percentages[p] = (int)(((float)neutrality[p][1] / (float)(neutrality[p][1] + (float)neutrality[p][0])) * 100);
                }
                returnValue[i] = percentages;
            }
            return returnValue;
        }

        public float averageK()
        {
            float average = 0;
            foreach(Node n in nodes)
            {
                average += n.GetK();
            }
             average = average / nodes.Length;
            if (average != 0)
            { }
            return average;
        }
    }

}
