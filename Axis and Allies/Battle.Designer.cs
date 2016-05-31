namespace Axis_and_Allies
{
    partial class Battle
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
            this.attackButton = new System.Windows.Forms.Button();
            this.retreatButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // attackButton
            // 
            this.attackButton.Location = new System.Drawing.Point(121, 427);
            this.attackButton.Name = "attackButton";
            this.attackButton.Size = new System.Drawing.Size(75, 23);
            this.attackButton.TabIndex = 0;
            this.attackButton.Text = "Attack";
            this.attackButton.UseVisualStyleBackColor = true;
            this.attackButton.Click += new System.EventHandler(this.attackButton_Click);
            // 
            // retreatButton
            // 
            this.retreatButton.Location = new System.Drawing.Point(293, 427);
            this.retreatButton.Name = "retreatButton";
            this.retreatButton.Size = new System.Drawing.Size(75, 23);
            this.retreatButton.TabIndex = 1;
            this.retreatButton.Text = "Retreat";
            this.retreatButton.UseVisualStyleBackColor = true;
            this.retreatButton.Click += new System.EventHandler(this.retreatButton_Click);
            // 
            // Battle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.retreatButton);
            this.Controls.Add(this.attackButton);
            this.Name = "Battle";
            this.Size = new System.Drawing.Size(500, 500);
            this.Load += new System.EventHandler(this.Battle_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button attackButton;
        private System.Windows.Forms.Button retreatButton;
    }
}
