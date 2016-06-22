using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Axis_and_Allies
{
    public partial class Battle : UserControl
    {

        Random random = new Random();
        int attakHits, defenseHits, aInf, aArt, aArm, aFig, aBom, dInf, dArt, dArm, dFig, dBom, counter, check, secondcheck;
         
        public Battle()
        {
            //set variables
            InitializeComponent();
            attakHits = 0;
            defenseHits = 0;    
        }

        private void Battle_Load(object sender, EventArgs e)
        {
            //set variables
            counter = Game.counter;
            aInf = aArt = aArm = aFig = aBom = dInf = dArt = dArm = dFig = dBom = check = 0;

            //focus the uc
            this.Focus();

            //show the name of the province
            provinceLabel.Text = Game.world[Game.counter].name;

            //foreach attacking unit count it and display the numbers on the screen
            foreach (Unit u in Game.world[counter].garrison)
            {
                if (u.owner != Game.world[counter].owner)
                {
                    attackerLabel.Text = u.owner;

                    if (u.type == "infantry")
                    {
                        aInf++;
                        attackInfLabel.Text = Convert.ToString(aInf);
                    }
                    else if (u.type == "artillery")
                    {
                        aArt++;
                        atttackArtLabel.Text = Convert.ToString(aArt);
                    }
                    else if (u.type == "armour")
                    {
                        aArm++;
                        attackArmLabel.Text = Convert.ToString(aArm);
                    }
                    else if (u.type == "fighter")
                    {
                        aFig++;
                        attackFigLabel.Text = Convert.ToString(aFig);
                    }
                    else if (u.type == "bomber")
                    {
                        aBom++;
                        attackBomLabel.Text = Convert.ToString(aBom);
                    }
                }
                //same for the defenders
                else
                {
                    if (u.type == "infantry")
                    {
                        dInf++;
                        defenseInfLabel.Text = Convert.ToString(dInf);
                    }
                    else if (u.type == "artillery")
                    {
                        dArt++;
                        defenseArtLabel.Text = Convert.ToString(dArt);
                    }
                    else if (u.type == "armour")
                    {
                        dArm++;
                        defenseArmLabel.Text = Convert.ToString(dArm);
                    }
                    else if (u.type == "fighter")
                    {
                        dFig++;
                        defenseFigLabel.Text = Convert.ToString(dFig);
                    }
                    else if (u.type == "bomber")
                    {
                        dBom++;
                        defenseBomLabel.Text = Convert.ToString(dBom);
                    }
                }
            }
             
            //set the defenders label as the owners name
            defenseLabel.Text = Game.world[counter].owner;
        }

        private void attackButton_Click(object sender, EventArgs e)
        {
            //set variables
            check = secondcheck = 0;

            //roll a random number for each unit to see if it lands a hit
            foreach (Unit u in Game.world[counter].garrison)
            {
                if (u.owner != Game.world[counter].owner)
                {
                    if (random.Next(1, 7) <= u.attack)
                    {
                        attakHits++;
                    }
                }
                else
                {
                    if (random.Next(1, 7) <= u.defense)
                    {
                        defenseHits++;
                    }
                }
            }

            //count the hits and remove a unit for each one
            for (int i = 0; i < attakHits; i ++)
            {
                foreach (Unit u in Game.world[counter].garrison)
                {
                    if (u.owner == Game.world[counter].owner)
                    {
                        Game.world[counter].garrison.Remove(u);
                        break;
                    }
                }
            }
            for (int i = 0; i < defenseHits; i++)
            {
                foreach (Unit u in Game.world[counter].garrison)
                {
                    if (u.owner != Game.world[counter].owner)
                    {
                        Game.world[counter].garrison.Remove(u);
                        break;
                    }
                }
            }

            //check to see if one side is empty
            foreach (Unit u in Game.world[counter].garrison)
            {
                if (u.owner == Game.world[counter].owner)
                {
                    secondcheck++;     
                }
                else
                {
                    check++;
                }
            }

            //if so than end the battle and returnt to the main uc
            if (secondcheck == 0)
            {
                if (Game.world[counter].garrison.Count() > 0)
                {
                    Game.world[counter].owner = Game.world[counter].garrison[0].owner;
                }
                Form f = this.FindForm();
                f.Controls.Remove(this);
                
            }
            else if (check == 0)
            {
                Form f = this.FindForm();
                f.Controls.Remove(this);
                
            }

            //else redo all the labels and recount the units for both sides
            aInf = aArt = aArm = aFig = aBom = dInf = dArt = dArm = dFig = dBom = 0;

            foreach (Unit u in Game.world[counter].garrison)
            {
                if (u.owner != Game.world[counter].owner)
                {
                   
                    if (u.type == "infantry")
                    {
                        aInf++;
                        attackInfLabel.Text = Convert.ToString(aInf);
                    }
                    else if (u.type == "artillery")
                    {
                        aArt++;
                        atttackArtLabel.Text = Convert.ToString(aArt);
                    }
                    else if (u.type == "armour")
                    {
                        aArm++;
                        attackArmLabel.Text = Convert.ToString(aArm);
                    }
                    else if (u.type == "fighter")
                    {
                        aFig++;
                        attackFigLabel.Text = Convert.ToString(aFig);
                    }
                    else if (u.type == "bomber")
                    {
                        aBom++;
                        attackBomLabel.Text = Convert.ToString(aBom);
                    }
                }
                else
                {
                    if (u.type == "infantry")
                    {
                        dInf++;
                        defenseInfLabel.Text = Convert.ToString(dInf);
                    }
                    else if (u.type == "artillery")
                    {
                        dArt++;
                        defenseArtLabel.Text = Convert.ToString(dArt);
                    }
                    else if (u.type == "armour")
                    {
                        dArm++;
                        defenseArmLabel.Text = Convert.ToString(dArm);
                    }
                    else if (u.type == "fighter")
                    {
                        dFig++;
                        defenseFigLabel.Text = Convert.ToString(dFig);
                    }
                    else if (u.type == "bomber")
                    {
                        dBom++;
                        defenseBomLabel.Text = Convert.ToString(dBom);
                    }
                }
            }

           
        
    }

        private void retreatButton_Click(object sender, EventArgs e)
        {
            //if you decide to retreat move all units back to thier respective capitals
            foreach (Unit u in Game.world[Game.counter].garrison)
            {
                if (u.owner != Game.world[Game.counter].owner && u.owner == Menu.nation)
                {
                    if (Menu.nation == "Germany")
                    {
                        Game.world[0].garrison.Add(u);
                        Game.world[Game.counter].garrison.Remove(u);
                    }
                    else
                    {
                        Game.world[10].garrison.Add(u);
                        Game.world[Game.counter].garrison.Remove(u);
                    }
                }
            }

            //return to the main form
            Form f = this.FindForm();
            f.Controls.Remove(this);
        }
    }
}
