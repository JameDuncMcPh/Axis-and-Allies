namespace Axis_and_Allies
{
    partial class Game
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
            this.phaseLabel = new System.Windows.Forms.Label();
            this.germanyButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.provinceLabel = new System.Windows.Forms.Label();
            this.garrisonLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // phaseLabel
            // 
            this.phaseLabel.AutoSize = true;
            this.phaseLabel.Location = new System.Drawing.Point(25, 325);
            this.phaseLabel.Name = "phaseLabel";
            this.phaseLabel.Size = new System.Drawing.Size(35, 13);
            this.phaseLabel.TabIndex = 0;
            this.phaseLabel.Text = "label1";
            // 
            // germanyButton
            // 
            this.germanyButton.FlatAppearance.BorderSize = 0;
            this.germanyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.germanyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.germanyButton.ForeColor = System.Drawing.Color.Transparent;
            this.germanyButton.Location = new System.Drawing.Point(180, 110);
            this.germanyButton.Name = "germanyButton";
            this.germanyButton.Size = new System.Drawing.Size(75, 75);
            this.germanyButton.TabIndex = 1;
            this.germanyButton.UseVisualStyleBackColor = true;
            this.germanyButton.Click += new System.EventHandler(this.germanyButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(66, 315);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // provinceLabel
            // 
            this.provinceLabel.AutoSize = true;
            this.provinceLabel.Location = new System.Drawing.Point(177, 325);
            this.provinceLabel.Name = "provinceLabel";
            this.provinceLabel.Size = new System.Drawing.Size(0, 13);
            this.provinceLabel.TabIndex = 3;
            // 
            // garrisonLabel
            // 
            this.garrisonLabel.AutoSize = true;
            this.garrisonLabel.Location = new System.Drawing.Point(177, 352);
            this.garrisonLabel.Name = "garrisonLabel";
            this.garrisonLabel.Size = new System.Drawing.Size(0, 13);
            this.garrisonLabel.TabIndex = 4;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.garrisonLabel);
            this.Controls.Add(this.provinceLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.germanyButton);
            this.Controls.Add(this.phaseLabel);
            this.Name = "Game";
            this.Size = new System.Drawing.Size(500, 500);
            this.Load += new System.EventHandler(this.Game_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Game_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label phaseLabel;
        private System.Windows.Forms.Button germanyButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label provinceLabel;
        private System.Windows.Forms.Label garrisonLabel;
    }
}
