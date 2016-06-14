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
        Province Germany ;
        Province Western_Europe ;
        Province Southern_Europe;
        Province Balkans ;
        Province Eatern_Europe ;
        Province Ukraine ;
        Province Belorussia;
        Province Archangel;
        Province Karelia ;
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
        List<string> nextnextInLine = new List<string>();
        #endregion

        #endregion

        public Game()
        {
            InitializeComponent();

            switch (Menu.nation)
            {
                case "USSR":
                    income = 7;
                    aiIncome = 12;
                    break;

                case "Germany":
                    income = 12;
                    aiIncome = 7;
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

            world = new Province[] { Germany, Western_Europe, Southern_Europe, Balkans, Eatern_Europe, Ukraine, Belorussia, Archangel, Karelia, Caucasus ,Russia ,WesternRussia };

            Set_up();

            phaseLabel.Text = "Movement";
            phase = 1;
            incomeLabel.Text = Convert.ToString(income);
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
                                world[counter].owner = greatgrandchild.InnerText;
                            }

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

        private void buyButton_Click(object sender, EventArgs e)
        {
            try
            {
                typeLabel.Text = "Type:";

                Unit u = new Unit(Convert.ToString(buyBox.Text), "Germany", "Germany");

                if (Menu.nation == "Germany" && income > u.cost)
                {
                    world[0].garrison.Add(u);
                    income -= u.cost;

                    Refresh();
                }
                else if (income > u.cost)
                {
                    u.owner = "USSR";
                    u.province = "Russia";
                    world[10].garrison.Add(u);
                    income -= u.cost;

                    Refresh();
                }
            }
            catch
            {
                typeLabel.Text = "Error";
            }
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.Map_1, 0, 0, 500, 300);

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

        private void button2_Click(object sender, EventArgs e)
        {
            switch (phase)
            {
                case 1:
                    phase = 2;
                    counter = 0;

                    foreach (Province p in world)
                    {
                        if (p.owner == Menu.nation)
                        {
                            income++;
                        }
                    }

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
                        if (counter < 5)
                        {
                            counter++;
                        }
                    }

                    foreach (Province p in world)
                    {
                        foreach (Unit u in p.garrison)
                        {
                            u.move = u.oMove;
                        }
                    }

                    
                    break;

                case 2:

                    #region AI turn

                    ussrProvinces.Clear();
                    germanyProvinces.Clear();

                    if (aination == "USSR")
                    {

                        foreach (Province p in world)
                        {
                            if (p.owner == "USSR")
                            {
                                ussrProvinces.Add(p);
                            }
                        }

                        foreach (Province p in ussrProvinces)
                        {
                            switch (p.name)
                            {
                                case "Germany":

                                    #region Win
                                    #endregion

                                    break;

                                case "Eastern_Europe":
                                    if (ussrProvinces.Count() > 8)
                                    {
                                        aitarget = "Germany";
                                        counter = 0;
                                    }
                                    break;
                                case "Balkans":
                                    if (ussrProvinces.Count() > 9)
                                    {
                                        aitarget = "Eastern_Europe";
                                        counter = 4;
                                    }
                                    break;

                                case "Ukraine":
                                    if (ussrProvinces.Count() > 4)
                                    {
                                        aitarget = "Balkans";
                                        counter = 3;
                                    }
                                    break;
                                case "Belorussia":
                                    if (ussrProvinces.Count() > 4)
                                    {
                                        aitarget = "Ukraine";
                                        counter = 3;
                                    }
                                    break;
                                case "Karelia":
                                    if (ussrProvinces.Count() > 7)
                                    {
                                        aitarget = "Belorussia";
                                        counter = 6;
                                    }
                                    break;
                                case "Archangel":
                                    if (ussrProvinces.Count() > 6)
                                    {
                                        aitarget = "Karelia";
                                        counter = 8;
                                    }
                                    break;
                                case "WesternRussia":
                                    if (ussrProvinces.Count() > 5)
                                    {
                                        aitarget = "Archangel";
                                        counter = 7;
                                    }
                                    break;
                                case "Caucasus":
                                    if (ussrProvinces.Count() > 3)
                                    {
                                        aitarget = "WesternRussia";
                                        counter = 11;
                                    }
                                    break;
                                case "Russia":
                                    if (ussrProvinces.Count() > 2)
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
                    else
                    {
                        foreach (Province p in world)
                        {
                            if (p.owner == "Germany")
                            {
                                germanyProvinces.Add(p);
                            }
                        }

                        foreach (Province p in ussrProvinces)
                        {
                            switch (p.name)
                            {
                                case "Russia":

                                    break;
                                case "Archangel":
                                    if (ussrProvinces.Count() > 9)
                                    {
                                        aitarget = "Russia";
                                        counter = 9;
                                    }
                                    break;
                                case "WesternRussia":
                                    if (ussrProvinces.Count() > 8)
                                    {
                                        aitarget = "Archangel";
                                        counter = 7;
                                    }
                                    break;
                                case "Caucasus":
                                    if (ussrProvinces.Count() > 7)
                                    {
                                        aitarget = "WesternRussia";
                                        counter = 11;
                                    }
                                    break;
                                case "Ukraine":
                                    if (ussrProvinces.Count() > 6)
                                    {
                                        aitarget = "Caucasus";
                                        counter = 10;
                                    }
                                    break;
                                case "Belorussia":
                                    if (ussrProvinces.Count() > 5)
                                    {
                                        aitarget = "Ukraine";
                                        counter = 5;
                                    }
                                    break;
                                case "Karelia":
                                    if (ussrProvinces.Count() > 4)
                                    {
                                        aitarget = "Belorussia";
                                        counter = 6;
                                    }
                                    break;
                                case "Eastern_Europe":
                                    if (ussrProvinces.Count() > 3)
                                    {
                                        aitarget = "Ukraine";
                                        counter = 5;
                                    }
                                    break;
                                case "Balkans":
                                    if (ussrProvinces.Count() > 3)
                                    {
                                        aitarget = "Eastern_Europe";
                                        counter = 4;
                                    }
                                    break;
                                case "Germany":
                                    if (ussrProvinces.Count() > 2)
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

                    #region Attack

                    foreach (Province p in ussrProvinces)
                    {
                        if (p.landConnection.Contains(aitarget) && p.garrison.Count() > world[counter].garrison.Count())
                        {
                            InLine.Add(p.name);

                            foreach (Unit u in p.garrison)
                            {
                                if (u.move > 0)
                                {
                                    u.move--;
                                    u.province = aitarget;

                                    world[counter].garrison.Add(u);
                                    p.garrison.Remove(u);
                                }
                            }
                        }
                        else
                        {
                            foreach (string s in InLine)
                            {
                                if (p.landConnection.Contains(s))
                                {
                                    nextInLine.Add(p.name);

                                    foreach (Unit u in p.garrison)
                                    {
                                        if (u.move > 0)
                                        {
                                            u.move--;
                                            u.province = s;

                                            world[counter].garrison.Add(u);
                                            p.garrison.Remove(u);
                                        }
                                    }
                                }
                                else
                                {
                                    foreach (string st in nextInLine)
                                    {
                                        if (p.landConnection.Contains(st))
                                        {
                                            foreach (Unit u in p.garrison)
                                            {
                                                if (u.move > 0)
                                                {
                                                    u.move--;
                                                    u.province = st;

                                                    world[counter].garrison.Add(u);
                                                    p.garrison.Remove(u);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

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

                    #endregion
                    break;

                default:
                    break;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void movingButton_Click(object sender, EventArgs e)
        {
            if (world[counter].garrison[garrisonBox.SelectedIndex].move > 0)
            {
                world[counter].garrison[garrisonBox.SelectedIndex].move--;
                world[counter].garrison[garrisonBox.SelectedIndex].province = world[secondCounter].name;

                world[secondCounter].garrison.Add(world[counter].garrison[garrisonBox.SelectedIndex]);
                world[counter].garrison.RemoveAt(garrisonBox.SelectedIndex);

                garrisonBox.Items.Clear();
                garrisonBox2.Items.Clear();

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

        private void movingButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (world[secondCounter].garrison[garrisonBox2.SelectedIndex].move > 0)
                {
                    world[secondCounter].garrison[garrisonBox2.SelectedIndex].move--;
                    world[secondCounter].garrison[garrisonBox2.SelectedIndex].province = world[counter].name;

                    world[counter].garrison.Add(world[secondCounter].garrison[garrisonBox2.SelectedIndex]);
                    world[secondCounter].garrison.RemoveAt(garrisonBox2.SelectedIndex);

                    garrisonBox.Items.Clear();
                    garrisonBox2.Items.Clear();

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

        private void germanyButton_Click(object sender, EventArgs e)
        {
            counter = 0;
            garrisonBox.Items.Clear();
            garrisonBox2.Items.Clear();
            dropDown.Items.Clear();


            provinceLabel.Text = world[counter].name;
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

            foreach (string s in world[counter].landConnection)
            {
                dropDown.Items.Add(s);
            }
        }

        private void westernEuropeButton_Click(object sender, EventArgs e)
        {
            counter = 1;
            garrisonBox.Items.Clear();
            garrisonBox2.Items.Clear();
            dropDown.Items.Clear();


            provinceLabel.Text = world[counter].name;
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

            foreach (string s in world[counter].landConnection)
            {
                dropDown.Items.Add(s);
            }
        }

        private void easternEurope_Click(object sender, EventArgs e)
        {
            counter = 3;
            garrisonBox.Items.Clear();
            garrisonBox2.Items.Clear();
            dropDown.Items.Clear();


            provinceLabel.Text = world[counter].name;
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

            foreach (string s in world[counter].landConnection)
            {
                dropDown.Items.Add(s);
            }
        }

        private void southernEurope_Click(object sender, EventArgs e)
        {
            counter = 2;
            garrisonBox.Items.Clear();
            garrisonBox2.Items.Clear();
            dropDown.Items.Clear();


            provinceLabel.Text = world[counter].name;
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

            foreach (string s in world[counter].landConnection)
            {
                dropDown.Items.Add(s);
            }
        }
    }
}
