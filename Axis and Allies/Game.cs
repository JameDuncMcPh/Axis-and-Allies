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
        /// <summary>
        /// Created by Duncan McPherson
        /// Jun 7 2016
        /// A board game of operation babrossa
        /// </summary>

        #region Variables
        //Ints
        public static int income, counter, secondCounter, amount, phase;
        string nation, sting, location;
        List<Province> germanyProvinces = new List<Province>();
        List<Province> ussrProvinces = new List<Province>();

        #region Provinces

        List<Unit> unit;
        List<string> s = new List<string>();

        //europe
        Province Germany;
        Province Western_Europe;
        Province Southern_Europe;
        Province Balkans;
        Province Eatern_Europe;
        Province Ukraine;
        Province Belorussia;
        Province Archangel;
        Province Karelia;
        Province Caucasus;
        Province Russia;
        Province WesternRussia;

        public static Province[] world;
        #endregion

        #region AI
        int aiIncome = 0;
        string aination, aitarget;
        List<string> InLine = new List<string>();
        List<string> nextInLine = new List<string>();
        List<int> intLine = new List<int>();
        List<int> nextintLine = new List<int>();
        #endregion

        #endregion

        public Game()
        {
            InitializeComponent();

            //setup the ai and human stuff
            switch (nation)
            {
                case "USSR":
                    //incomes
                    income = 7;
                    aiIncome = 12;

                    //names
                    aination = "Germany";
                    break;

                case "Germany":
                    //incomes
                    income = 12;
                    aiIncome = 7;

                    //names
                    aination = "USSR";
                    break;

                default:
                    break;
            }
        }

        private void Game_Load(object sender, EventArgs e)
        {
            //focus on this form
            this.Focus();

            //set which nation the player is
            nation = Menu.nation;

            //create trhe provinces and add them to the world
            #region Provinces

            List<Unit> unit;
            List<string> s = new List<string>();

            //europe
            Province Germany = new Province("", unit = new List<Unit>(), s = new List<string>(), s = new List<string>(), "", "");
            Province Western_Europe = new Province("", unit = new List<Unit>(), s = new List<string>(), s = new List<string>(), "", "");
            Province Southern_Europe = new Province("", unit = new List<Unit>(), s = new List<string>(), s = new List<string>(), "", "");
            Province Balkans = new Province("", unit = new List<Unit>(), s = new List<string>(), s = new List<string>(), "", "");
            Province Eatern_Europe = new Province("", unit = new List<Unit>(), s = new List<string>(), s = new List<string>(), "", "");
            Province Ukraine = new Province("", unit = new List<Unit>(), s = new List<string>(), s = new List<string>(), "", "");
            Province Belorussia = new Province("", unit = new List<Unit>(), s = new List<string>(), s = new List<string>(), "", "");
            Province Archangel = new Province("", unit = new List<Unit>(), s = new List<string>(), s = new List<string>(), "", "");
            Province Karelia = new Province("", unit = new List<Unit>(), s = new List<string>(), s = new List<string>(), "", "");
            Province Caucasus = new Province("", unit = new List<Unit>(), s = new List<string>(), s = new List<string>(), "", "");
            Province Russia = new Province("", unit = new List<Unit>(), s = new List<string>(), s = new List<string>(), "", "");
            Province WesternRussia = new Province("", unit = new List<Unit>(), s = new List<string>(), s = new List<string>(), "", "");
            #endregion

            world = new Province[] { Germany, Western_Europe, Southern_Europe, Balkans, Eatern_Europe, Ukraine, Belorussia, Archangel, Karelia, Caucasus, Russia, WesternRussia };

            //load the save files
            Set_up(Menu.load);

            //set the variables for the beginng
            dropDown.Text = "Select province";
            incomeLabel.Text = "Income: " + income.ToString();

            if (phase == 1)
            {
                phaseLabel.Text = "Movement";
                button2.Text = "To Combat";
            }
            else if (phase == 2)
            {
                phaseLabel.Text = "Combat";
                button2.Text = "End Turn";
            }
            else if (phase == 3)
            {
                phaseLabel.Text = "AI TURN";
                button2.Text = "Begin Turn";
            }
            else
            {
                phaseLabel.Text = "Movement";
                button2.Text = "To Combat";
            }

            //set the unit for purchase
            purchaseBox.Items.Add("infantry");
            purchaseBox.Items.Add("artillery");
            purchaseBox.Items.Add("armour");
            purchaseBox.Items.Add("fighter");
            purchaseBox.Items.Add("bomber");

        }

        private void Set_up(string s)
        {
            //set variables to null
            counter = 0;
            amount = 0;
            sting = "";

            //select document to read
            XmlDocument doc = new XmlDocument();
            doc.Load("Setup.xml");

            //create a node variable to represent the parent element
            XmlNode parent;
            parent = doc.DocumentElement;

            //start looking for the right node to find information
            foreach (XmlNode child in parent)
            {
                //try and load player information
                if (child.Name == "player")
                {
                    foreach (XmlNode grandchild in child)
                    {
                        try
                        {
                            if (grandchild.Name == "IPC")
                            {
                                income = Convert.ToInt16(grandchild.InnerText);
                            }
                            else if (grandchild.Name == "country" && (grandchild.InnerText == "USSR"|| grandchild.InnerText == "Germany"))
                            {
                                Menu.nation = Convert.ToString(grandchild.InnerText);
                            }
                            else if (grandchild.Name == "phase")
                            {
                                phase = Convert.ToInt16(grandchild.InnerText);
                            }
                        }
                        catch
                        {
                        }
                    }
                }

                //whether to choose save or new game data
                if (child.Name == s)
                {
                    foreach (XmlNode grandchild in child)
                    {
                        //set province name
                        world[counter].name = grandchild.Name;

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

                            if (greatgrandchild.Name == "owner")
                            {
                                //set the owner
                                world[counter].owner = greatgrandchild.InnerText;
                            }

                            //add the units the the garrisons
                            if (greatgrandchild.Name == "infantry")
                            {
                                for (int i = 0; i < amount; i++)
                                {
                                    Unit inf = new Unit("infantry", world[counter].owner, world[counter].name);
                                    world[counter].garrison.Add(inf);
                                }
                            }
                            else if (greatgrandchild.Name == "artillery")
                            {
                                for (int i = 0; i < amount; i++)
                                {
                                    Unit art = new Unit("artillery", world[counter].owner, world[counter].name);
                                    world[counter].garrison.Add(art);
                                }
                            }
                            else if (greatgrandchild.Name == "armour")
                            {
                                for (int i = 0; i < amount; i++)
                                {
                                    Unit arm = new Unit("armour", world[counter].owner, world[counter].name);
                                    world[counter].garrison.Add(arm);
                                }
                            }
                            else if (greatgrandchild.Name == "fighter")
                            {
                                for (int i = 0; i < amount; i++)
                                {
                                    Unit fig = new Unit("fighter", world[counter].owner, world[counter].name);
                                    world[counter].garrison.Add(fig);
                                }
                            }
                            else if (greatgrandchild.Name == "bomber")
                            {
                                for (int i = 0; i < amount; i++)
                                {
                                    Unit bom = new Unit("bomber", world[counter].owner, world[counter].name);
                                    world[counter].garrison.Add(bom);
                                }
                            }
                            //add the land connection 
                            else if (greatgrandchild.Name == "landcon")
                            {
                                foreach (char c in greatgrandchild.InnerText)
                                {
                                    if (c != ',')
                                    {
                                        sting += c;
                                    }
                                    else
                                    {
                                        world[counter].landConnection.Add(sting);
                                        sting = "";
                                    }
                                }
                            }

                            //whether thier is a factory or not
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
                        //move onto the next one
                        counter++;
                    }
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //variables for saving
            int aInf, aArt, aArm, aFig, aBom;
            aInf = aArt = aArm = aFig = aBom = 0;
            string landcon = "";

            //create writer
            XmlTextWriter writer = new XmlTextWriter("Setup.xml", null);

            writer.WriteStartElement("player");

            //record information about the player
            writer.WriteElementString("IPC", income.ToString());
            writer.WriteElementString("country", nation);
            writer.WriteElementString("phase", phase.ToString());

            writer.WriteStartElement("savegame");

            //record how many units are in each provine
            foreach (Province p in world)
            {
                aInf = aArt = aArm = aFig = aBom = 0;
                writer.WriteStartElement(p.name);

                foreach (Unit u in p.garrison)
                {
                    switch (u.type)
                    {
                        case "infantry":
                            aInf++;
                            break;

                        case "artillery":
                            aArt++;
                            break;

                        case "armour":
                            aArm++;
                            break;

                        case "figther":
                            aFig++;
                            break;

                        case "bomber":
                            aBom++;
                            break;

                        default:
                            break;
                    }
                }

                //record what provinces it is adjacent to
                foreach (string s in p.landConnection)
                {
                    landcon += s + ",";
                }

                //at the stated position write each piece of informationa about the province
                writer.WriteElementString("owner", p.owner);
                writer.WriteElementString("infantry", aInf.ToString());
                writer.WriteElementString("artillery", aArt.ToString());
                writer.WriteElementString("armour", aArm.ToString());
                writer.WriteElementString("figther", aFig.ToString());
                writer.WriteElementString("bomber", aBom.ToString());
                writer.WriteElementString("landcon", landcon);
                writer.WriteElementString("IC", p.factory);

                writer.WriteEndElement();
            }

            //close off everything and quit
            writer.WriteEndElement();
            writer.Close();
            Application.Exit();
        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            //check if you can purchase a unit
            try
            {
                //set it equeal to the box
                typeLabel.Text = "Type:";
                string type = purchaseBox.Text;

                //create the new unit
                Unit u = new Unit(type, "Germany", "Germany");

                //cheack to see if thier is suffiecent income if so add it to the game
                if (nation == "Germany" && income > u.cost)
                {
                    world[0].garrison.Add(u);
                    income -= u.cost;
                    incomeLabel.Text = "Income: " + income.ToString();

                    Refresh();
                }
                else if (income > u.cost)
                {
                    u.owner = "USSR";
                    u.province = "Russia";
                    world[10].garrison.Add(u);
                    income -= u.cost;
                    incomeLabel.Text = "Income: " + income.ToString();

                    Refresh();
                }
            }
            //if not return a error
            catch
            {
                typeLabel.Text = "Error";
            }
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            //draw the map
            e.Graphics.DrawImage(Properties.Resources.Map_1, 0, 0, 500, 300);

            //draw the flag of the nation
            switch (nation)
            {
                case "USSR":
                    e.Graphics.DrawImage(Properties.Resources.soviet, 25, 350, 100, 50);
                    break;
                case "Germany":
                    e.Graphics.DrawImage(Properties.Resources.Nazi, 25, 350, 100, 50);
                    break;
                default:
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //switching phases of the game
            switch (phase)
            {
                case 0:
                    //set variables for next phase and set text for current
                    phase = 1;
                    counter = 0;
                    phaseLabel.Text = "Movement";
                    button2.Text = "To Combat";
                    break;

                case 1:
                    //set variables for next phase and set text for current
                    phase = 2;
                    counter = 0;
                    phaseLabel.Text = "Combat";
                    button2.Text = "End Turn";

                    //foreach province add 1 to your income
                    foreach (Province p in world)
                    {
                        if (p.owner == nation)
                        {
                            income++;
                        }
                    }

                    //cheack to see if the province is contested
                    foreach (Province p in world)
                    {
                        foreach (Unit u in p.garrison)
                        {
                            if (u.owner != p.owner)
                            {
                                //if so then make a battle
                                Form f = this.FindForm();
                                Battle b = new Battle();
                                f.Controls.Add(b);
                                b.BringToFront();
                                break;
                            }
                        }
                        if (counter < 11)
                        {
                            counter++;
                        }
                    }

                    foreach (Province p in world)
                    {
                        foreach (Unit u in p.garrison)
                        {
                            //reset all move
                            u.move = u.oMove;
                        }
                    }

                    break;

                case 2:
                    //set variables for next phase and set text for current
                    phase = 0;
                    counter = 0;
                    phaseLabel.Text = "AI TURN";
                    button2.Text = "Begin Turn";

                    //run AI turn
                    #region AI turn

                    //find a target to attack
                    #region Target accuriment

                    //determine what nation you are playing
                    if (nation == "USSR")
                    {
                        aination = "Germany";
                    }
                    else
                    {
                        aination = "USSR";
                    }
                    ussrProvinces.Clear();
                    germanyProvinces.Clear();

                    //russian ai 
                    if (aination == "USSR")
                    {
                        //see what provinces it controls
                        foreach (Province p in world)
                        {
                            if (p.owner == "USSR")
                            {
                                ussrProvinces.Add(p);
                            }
                            else
                            {
                                if (p.name == "Russia")
                                {
                                    //ends game if conditions are met
                                    #region Result
                                    //print out result of the game
                                    resultLabel.BringToFront();
                                    resultLabel.Text = "WINNER";
                                    #endregion
                                }
                            }
                        }

                        //then depending on provinces choose which one to attack
                        foreach (Province p in ussrProvinces)
                        {
                            switch (p.name)
                            {
                                case "Germany":
                                    //ends game if conditions are met
                                    #region Result
                                    //print out result of the game
                                    resultLabel.BringToFront();
                                    resultLabel.Text = "LOSER";
                                    #endregion
                                    break;

                                case "Eastern_Europe":
                                    if (ussrProvinces.Count() == 9)
                                    {
                                        aitarget = "Germany";
                                        counter = 0;
                                    }
                                    break;
                                case "Balkans":
                                    if (ussrProvinces.Count() == 8)
                                    {
                                        aitarget = "Eastern_Europe";
                                        counter = 3;
                                    }
                                    break;

                                case "Ukraine":
                                    if (ussrProvinces.Count() == 7)
                                    {
                                        aitarget = "Balkans";
                                        counter = 4;
                                    }
                                    break;
                                case "Belorussia":
                                    if (ussrProvinces.Count() == 6)
                                    {
                                        aitarget = "Ukraine";
                                        counter = 3;
                                    }
                                    break;
                                case "Karelia":
                                    if (ussrProvinces.Count() == 5)
                                    {
                                        aitarget = "Belorussia";
                                        counter = 6;
                                    }
                                    break;
                                case "Archangel":
                                    if (ussrProvinces.Count() == 4)
                                    {
                                        aitarget = "Karelia";
                                        counter = 8;
                                    }
                                    break;
                                case "WesternRussia":
                                    if (ussrProvinces.Count() == 3)
                                    {
                                        aitarget = "Archangel";
                                        counter = 7;
                                    }
                                    break;
                                case "Caucasus":
                                    if (ussrProvinces.Count() == 2)
                                    {
                                        aitarget = "WesternRussia";
                                        counter = 11;
                                    }
                                    break;
                                case "Russia":
                                    if (ussrProvinces.Count() == 1)
                                    {
                                        aitarget = "Caucasus";
                                        counter = 9;
                                    }
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                    //German AI
                    else
                    {
                        //find out what provinces
                        foreach (Province p in world)
                        {
                            if (p.owner == "Germany")
                            {
                                germanyProvinces.Add(p);
                            }
                            else
                            {
                                if (p.name == "Germany")
                                {
                                    //ends game if conditions are met
                                    #region Result
                                    //print out result of the game
                                    resultLabel.BringToFront();
                                    resultLabel.Text = "WINNER";
                                    #endregion
                                }
                            }
                        }

                        foreach (Province p in germanyProvinces)
                        {
                            switch (p.name)
                            {
                                case "Russia":
                                    //ends game if conditions are met
                                    #region Result
                                    //print out result of the game
                                    resultLabel.BringToFront();
                                    resultLabel.Text = "LOSER";
                                    #endregion
                                    break;
                                case "Archangel":
                                    if (germanyProvinces.Count() == 11)
                                    {
                                        aitarget = "Russia";
                                        counter = 9;
                                    }
                                    break;
                                case "WesternRussia":
                                    if (germanyProvinces.Count() == 10)
                                    {
                                        aitarget = "Archangel";
                                        counter = 7;
                                    }
                                    break;
                                case "Caucasus":
                                    if (germanyProvinces.Count() == 9)
                                    {
                                        aitarget = "WesternRussia";
                                        counter = 11;
                                    }
                                    break;
                                case "Ukraine":
                                    if (germanyProvinces.Count() == 8)
                                    {
                                        aitarget = "Caucasus";
                                        counter = 10;
                                    }
                                    break;
                                case "Belorussia":
                                    if (germanyProvinces.Count() == 7)
                                    {
                                        aitarget = "Ukraine";
                                        counter = 5;
                                    }
                                    break;
                                case "Karelia":
                                    if (germanyProvinces.Count() == 6)
                                    {
                                        aitarget = "Belorussia";
                                        counter = 6;
                                    }
                                    break;
                                case "Eastern_Europe":
                                    if (germanyProvinces.Count() == 5)
                                    {
                                        aitarget = "Ukraine";
                                        counter = 5;
                                    }
                                    break;
                                case "Balkans":
                                    if (germanyProvinces.Count() == 4)
                                    {
                                        aitarget = "Eastern_Europe";
                                        counter = 3;
                                    }
                                    break;
                                case "Germany":
                                    if (germanyProvinces.Count() == 3)
                                    {
                                        aitarget = "Balkans";
                                        counter = 3;
                                    }
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                    #endregion

                    //attack and move units
                    #region Attack

                    //check to see if one of the ai controlled provinces is adjacent to the target
                    foreach (Province p in ussrProvinces)
                    {
                        if (p.landConnection.Contains(aitarget) && p.garrison.Count() > world[counter].garrison.Count())
                        {
                            //if so move troops and set it as an adjacent province
                            InLine.Add(p.name);
                            intLine.Add(ussrProvinces.IndexOf(p));

                            for (int i = 0; i < p.garrison.Count(); i++)
                            {
                                if (p.garrison[i].move > 0)
                                {
                                    p.garrison[i].move--;
                                    p.garrison[i].province = aitarget;

                                    world[counter].garrison.Add(p.garrison[i]);
                                    p.garrison.Remove(p.garrison[i]);
                                }
                            }
                        }
                        //check to see if one of the ai controlled provinces is adjacent to the adjacent province
                        else
                        {
                            foreach (string s in InLine)
                            {
                                if (p.landConnection.Contains(s))
                                {
                                    //if so move troops and set it as an adjacent province
                                    nextInLine.Add(p.name);
                                    nextintLine.Add(ussrProvinces.IndexOf(p));
                                    secondCounter = intLine[InLine.IndexOf(s)];

                                    for (int i = 0; i < p.garrison.Count(); i++)
                                    {
                                        if (p.garrison[i].move > 0)
                                        {
                                            p.garrison[i].move--;
                                            p.garrison[i].province = s;

                                            world[secondCounter].garrison.Add(p.garrison[i]);
                                            p.garrison.Remove(p.garrison[i]);
                                        }
                                    }
                                }
                                //check to see if one of the ai controlled provinces is adjacent to the adjacent adjacent province
                                else
                                {
                                    foreach (string st in nextInLine)
                                    {
                                        //if so move troops and set it as an adjacent province
                                        if (p.landConnection.Contains(st))
                                        {
                                            secondCounter = nextintLine[nextInLine.IndexOf(st)];

                                            for (int i = 0; i < p.garrison.Count(); i++)
                                            {
                                                if (p.garrison[i].move > 0)
                                                {
                                                    p.garrison[i].move--;
                                                    p.garrison[i].province = aitarget;

                                                    world[counter].garrison.Add(p.garrison[i]);
                                                    p.garrison.Remove(p.garrison[i]);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    counter = 0;

                    foreach (Province p in world)
                    {
                        foreach (Unit u in p.garrison)
                        {
                            if (u.owner != p.owner)
                            {
                                Form f = this.FindForm();
                                Battle b = new Battle();
                                f.Controls.Add(b);
                                b.BringToFront();
                                break;
                            }
                        }
                        if (counter < 11)
                        {
                            counter++;
                        }
                    }

                    #endregion

                    //buy more units in order for the game to continue
                    #region Purchase

                    //cheack what nation is what and adds troops if thier is suffient income
                    if (nation == "USSR")
                    {
                        if (aiIncome > 3)
                        {
                            Unit u = new Unit("infantry", "USSR", "Russia");
                        }
                    }
                    else
                    {
                        if (aiIncome > 5)
                        {
                            Unit u = new Unit("infantry", "Germany", "Germany");
                        }
                    }

                    #endregion

                    #endregion

                    
                    break;

                default:
                    break;
            }
        }

        private void movingButton_Click(object sender, EventArgs e)
        {
            try
            {
                //see if it can be moved by game standards
                if (world[counter].garrison[garrisonBox.SelectedIndex].move > 0 && world[counter].garrison[garrisonBox.SelectedIndex].owner == nation)
                {
                    //move the unit from one list to another and lower its move counter
                    world[counter].garrison[garrisonBox.SelectedIndex].move--;
                    world[counter].garrison[garrisonBox.SelectedIndex].province = world[secondCounter].name;

                    world[secondCounter].garrison.Add(world[counter].garrison[garrisonBox.SelectedIndex]);
                    world[counter].garrison.RemoveAt(garrisonBox.SelectedIndex);

                    garrisonBox.Items.Clear();
                    garrisonBox2.Items.Clear();

                    //reprint all the units in both garrison boxes
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

                            case "armour":
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

                    foreach (Unit u in world[secondCounter].garrison)
                    {
                        switch (u.type)
                        {
                            case "infantry":
                                garrisonBox2.Items.Add("inf");
                                break;

                            case "artillery":
                                garrisonBox2.Items.Add("art");
                                break;

                            case "armour":
                                garrisonBox2.Items.Add("arm");
                                break;

                            case "fighter":
                                garrisonBox2.Items.Add("fig");
                                break;

                            case "bomber":
                                garrisonBox2.Items.Add("bom");
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void movingButton2_Click(object sender, EventArgs e)
        {
            //cheack to see if you can move the unit
            try
            {
                //if so than see if it can be moved by game standards
                if (world[secondCounter].garrison[garrisonBox2.SelectedIndex].move > 0 && world[counter].garrison[garrisonBox.SelectedIndex].owner == nation)
                {
                    //move the unit from one list to another and lower its move counter
                    world[secondCounter].garrison[garrisonBox2.SelectedIndex].move--;
                    world[secondCounter].garrison[garrisonBox2.SelectedIndex].province = world[counter].name;

                    world[counter].garrison.Add(world[secondCounter].garrison[garrisonBox2.SelectedIndex]);
                    world[secondCounter].garrison.RemoveAt(garrisonBox2.SelectedIndex);

                    garrisonBox.Items.Clear();
                    garrisonBox2.Items.Clear();

                    //reprint all the units in both garrison boxes
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

                            case "armour":
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
                    foreach (Unit u in world[secondCounter].garrison)
                    {
                        switch (u.type)
                        {
                            case "infantry":
                                garrisonBox2.Items.Add("inf");
                                break;

                            case "artillery":
                                garrisonBox2.Items.Add("art");
                                break;

                            case "armour":
                                garrisonBox2.Items.Add("arm");
                                break;

                            case "fighter":
                                garrisonBox2.Items.Add("fig");
                                break;

                            case "bomber":
                                garrisonBox2.Items.Add("bom");
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            //if it didn't work do nothing
            catch
            {
            }
        }

        private void dropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            secondCounter = 0;
            location = dropDown.SelectedItem.ToString();
            garrisonBox2.Items.Clear();

            foreach (Province p in world)
            {
                if (location == p.name)
                {
                    foreach (Unit u in p.garrison)
                    {
                        switch (u.type)
                        {
                            case "infantry":
                                garrisonBox2.Items.Add("inf");
                                break;

                            case "artillery":
                                garrisonBox2.Items.Add("art");
                                break;

                            case "armour":
                                garrisonBox2.Items.Add("arm");
                                break;

                            case "fighter":
                                garrisonBox2.Items.Add("fig");
                                break;

                            case "bomber":
                                garrisonBox2.Items.Add("bom");
                                break;
                            default:
                                break;
                        }
                    }

                    break;
                }
                secondCounter++;
            }
        }

        private void ukraineButton_Click(object sender, EventArgs e)
        {
            //set varialbes and clear
            counter = 5;
            garrisonBox.Items.Clear();
            garrisonBox2.Items.Clear();
            dropDown.Items.Clear();
            dropDown.Text = "";

            //set the name of the province and clear the garrison box of text
            provinceLabel.Text = world[counter].name;
            garrisonBox.Text = "";

            //add foreach unit its name to the garrison box
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

                    case "armour":
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

            //add the land connections to the drop down box
            foreach (string s in world[counter].landConnection)
            {
                dropDown.Items.Add(s);
            }
        }

        private void belorussiaButton_Click(object sender, EventArgs e)
        {
            //set varialbes and clear
            counter = 6;
            garrisonBox.Items.Clear();
            garrisonBox2.Items.Clear();
            dropDown.Items.Clear();
            dropDown.Text = "";

            //set the name of the province and clear the garrison box of text
            provinceLabel.Text = world[counter].name;
            garrisonBox.Text = "";

            //add foreach unit its name to the garrison box
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

                    case "armour":
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

            //add the land connections to the drop down box
            foreach (string s in world[counter].landConnection)
            {
                dropDown.Items.Add(s);
            }
        }

        private void westernrussiaButton_Click(object sender, EventArgs e)
        {
            //set varialbes and clear
            counter = 11;
            garrisonBox.Items.Clear();
            garrisonBox2.Items.Clear();
            dropDown.Items.Clear();
            dropDown.Text = "";

            //set the name of the province and clear the garrison box of text
            provinceLabel.Text = world[counter].name;
            garrisonBox.Text = "";

            //add foreach unit its name to the garrison box
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

                    case "armour":
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

            //add the land connections to the drop down box
            foreach (string s in world[counter].landConnection)
            {
                dropDown.Items.Add(s);
            }
        }

        private void archangelButon_Click(object sender, EventArgs e)
        {
            //set varialbes and clear
            counter = 7;
            garrisonBox.Items.Clear();
            garrisonBox2.Items.Clear();
            dropDown.Items.Clear();
            dropDown.Text = "";

            //set the name of the province and clear the garrison box of text
            provinceLabel.Text = world[counter].name;
            garrisonBox.Text = "";

            //add foreach unit its name to the garrison box
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

                    case "armour":
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

            //add the land connections to the drop down box
            foreach (string s in world[counter].landConnection)
            {
                dropDown.Items.Add(s);
            }
        }

        private void kareliaButton_Click(object sender, EventArgs e)
        {
            //set varialbes and clear
            counter = 8;
            garrisonBox.Items.Clear();
            garrisonBox2.Items.Clear();
            dropDown.Items.Clear();
            dropDown.Text = "";

            //set the name of the province and clear the garrison box of text
            provinceLabel.Text = world[counter].name;
            garrisonBox.Text = "";

            //add foreach unit its name to the garrison box
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

                    case "armour":
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

            //add the land connections to the drop down box
            foreach (string s in world[counter].landConnection)
            {
                dropDown.Items.Add(s);
            }
        }

        private void germanyButton_Click(object sender, EventArgs e)
        {
            //set varialbes and clear
            counter = 0;
            garrisonBox.Items.Clear();
            garrisonBox2.Items.Clear();
            dropDown.Items.Clear();
            dropDown.Text = "";

            //set the name of the province and clear the garrison box of text
            provinceLabel.Text = world[counter].name;
            garrisonBox.Text = "";

            //add foreach unit its name to the garrison box
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

                    case "armour":
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

            //add the land connections to the drop down box
            foreach (string s in world[counter].landConnection)
            {
                dropDown.Items.Add(s);
            }
        }

        private void westernEuropeButton_Click(object sender, EventArgs e)
        {
            //set varialbes and clear
            counter = 1;
            garrisonBox.Items.Clear();
            garrisonBox2.Items.Clear();
            dropDown.Items.Clear();
            dropDown.Text = "";

            //set the name of the province and clear the garrison box of text
            provinceLabel.Text = world[counter].name;
            garrisonBox.Text = "";

            //add foreach unit its name to the garrison box
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

                    case "armour":
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

            //add the land connections to the drop down box
            foreach (string s in world[counter].landConnection)
            {
                dropDown.Items.Add(s);
            }
        }

        private void easternEurope_Click(object sender, EventArgs e)
        {
            //set varialbes and clear
            counter = 3;
            garrisonBox.Items.Clear();
            garrisonBox2.Items.Clear();
            dropDown.Items.Clear();
            dropDown.Text = "";

            //set the name of the province and clear the garrison box of text
            provinceLabel.Text = world[counter].name;
            garrisonBox.Text = "";

            //add foreach unit its name to the garrison box
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

                    case "armour":
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

            //add the land connections to the drop down box
            foreach (string s in world[counter].landConnection)
            {
                dropDown.Items.Add(s);
            }
        }

        private void southernEurope_Click(object sender, EventArgs e)
        {
            //set varialbes and clear
            counter = 2;
            garrisonBox.Items.Clear();
            garrisonBox2.Items.Clear();
            dropDown.Items.Clear();
            dropDown.Text = "";

            //set the name of the province and clear the garrison box of text
            provinceLabel.Text = world[counter].name;
            garrisonBox.Text = "";

            //add foreach unit its name to the garrison box
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

                    case "armour":
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

            //add the land connections to the drop down box
            foreach (string s in world[counter].landConnection)
            {
                dropDown.Items.Add(s);
            }
        }

        private void Balkans_Click(object sender, EventArgs e)
        {
            //set varialbes and clear
            counter = 4;
            garrisonBox.Items.Clear();
            garrisonBox2.Items.Clear();
            dropDown.Items.Clear();
            dropDown.Text = "";

            //set the name of the province and clear the garrison box of text
            provinceLabel.Text = world[counter].name;
            garrisonBox.Text = "";

            //add foreach unit its name to the garrison box
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

                    case "armour":
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

            //add the land connections to the drop down box
            foreach (string s in world[counter].landConnection)
            {
                dropDown.Items.Add(s);
            }
        }

        private void russiaButton_Click(object sender, EventArgs e)
        {
            //set varialbes and clear
            counter = 10;
            garrisonBox.Items.Clear();
            garrisonBox2.Items.Clear();
            dropDown.Items.Clear();
            dropDown.Text = "";

            //set the name of the province and clear the garrison box of text
            provinceLabel.Text = world[counter].name;
            garrisonBox.Text = "";

            //add foreach unit its name to the garrison box
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

                    case "armour":
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

            //add the land connections to the drop down box
            foreach (string s in world[counter].landConnection)
            {
                dropDown.Items.Add(s);
            }
        }

        private void caucasusButton_Click(object sender, EventArgs e)
        {
            //set varialbes and clear
            counter = 9;
            garrisonBox.Items.Clear();
            garrisonBox2.Items.Clear();
            dropDown.Items.Clear();
            dropDown.Text = "";

            //set the name of the province and clear the garrison box of text
            provinceLabel.Text = world[counter].name;
            garrisonBox.Text = "";

            //add foreach unit its name to the garrison box
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

                    case "armour":
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

            //add the land connections to the drop down box
            foreach (string s in world[counter].landConnection)
            {
                dropDown.Items.Add(s);
            }
        }
    }
}
