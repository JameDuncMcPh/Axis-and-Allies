using System;
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
        //europe
        Province Germany, Western_Europe, Southern_Europe, Balkans, Eatern_Europe;

        Province[] world;
        #endregion    

        #endregion

        public Game()
        {
            InitializeComponent();

            world = new Province[] { Germany, Western_Europe, Southern_Europe, Southern_Europe, Balkans, Eatern_Europe };

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
                                //world[counter].owner = greatgrandchild.InnerText;
                                world[counter].owner = "";
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
            provinceLabel.Text = "Germany";
            garrisonBox.Text = "";

            foreach (Unit u in Germany.garrison)
            {
                switch (u.type)
                {
                    case "infantry":
                        garrisonBox.Text += "inf";
                        break;

                    case "artillery":
                        garrisonBox.Text += "art";
                        break;

                    case "tank":
                        garrisonBox.Text += "arm";
                        break;

                    case "figther":
                        garrisonBox.Text += "fig";
                        break;

                    case "bomber":
                        garrisonBox.Text += "bom";
                        break;
                    default:
                        break;
                }
            }
        }

        private void westernEuropeButton_Click(object sender, EventArgs e)
        {

        }

    }
}
