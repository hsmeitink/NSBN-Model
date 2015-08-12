using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NSBN_V._2._1
{
    class AgentHandler
    {
        /// <summary>
        /// handles all of the agents: does all of the updating of the agents and handles all changes to agents
        /// </summary>

        World world;
        List<Agent> agents = new List<Agent>(); // list of all agents
        Random random;
        int IDCounter = 0;
        long stepCounter = 0;
        int MaxAge = 300; // maximal age of an agent
        int resetCounter;
        int ReproductionCost = 300; // the ammount of food an agent needs to reproduce
        List<int[]> branchingList = new List<int[]>(); // ([ownID, parrentID, ageOfParrentAtBirth],...)
        List<int> KValues = new List<int>(); // list of inital K values
        int AgentsPerKValue; // amount of agents to be added per K value at startup
        int N; // the N value of each agent
        bool CarnivorPercentageEnabled;
        bool KeepTrackOfTree;
        bool StrictK;
        int RestartAtTurn;
        List<heratigeNode> heratigeTree = new List<heratigeNode>(); // still being implemented, keeps a complete heritage tree of all agents

        public AgentHandler(World world, bool carnivorPercentageEnabled, bool keepTrackOfTree, int restartAtTurn, bool strictK)
        {
            this.StrictK = strictK;
            RestartAtTurn = restartAtTurn;
            random = new Random();
            this.world = world;
            this.CarnivorPercentageEnabled = carnivorPercentageEnabled;
            this.KeepTrackOfTree = keepTrackOfTree;
        }

        public void SetKValues(List<int> ListOfKValues)
        {
            KValues = ListOfKValues;
        }

        public void SetAgentsPerKValue(int amount)
        {
            AgentsPerKValue = amount;
        }

        public void setNValue(int N_value)
        {
            this.N = N_value;
        }

        public bool AddAgent(Agent newAgent, int parrentID, int ageParrent)
        {
            if (world.addAgent(newAgent)) // if the agent is succesfully added to the world then also add it to a list for easy referencing
            {
                if(KeepTrackOfTree) branchingList.Add(new int[] { newAgent.ID, parrentID, ageParrent }); // the heratige tree is still being implemented
                agents.Add(newAgent);
                return true;
            }
            return false;
        }

        public int[] directionToAbsolute(Agent agent, int direction) // convert the orientation of the agent to the location of the cell it is facing
        {
            int[] output = new int[2];
            int x = agent.X;
            int y = agent.Y;

            if (direction == 1)
            {
                output[0] = x; output[1] = y - 1;
            }
            else if (direction == 2)
            {
                output[0] = x + 1; output[1] = y - 1;
            }
            else if (direction == 3)
            {
                output[0] = x + 1; output[1] = y;
            }
            else if (direction == 4)
            {
                output[0] = x + 1; output[1] = y + 1;
            }
            else if (direction == 5)
            {
                output[0] = x; output[1] = y + 1;
            }
            else if (direction == 6)
            {
                output[0] = x - 1; output[1] = y + 1;
            }
            else if (direction == 7)
            {
                output[0] = x - 1; output[1] = y;
            }
            else if (direction == 8)
            {
                output[0] = x - 1; output[1] = y - 1;
            }
            else
            {
                throw new System.ArgumentException("Invalid movement direction");
            }

            if (output[0] >= world.worldWidth)
            {
                output[0] = 0;
            }
            else if (output[0] < 0)
            {
                output[0] = world.worldWidth - 1;
            }

            if (output[1] >= world.worldHeight)
            {
                output[1] = 0;
            }
            else if (output[1] < 0)
            {
                output[1] = world.worldHeight - 1;
            }

            return output;
        }


        public void ExecuteAgents() // the actual execution / updating of the agents
        {
            List<Agent> toBeRemoved = new List<Agent>(); // agents that need to be removed after all agents are updated at the end of the run

            if (RestartAtTurn == stepCounter) // if the simulation has reach the turn where it is to be restarted then remove all current agents
            {
                foreach(Agent agent in agents)
                {
                    world.removeAgent(agent);
                }
                agents.Clear();
            }
            if (agents.Count == 0) // if there are no agents alive then fill the world with agents according to the parameters specified by the user
            {
                if(KValues.Count == 0)
                {
                    return;
                }

                stepCounter = 0;

                foreach(int k in KValues) // for each of the selected K values
                {
                    for (int a = 0; a < AgentsPerKValue; a++) // add the specified ammount of agents
                    {
                        Node[] nodes = new Node[N];
                        for (int i = 0; i < N; i++)
                        {
                            // fill the new agents network with K random connections
                            nodes[i] = new Node(i, null, random.Next(0, 2), new List<int>(), random);
                            for (int j = 0; j < k; j++)
                            {
                                nodes[i].AddRandomConnection(N);
                            }
                        }
                        if(
                            AddAgent(new Agent(nodes, random.Next(0, world.worldWidth), random.Next(0, world.worldHeight), random.Next(1, 9), ReproductionCost / 2, IDCounter, 50, 50, 50, 50, (double)random.Next(1, 11) / 10, (double)random.Next(1, 11) / 10, (double)random.Next(1, 11) / 10, random, 0, StrictK, CarnivorPercentageEnabled), -1, -1)
                          )
                        {
                            IDCounter++;
                        }
                    }

                }

                resetCounter++;
            }

            agents = agents.OrderBy(i => random.Next()).ToList(); // create a randomly ordered list of agents to ensure a random order of execution
            int avarageFood = 0;

            for (int i = agents.Count - 1; i >= 0; i--) // execute / update each agent
            {
                if (agents[i].Alive) // if the agent is still alive
                {
                    avarageFood += agents[i].Food;
                    int[] surrounding = CalculateSurrounding(agents[i]); // the values for the agents input nodes
                    int[] location;
                    int[] output = agents[i].Execute(surrounding); // the values of the agents output nodes


                    if (output[2] == 1 && agents[i].Food >= ReproductionCost + 50) // if the agents wants to reproduce and has enough food
                    {
                        location = directionToAbsolute(agents[i], agents[i].ValidateDirection(agents[i].Direction - 4));
                        if (!world.occupied(location[0], location[1]))
                        {
                            // create new agent (child)
                            Agent newAgent = agents[i].CreateMutantCopy();
                            newAgent.ID = IDCounter;
                            newAgent.X = location[0];
                            newAgent.Y = location[1];
                        
                            // give the new agent a random color (currently not used)
                            newAgent.Red = (double)random.Next(1, 11) / 10;
                            newAgent.Blue = (double)random.Next(1, 11) / 10;
                            newAgent.Green = (double)random.Next(1, 11) / 10;

                            newAgent.Food = ReproductionCost / 6;// initial food for the child

                            if (AddAgent(newAgent, agents[i].ID, agents[i].Age)) // try to add the new agent to the world
                            {
                                agents[i].Food -= ReproductionCost;
                                IDCounter++;
                            }
                        }
                    }
                    if (output[1] == 1) // if the agents output signals that it wants to move
                    {
                        location = directionToAbsolute(agents[i], agents[i].Direction);

                        if (world.occupied(location[0], location[1])) // if the new location is occupied then an attack will happen
                        {
                            Agent DefendingAgent = world.getAgent(location[0], location[1]); // get the defending agent

                            // if the defending agent has a larger carnivor percentage or wins by chance
                            if (DefendingAgent.CarnivorePercentage > agents[i].CarnivorePercentage | (DefendingAgent.CarnivorePercentage == agents[i].CarnivorePercentage & random.Next(0, 2) == 1))
                            {
                                int FoodOfAge = agents[i].Age;
                                if (FoodOfAge > 100) FoodOfAge = 100;
                                DefendingAgent.Food += (int)(agents[i].Food * ((float)DefendingAgent.CarnivorePercentage) / 100);// +FoodOfAge;
                                toBeRemoved.Add(agents[i]);
                                world.removeAgent(agents[i]);
                                agents[i].Alive = false;
                            }

                            else
                            {
                                int FoodOfAge = DefendingAgent.Age;
                                if (FoodOfAge > 100) FoodOfAge = 100;
                                agents[i].Food += (int)(DefendingAgent.Food * ((float)agents[i].CarnivorePercentage) / 100);// +agents[i].Age;
                                world.removeAgent(DefendingAgent);
                                toBeRemoved.Add(DefendingAgent);
                                DefendingAgent.Alive = false;
                                world.moveAgent(agents[i], location[0], location[1]);
                            }

                        }
                        else if (world.moveAgent(agents[i].X, agents[i].Y, location[0], location[1])) // if the new location is free
                        {
                            agents[i].X = location[0];
                            agents[i].Y = location[1];
                        }
                    }

                    agents[i].Food -= 10; // remove the food that each turn costs
                    agents[i].Age++;

                    // if an agents reaches its maximum age or has no more food then remove the agent
                    if (agents[i].Food <= 0 | agents[i].Age > MaxAge)
                    {
                        world.removeAgent(agents[i].X, agents[i].Y);
                        toBeRemoved.Add(agents[i]);
                        agents[i].Alive = false;
                    }
                }
            }

            avarageFood = avarageFood / agents.Count;

            // remove all of the agents that have died in this run
            foreach (Agent agent in toBeRemoved)
            {
                agents.Remove(agent);
            }
            toBeRemoved.Clear();  

            // write test date to .csv file every 20 turns
            if (stepCounter % 20 == 0)
            {
                addToCSV();
            }

            stepCounter++;
        }

        public int GetAgentCount()
        {
            return agents.Count;
        }

        public long GetStepCounter()
        {
            return stepCounter;
        }

        public int[] CalculateSurrounding(Agent agent) // get the values for the input nodes of an agent
        {
            int[] surrounding = new int[10];
            int[] location = directionToAbsolute(agent, agent.ValidateDirection(agent.Direction - 2));
            surrounding[0] = world.GetFood(location[0], location[1]);
            surrounding[5] = 0;
            if (world.occupied(location[0], location[1]))
            {
                surrounding[5] = 1;
            }
            location = directionToAbsolute(agent, agent.ValidateDirection(agent.Direction - 1));
            surrounding[1] = world.GetFood(location[0], location[1]);
            surrounding[6] = 0;
            if (world.occupied(location[0], location[1]))
            {
                surrounding[6] = 1;
            }
            location = directionToAbsolute(agent, agent.ValidateDirection(agent.Direction));
            surrounding[2] = world.GetFood(location[0], location[1]);
            surrounding[7] = 0;
            if (world.occupied(location[0], location[1]))
            {
                surrounding[7] = 1;
            }
            location = directionToAbsolute(agent, agent.ValidateDirection(agent.Direction + 1));
            surrounding[3] = world.GetFood(location[0], location[1]);
            surrounding[8] = 0;
            if (world.occupied(location[0], location[1]))
            {
                surrounding[8] = 1;
            }
            location = directionToAbsolute(agent, agent.ValidateDirection(agent.Direction + 2));
            surrounding[4] = world.GetFood(location[0], location[1]);
            surrounding[9] = 0;
            if (world.occupied(location[0], location[1]))
            {
                surrounding[9] = 1;
            }
            return surrounding; // [foodleft, foodleftahead, foodahead, foodrightahead, foodright, agentleft, agentleftahead, agenthead, agentrightahead, agentright]
        }

        public void addToCSV() // write test data to the "graphdate.csv" file
        {
            int[] KAgentCount = new int[101]; // the amount of agents of each K value
            int[] percentages = new int[101]; // the amount of agents of each carnivor percentage
            float totalAverage = 0;
            for (int i = 0; i < KAgentCount.Length; i++)
            {
                KAgentCount[i] = 0;
            }
            foreach (Agent agent in agents)
            {
                KAgentCount[agent.nodes[0].GetK()]++;
                percentages[agent.CarnivorePercentage]++;
                totalAverage += agent.averageK();
            }
            totalAverage = totalAverage / agents.Count;
            string text = "";

            for (int i = 0; i < 20; i++)
            {
                text += ", " + KAgentCount[i];
            }
            int maxpercentage = 0;
            text += ", percentages";
            for (int i = 0; i < percentages.Length; i++)
            {
                text += ", " + percentages[i];
                if (percentages[i] != 0)
                {
                    maxpercentage = i;
                }
            }

            File.AppendAllText(@"graphdata.csv", stepCounter.ToString() + "," + agents.Count.ToString() + "," + world.GetFoodCountInWorld().ToString() + text + "," + "totalAverage" + "," + totalAverage.ToString() + Environment.NewLine);
        }

        public void CreateTree() // still being implemented
        {
            string output = "(";
            for (int i = 0; i < branchingList.Count; i++)
            {
                if (branchingList[i][1] == -1)
                {
                    if (output[output.Length - 1] != '(')
                    {
                        output += ",";
                    }
                    output += "#" + branchingList[i][0].ToString() + "#:0.1";
                }
                else
                {
                    int index = output.IndexOf("#" + branchingList[i][1].ToString() + "#");
                    if (output[index - 1] == ')')
                    {
                        output = output.Insert(index - 1, ",#" + branchingList[i][0].ToString() + "#:" + branchingList[i][2].ToString());
                    }
                    else
                    {
                        output = output.Insert(index, "(#" + branchingList[i][0].ToString() + "#:" + branchingList[i][2].ToString() + ")");
                    }
                }
            }
            output += ")StartOfSimulation:0;";
            output = output.Replace("#", "");
        }

        public int calculateBranchExtinctionSize(int ID) // still being implemented
        {
            int extenctionSize = addUpDeadNodes(ID);
            if (extenctionSize != -1 && heratigeTree[ID].ParentID != -1)
            {
                int temp = calculateBranchExtinctionSize(heratigeTree[ID].ParentID);
                if(temp != -1)
                {
                    extenctionSize = temp;
                }
            }
            return extenctionSize;
        }

        public int addUpDeadNodes(int parent) // still being implemented
        {
            int returnValue = 0;
            for(int i = 0; i < heratigeTree[parent].childrenIDs.Count; i++)
            {
                returnValue++;
                int temp = addUpDeadNodes(heratigeTree[parent].childrenIDs[i]);
                returnValue += temp;
                if(temp == -1)
                {
                    returnValue = -1;
                    i = heratigeTree[parent].childrenIDs.Count;
                }
            }
            return returnValue;
        }

    }
}
