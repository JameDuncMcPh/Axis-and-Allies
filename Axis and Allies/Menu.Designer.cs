namespace Axis_and_Allies
{
    partial class Menu
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.gameButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.editionLabel = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.playLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(164, 110);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(145, 23);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "AXIS AND ALLIES";
            // 
            // gameButton
            // 
            this.gameButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameButton.Location = new System.Drawing.Point(189, 162);
            this.gameButton.Name = "gameButton";
            this.gameButton.Size = new System.Drawing.Size(75, 23);
            this.gameButton.TabIndex = 1;
            this.gameButton.Text = "New Game";
            this.gameButton.UseVisualStyleBackColor = true;
            this.gameButton.Click += new System.EventHandler(this.buttonePress);
            // 
            // LoadButton
            // 
            this.LoadButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadButton.Location = new System.Drawing.Point(189, 220);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 2;
            this.LoadButton.Text = "Load Game";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.buttonePress);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(189, 278);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(75, 23);
            this.quitButton.TabIndex = 3;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.buttonePress);
            // 
            // editionLabel
            // 
            this.editionLabel.AutoSize = true;
            this.editionLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editionLabel.Location = new System.Drawing.Point(170, 133);
            this.editionLabel.Name = "editionLabel";
            this.editionLabel.Size = new System.Drawing.Size(135, 18);
            this.editionLabel.TabIndex = 5;
            this.editionLabel.Text = "Operation Barbarosa";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(189, 249);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "How to Play";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.buttonePress);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(189, 191);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "New Game";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonePress);
            // 
            // playLabel
            // 
            this.playLabel.AutoSize = true;
            this.playLabel.Location = new System.Drawing.Point(59, 57);
            this.playLabel.Name = "playLabel";
            this.playLabel.Size = new System.Drawing.Size(0, 13);
            this.playLabel.TabIndex = 8;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.playLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.editionLabel);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.gameButton);
            this.Controls.Add(this.titleLabel);
            this.Name = "Menu";
            this.Size = new System.Drawing.Size(500, 500);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button gameButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label editionLabel;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label playLabel;
    }
}
