using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSBN_V._2._1
{
    /// <summary>
    /// Keeps track of the world and handles all changes to the world
    /// </summary>
    
    class World
    {
        Cell[,] world; // the two dimensional world array
        public int worldWidth = 0;
        public int worldHeight = 0;
        int MinAddedFood = 10; // minimal amount of food added when food is added to a cell
        int MaxAddedFood = 80; // maximal amoutn of food added to a cell
        Random random;

        public World(int width, int height)
        {
            random = new Random();
            worldWidth = width;
            worldHeight = height;
            world = new Cell[worldWidth, worldHeight];

            // fill the world array with new cell instances
            for (int x = 0; x < worldWidth; x++)
            {
                for (int y = 0; y < worldHeight; y++)
                {
                    world[x, y] = new Cell();
                }
            }
        }

        public int getFood(int X, int Y)
        {
            return world[X, Y].food;
        }

        public bool occupied(int X, int Y)
        {
            return world[X, Y].occupied;
        }

        public bool addAgent(Agent agent)
        {
            if (world[agent.X, agent.Y].setAgent(agent)) // if the agent is succesfully added to the cell
            {
                // add food that was in the cell to the new agent according to its carnivor percentage
                float food = world[agent.X, agent.Y].food * ((100 - (float)world[agent.X, agent.Y].getAgent().CarnivorePercentage) / 100);
                world[agent.X, agent.Y].getAgent().Food += (int)food;
                world[agent.X, agent.Y].food = 0;
                return true;
            }
            return false;
        }

        public Agent getAgent(int X, int Y)
        {
            return world[X, Y].getAgent();
        }

        public void removeAgent(int X, int Y)
        {
            world[X, Y].removeAgent();
        }

        public void removeAgent(Agent agent)
        {
            removeAgent(agent.X, agent.Y);
        }

        public bool moveAgent(int currentX, int currentY, int newX, int newY) // move agent from one cell to another
        {
            if (world[currentX, currentY].occupied & !world[newX, newY].occupied) // if there is an agent in the current location and no agent in the new location
            {
                Agent movingAgent = world[currentX, currentY].getAgent();
                movingAgent.X = newX;
                movingAgent.Y = newY;
                world[newX, newY].setAgent(movingAgent);
                world[currentX, currentY].removeAgent();

                // add food of the new location to the agent according to its carnivor percentage
                float temp = world[newX, newY].food;
                temp = temp * ((100 - (float)movingAgent.CarnivorePercentage) / 100);
                movingAgent.Food += (int)Math.Round(temp);
                world[newX, newY].food = 0;

                return true;
            }
            return false;
        }

        public bool moveAgent(Agent agent, int newX, int newY)
        {
            return moveAgent(agent.X, agent.Y, newX, newY);
        }

        public void AddFoodToWorld(int chancePerCell) // add food to the world with a giving chance for each cell
        {
            for (int x = 0; x < worldWidth; x++)
            {
                for (int y = 0; y < worldHeight; y++)
                {
                    if (random.Next(10000) < chancePerCell & world[x, y].food < 200)
                    {
                        world[x, y].food = random.Next(MinAddedFood, MaxAddedFood + 1);
                    }
                }
            }
        }

        public int GetFood(int X, int Y)
        {
            return world[X, Y].food;
        }

        public double GetRed(int X, int Y)
        {
            return world[X, Y].getAgent().Red;
        }

        public double GetBlue(int X, int Y)
        {
            return world[X, Y].getAgent().Blue;
        }

        public double GetGreen(int X, int Y)
        {
            return world[X, Y].getAgent().Green;
        }

        public int GetId(int X, int Y)
        {
            if (world[X, Y].occupied)
            {
                return world[X, Y].getAgent().ID;
            }
            return -1;
        }

        public int GetFoodCountInWorld() // add all of the food in the world and return this
        {
            int count = 0;
            for (int x = 0; x < worldWidth; x++)
            {
                for (int y = 0; y < worldHeight; y++)
                {
                    if (world[x, y].food != 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
