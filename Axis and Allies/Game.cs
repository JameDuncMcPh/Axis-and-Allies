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
        int nation, income;

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

            Income();
        }

        private void Income()
        {
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.World_War_II_Revised, 0, 0, 500, 300);

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
