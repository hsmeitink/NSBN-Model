using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSBN_V._2._1
{
    class heratigeNode // still being implemented
    {
        public int ParentID;
        public List<int> childrenIDs = new List<int>();
        public bool alive = true;
        public heratigeNode(int parentID)
        {
            ParentID = parentID;
        }
    }
}
