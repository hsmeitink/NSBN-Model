using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSBN_V._2._1
{
    /// <summary>
    /// resembles a single cell in the grid that is called the world
    /// </summary>

    class Cell
    {
        Agent agent = null;
        public int food = 0;
        public bool occupied = false;

        public bool setAgent(Agent agent)
        {
            if (!occupied)
            {
                this.agent = agent;
                occupied = true;
                return true;
            }
            return false;
        }

        public Agent getAgent()
        {
            return agent;
        }

        public bool removeAgent()
        {
            if (occupied)
            {
                this.agent = null;
                occupied = false;
                return true;
            }
            return false;
        }
    }
}
