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
    public partial class Game : UserControl
    {

        #region Variables
        int income;
        string nation;

        #region Units Lists
        List<Unit> germany, western_Europe, southern_Europe, balkans, eatern_Europe;


        #endregion

        #region Provinces
        List<Province> world = new List<Province>();

        //europe
        Province Germany, Western_Europe, Southern_Europe, Balkans, Eatern_Europe;
        #endregion

        List<string> map = new List<string> { "Germany", "Western_Europe", "Southern_Europe", "Balkans", "Eatern_Europe" };

        #endregion

        public Game()
        {
            InitializeComponent();

            switch (Menu.nation)
            {
                case 1:
                    income = 7;
                    break;

                case 2:
                    income = 12;
                    break;

                case 3:
                    income = 12;
                    break;

                case 4:
                    income = 9;
                    break;

                case 5:
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

        }

        private void Set_up()
        {
            Unit i = new Unit("infantry", nation, );
        }

        private void Income()
        {
            
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.map, 0, 0, 500, 300);

            switch (nation)
            {
                case 1:
                    e.Graphics.DrawImage(Properties.Resources.soviet, 25, 350, 50, 50);
                    break;
                case 2:
                    e.Graphics.DrawImage(Properties.Resources.Nazi, 25, 350, 50, 50);
                    break;
                case 3:
                    e.Graphics.DrawImage(Properties.Resources.UK_raf, 25, 350, 50, 50);
                    break;
                case 4:
                    e.Graphics.DrawImage(Properties.Resources.japan_sun, 25, 350, 50, 50);
                    break;
                case 5:
                    e.Graphics.DrawImage(Properties.Resources.usa_star, 25, 350, 50, 50);
                    break;
                default:
                    break;
            }
        }
    }
}
