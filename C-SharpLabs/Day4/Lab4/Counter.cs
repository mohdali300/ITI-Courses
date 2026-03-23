using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Counter
    {
        public static int totalObjectsCreated;
        public int instanceId;

        static Counter()
        {
            totalObjectsCreated = 0;
        }

        public Counter()
        {
            totalObjectsCreated++;
            instanceId = totalObjectsCreated;
        }
    }
}
