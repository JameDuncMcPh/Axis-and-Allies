using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axis_and_Allies
{
    class Unit
    {
        public int attack, defense, hitpoint, cost, move;

        public string type, owner, province;

        public Unit (string type_, string owner_, string province_)
        {
            type = type_;

            switch (type)
            {
                case "infantry":

                    attack = 1;
                    defense = 2;
                    move = 1;
                    hitpoint = 1;
                    cost = 1;

                    break;

                case "artilleye":

                    attack = 2;
                    defense = 2;
                    move = 1;
                    hitpoint = 1;
                    cost = 3;

                    break;

                case "tank":

                    attack = 3;
                    defense = 3;
                    move = 2;
                    hitpoint = 1;
                    cost = 5;

                    break;



                default:
                    break;
            }

            owner = owner_;
            province = "null";
        }

        void unitMove(Unit a, Province d, Province b)
        {
            if (b.landConnection.Contains(Convert.ToString(d)) || b.seaConnections.Contains(Convert.ToString(d)))
            {
                foreach (Unit u in b.garrison)
                {
                    if (u.type == a.type)
                    {
                        b.garrison.Remove(u);
                        a.move -= 1;
                        d.garrison.Add(a);
                        break;
                    }
                }
            }
        }
    }
}
