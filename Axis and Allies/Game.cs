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
        public Game()
        {
            InitializeComponent();
        }
        
        private void Game_Load(object sender, EventArgs e)
        {
            this.Focus();   
        }
    }
}
