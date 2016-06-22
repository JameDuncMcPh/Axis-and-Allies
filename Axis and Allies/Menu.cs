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
        /// <summary>
        ///  Created by Duncan McPherson
        /// Jun 7 2016
        /// A board game of operation babrossa
        /// </summary>
        
        //variables
        bool newGame = false;
        bool instrutions = false;

        public static string load;
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
                //chosing what country to play and startning game
                if (sender.Equals(gameButton))
                {
                    load = "map";
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
                    load = "map";
                    nation = "Germany";
                    // f is the form that this control is on - ("this" is the current User Control)
                    Form f = this.FindForm();
                    f.Controls.Remove(this);

                    //if there is a wrong press then game over
                    Game g = new Game();
                    f.Controls.Add(g);                  
                }               
            }
            //choosing to play a new game
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
            //loading the old game
            else if (sender.Equals(LoadButton) && newGame == false)
            {
                load = "savegame";
                // f is the form that this control is on - ("this" is the current User Control)
                Form f = this.FindForm();
                f.Controls.Remove(this);

                //if there is a wrong press then game over
                Game g = new Game();
                f.Controls.Add(g);
            }
            //showing hoe to play
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
                                    + "and winning a battle aganist the oppsing forces. " + "\n" + "\n"
                                    + "Once your enter the game thier will be two boxes" + "\n"
                                    + ", the first one shows the units of the province of which you just" + "\n"
                                    + "clicked on while the second one is the one which" + "\n"
                                    + "you have chosen to move your troops too. To move" + "\n"
                                    + "the troops just clicked the arrow button in that direction" + "\n";
            }
            //quiting
            else if (sender.Equals(quitButton) && newGame == false)
            {
                Application.Exit();
            }
            //backing out of information
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

