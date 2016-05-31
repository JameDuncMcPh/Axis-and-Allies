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
        int attakHits, defenseHits;
         

        public Battle()
        {
            InitializeComponent();
            attakHits = 0;
            defenseHits = 0;    
        }

        private void Battle_Load(object sender, EventArgs e)
        {
            
        }

        private void attackButton_Click(object sender, EventArgs e)
        {
            foreach (Unit u in Game.world[Game.counter].garrison)
            {
                if (u.owner != Game.world[Game.counter].name)
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
            for (int i = 0; i < attakHits; i ++)
            {
                foreach (Unit u in Game.world[Game.counter].garrison)
                {
                    if (u.owner == Game.world[Game.counter].name)
                    {
                        Game.world[Game.counter]
                    }
                }
            }
        }

        private void retreatButton_Click(object sender, EventArgs e)
        {

        }
    }
}
