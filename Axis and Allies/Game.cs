﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Axis_and_Allies
{
    public partial class Game : UserControl
    {

        #region Variables
        //Ints
        int income, counter, amount;
        string nation, sting;

        #region Provinces

        List<Unit> unit = new List<Unit>();
        List<string> s = new List<string>();

        //europe
        Province Germany, Western_Europe, Southern_Europe, Balkans, Eatern_Europe;

        Province[] world;
        #endregion    

        #endregion

        public Game()
        {
            InitializeComponent();

           

            switch (Menu.nation)
            {
                case "USSR":
                    income = 7;
                    break;

                case "Germany":
                    income = 12;
                    break;

                case "UK":
                    income = 12;
                    break;

                case "Japan":
                    income = 9;
                    break;

                case "USA":
                    income = 12;
                    break;

                default:
                    break;
            }
        }

        private void Game_Load(object sender, EventArgs e)
        {
            this.Focus();

            nation = Menu.nation;

            #region Provinces

            List<Unit> unit;
            List<string> s = new List<string>();

            //europe
            Province Germany = new Province(unit = new List<Unit>(), s, s, "", "");
            Province Western_Europe = new Province(unit = new List<Unit>(), s, s, "", "");
            Province Southern_Europe = new Province(unit = new List<Unit>(), s, s, "", "");
            Province Balkans = new Province(unit = new List<Unit>(), s, s, "", "");
            Province Eatern_Europe = new Province(unit = new List<Unit>(), s, s, "", "");

            #endregion

            world = new Province[] { Germany, Western_Europe,  Southern_Europe, Balkans, Eatern_Europe };

            Set_up();
        }

        private void Set_up()
        {
            counter = 0;
            amount = 0;
            sting = "";

            XmlDocument doc = new XmlDocument();
            doc.Load("Setup.xml");

            //create a node variable to represent the parent element
            XmlNode parent;
            parent = doc.DocumentElement;

            foreach (XmlNode child in parent)
            {
                if (child.Name == "map")
                {
                    foreach (XmlNode grandchild in child)
                    {
                        Unit inf = new Unit("infantry", "Germany", Convert.ToString(world[counter]));
                        Unit art = new Unit("artillery", "Germany", Convert.ToString(world[counter]));
                        Unit arm = new Unit("armour", "Germany", Convert.ToString(world[counter]));
                        Unit fig = new Unit("fighter", "Germany", Convert.ToString(world[counter]));
                        Unit bom = new Unit("bomber", "Germany", Convert.ToString(world[counter]));

                        foreach (XmlNode greatgrandchild in grandchild)
                        {
                            try
                            {
                                amount = Convert.ToInt16(greatgrandchild.InnerText);
                            }
                            catch
                            {
                                amount = 0;
                            }

                            if (greatgrandchild.Name == "infantry")
                            {
                                for (int i = 0; i < amount; i++)
                                {
                                    world[counter].garrison.Add(inf);
                                }
                            }
                            else if (greatgrandchild.Name == "artillery")
                            {
                                for (int i = 0; i < amount; i++)
                                {
                                    world[counter].garrison.Add(art);
                                }
                            }
                            else if (greatgrandchild.Name == "armour")
                            {
                                for (int i = 0; i < amount; i++)
                                {
                                    world[counter].garrison.Add(arm);
                                }
                            }
                            else if (greatgrandchild.Name == "fighter")
                            {
                                for (int i = 0; i < amount; i++)
                                {
                                    world[counter].garrison.Add(fig);
                                }
                            }
                            else if (greatgrandchild.Name == "bomber")
                            {
                                for (int i = 0; i < amount; i++)
                                {
                                    world[counter].garrison.Add(bom);
                                }
                            }
                            else if (greatgrandchild.Name == "landcon")
                            {
                                foreach (char c in greatgrandchild.InnerText)
                                {
                                    if (c != ',')
                                    {
                                        sting += c;
                                    }

                                    foreach (Province p in world)
                                    {
                                        if (sting == Convert.ToString(p))
                                        {
                                            world[counter].landConnection.Add(sting);
                                            sting = "";
                                        }
                                    }
                                }
                            }
                            else if (greatgrandchild.Name == "owner")
                            {
                                world[counter].owner = greatgrandchild.InnerText;    
                            }
                            else if (greatgrandchild.Name == "IC")
                            {
                                if (greatgrandchild.InnerText == "YES")
                                {
                                    world[counter].factory = "yes";
                                    
                                }
                                else
                                {
                                   world[counter].factory = "no";
                                    
                                }
                            }
                        }
                        counter++;
                    }
                }
            }
        }

        private void Income()
        {

        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.map, 0, 0, 500, 300);

            switch (nation)
            {
                case "USSR":
                    e.Graphics.DrawImage(Properties.Resources.soviet, 25, 350, 50, 50);
                    break;
                case "Germany":
                    e.Graphics.DrawImage(Properties.Resources.Nazi, 25, 350, 50, 50);
                    break;
                case "UK":
                    e.Graphics.DrawImage(Properties.Resources.UK_raf, 25, 350, 50, 50);
                    break;
                case "Japan":
                    e.Graphics.DrawImage(Properties.Resources.japan_sun, 25, 350, 50, 50);
                    break;
                case "USA":
                    e.Graphics.DrawImage(Properties.Resources.usa_star, 25, 350, 50, 50);
                    break;
                default:
                    break;
            }
        }

        private void germanyButton_Click(object sender, EventArgs e)
        {
            counter = 0;
            provinceLabel.Text = "Germany";
            garrisonBox.Text = "";

            foreach (Unit u in world[counter].garrison)
            {
                switch (u.type)
                {
                    case "infantry":
                        garrisonBox.Items.Add("inf");
                        break;

                    case "artillery":
                        garrisonBox.Items.Add("art");
                        break;

                    case "tank":
                        garrisonBox.Items.Add("arm");
                        break;

                    case "fighter":
                        garrisonBox.Items.Add("fig");
                        break;

                    case "bomber":
                        garrisonBox.Items.Add("bom");
                        break;
                    default:
                        break;
                }
            }
        }

        private void westernEuropeButton_Click(object sender, EventArgs e)
        {

        }

        private void movingButton_Click(object sender, EventArgs e)
        {
            foreach (string s in world[counter].landConnection)
            {
                if (s == textBox1.Text)
                {
                    garrisonBox2.Items.Add(garrisonBox.SelectedIndex.ToString());
                    garrisonBox.Items.Remove(garrisonBox.SelectedIndex.ToString());
                }
            }    
        }

        private void movingButton2_Click(object sender, EventArgs e)
        {
            garrisonBox.Items.Add(garrisonBox2.SelectedIndex.ToString());
            garrisonBox2.Items.Remove(garrisonBox2.SelectedIndex.ToString());
        }
    }
}
