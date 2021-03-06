﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axis_and_Allies
{
    public class Unit
    {
        public int attack, defense, hitpoint, cost, move, oMove;

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
                    oMove = 1;
                    hitpoint = 1;
                    cost = 3;

                    break;

                case "artillery":

                    attack = 2;
                    defense = 2;
                    move = 1;
                    oMove = 1;
                    hitpoint = 1;
                    cost = 4;

                    break;

                case "armour":

                    attack = 3;
                    defense = 3;
                    move = 2;
                    oMove = 2;
                    hitpoint = 1;
                    cost = 5;

                    break;

                case "fighter":

                    attack = 4;
                    defense = 4;
                    move = 3;
                    oMove = 3;
                    hitpoint = 1;
                    cost = 10;

                    break;

                case "bomber":

                    attack = 4;
                    defense = 1;
                    move = 6;
                    oMove = 6;
                    hitpoint = 1;
                    cost = 15;

                    break;



                default:
                    break;
            }

            owner = owner_;
            province = province_;
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
