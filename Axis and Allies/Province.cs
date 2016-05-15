using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axis_and_Allies
{
    class Province
    {
        public List<Unit> garrison = new List<Unit>();

        public  List<string> landConnection, seaConnections;

        public string owner, factory;

        public Province (List<Unit> garrison_, List<string> landConnection_, List<string> seaConnections_, string owner_, string factory_)
        {
            garrison = garrison_;
            landConnection = landConnection_;
            seaConnections = seaConnections_;
            owner = owner_;
            factory = factory_;
        }
    }
}
