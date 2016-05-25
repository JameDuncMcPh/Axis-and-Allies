﻿namespace Axis_and_Allies
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
            this.westernEuropeButton = new System.Windows.Forms.Button();
            this.garrisonBox = new System.Windows.Forms.ListBox();
            this.garrisonBox2 = new System.Windows.Forms.ListBox();
            this.movingButton = new System.Windows.Forms.Button();
            this.movingButton2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.provinceLabel.Location = new System.Drawing.Point(351, 321);
            this.provinceLabel.Name = "provinceLabel";
            this.provinceLabel.Size = new System.Drawing.Size(0, 13);
            this.provinceLabel.TabIndex = 3;
            // 
            // westernEuropeButton
            // 
            this.westernEuropeButton.BackColor = System.Drawing.Color.Transparent;
            this.westernEuropeButton.FlatAppearance.BorderSize = 0;
            this.westernEuropeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.westernEuropeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.westernEuropeButton.ForeColor = System.Drawing.Color.Transparent;
            this.westernEuropeButton.Location = new System.Drawing.Point(121, 122);
            this.westernEuropeButton.Name = "westernEuropeButton";
            this.westernEuropeButton.Size = new System.Drawing.Size(53, 82);
            this.westernEuropeButton.TabIndex = 5;
            this.westernEuropeButton.UseVisualStyleBackColor = false;
            this.westernEuropeButton.Click += new System.EventHandler(this.westernEuropeButton_Click);
            // 
            // garrisonBox
            // 
            this.garrisonBox.FormattingEnabled = true;
            this.garrisonBox.Location = new System.Drawing.Point(354, 345);
            this.garrisonBox.Name = "garrisonBox";
            this.garrisonBox.Size = new System.Drawing.Size(45, 95);
            this.garrisonBox.TabIndex = 6;
            // 
            // garrisonBox2
            // 
            this.garrisonBox2.FormattingEnabled = true;
            this.garrisonBox2.Location = new System.Drawing.Point(424, 345);
            this.garrisonBox2.Name = "garrisonBox2";
            this.garrisonBox2.Size = new System.Drawing.Size(45, 95);
            this.garrisonBox2.TabIndex = 7;
            // 
            // movingButton
            // 
            this.movingButton.Location = new System.Drawing.Point(400, 365);
            this.movingButton.Name = "movingButton";
            this.movingButton.Size = new System.Drawing.Size(23, 23);
            this.movingButton.TabIndex = 8;
            this.movingButton.Text = ">";
            this.movingButton.UseVisualStyleBackColor = true;
            this.movingButton.Click += new System.EventHandler(this.movingButton_Click);
            // 
            // movingButton2
            // 
            this.movingButton2.Location = new System.Drawing.Point(400, 394);
            this.movingButton2.Name = "movingButton2";
            this.movingButton2.Size = new System.Drawing.Size(23, 23);
            this.movingButton2.TabIndex = 9;
            this.movingButton2.Text = "<";
            this.movingButton2.UseVisualStyleBackColor = true;
            this.movingButton2.Click += new System.EventHandler(this.movingButton2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(424, 322);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(45, 20);
            this.textBox1.TabIndex = 10;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.movingButton2);
            this.Controls.Add(this.movingButton);
            this.Controls.Add(this.garrisonBox2);
            this.Controls.Add(this.garrisonBox);
            this.Controls.Add(this.westernEuropeButton);
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
        private System.Windows.Forms.Button westernEuropeButton;
        private System.Windows.Forms.ListBox garrisonBox;
        private System.Windows.Forms.ListBox garrisonBox2;
        private System.Windows.Forms.Button movingButton;
        private System.Windows.Forms.Button movingButton2;
        private System.Windows.Forms.TextBox textBox1;
    }
}
