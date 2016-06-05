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
    public partial class Menu : UserControl
    {
        bool newGame = false;

        public static string nation;

        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            this.Focus();
            button2.Visible = false;
            button4.Visible = false;

        }

        private void buttonePress(object sender, EventArgs e)
        {

            if (newGame == true)
            {
                if (sender.Equals(gameButton))
                {
                    nation = "USSR";
                    // f is the form that this control is on - ("this" is the current User Control)
                    Form f = this.FindForm();
                    f.Controls.Remove(this);

                    //if there is a wrong press then game over
                    Game g = new Game();
                    f.Controls.Add(g);

                    
                }
                else if (sender.Equals(button2))
                {
                    nation = "Germany";
                    // f is the form that this control is on - ("this" is the current User Control)
                    Form f = this.FindForm();
                    f.Controls.Remove(this);

                    //if there is a wrong press then game over
                    Game g = new Game();
                    f.Controls.Add(g);

                    
                }
                
            }

            if (sender.Equals(gameButton) && newGame == false)
            {
                button2.Visible = true;
                //button4.Visible = true;
                LoadButton.Visible = false;
                quitButton.Visible = false;

                gameButton.Text = "U.S.S.R.";
                button2.Text = "Germany";
                LoadButton.Text = "";
                button4.Text = "";
                quitButton.Text = "";

                newGame = true;
            }
            else if (sender.Equals(LoadButton) && newGame == false)
            {
            }
            else if (sender.Equals(quitButton) && newGame == false)
            {
                Application.Exit();
            }

            
        }
    }
}

