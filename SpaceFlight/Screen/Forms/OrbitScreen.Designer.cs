namespace SpaceFlight.Screen.Forms
{
    partial class OrbitScreen
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrbitScreen));
            this.pnlOrbitScreen = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlOrbitScreen
            // 
            this.pnlOrbitScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrbitScreen.Location = new System.Drawing.Point(0, 0);
            this.pnlOrbitScreen.Name = "pnlOrbitScreen";
            this.pnlOrbitScreen.Size = new System.Drawing.Size(503, 440);
            this.pnlOrbitScreen.TabIndex = 0;
            // 
            // OrbitScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 440);
            this.Controls.Add(this.pnlOrbitScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrbitScreen";
            this.Text = "OrbitScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrbitScreen_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOrbitScreen;
    }
}