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
        bool instrutions = false;

        public static string nation;

        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            this.Focus();
            button2.Visible = false;
            //button4.Visible = false;

        }

        private void buttonePress(object sender, EventArgs e)
        {

            if (newGame == true)
            {
                if (sender.Equals(gameButton))
                {
                    button4.Visible = false;
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
                button4.Visible = false;
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
            else if (sender.Equals(button4) && newGame == false)
            {
                titleLabel.Visible = false;
                editionLabel.Visible = false;
                gameButton.Visible = false;
                LoadButton.Visible = false;
                button4.Visible = false;
                instrutions = true;

                quitButton.Text = "Back";
                playLabel.Text = "Axis and Allies is a stragtic board where one tries " + "\n"
                                    + "to conqour the oppents captial, which in this case " + "\n"
                                    + "are the provinces of Germany for the USSR and Russia " + "\n"
                                    + "for Germany respectively, by moving units into a area " + "\n"
                                    + "and winning a battle aganist the oppsing forces. " + "\n";
            }
            else if (sender.Equals(quitButton) && newGame == false)
            {
                Application.Exit();
            }
            else if (sender.Equals(quitButton) && instrutions == true)
            {
                titleLabel.Visible = true;
                editionLabel.Visible = true;
                gameButton.Visible = true;
                LoadButton.Visible = true;
                button4.Visible = true;
                instrutions = false;

                quitButton.Text = "Quit";
                playLabel.Text = "";
            }


        }
    }
}

