using System.Windows.Forms;

namespace SpaceFlight
{
    partial class SimulationScreen
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.SimulationPanel = new System.Windows.Forms.Panel();
            this.lblDebug = new System.Windows.Forms.Label();
            this.lblDebugDistance = new System.Windows.Forms.Label();
            this.SimulationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SimulationPanel
            // 
            this.SimulationPanel.Controls.Add(this.lblDebugDistance);
            this.SimulationPanel.Controls.Add(this.lblDebug);
            this.SimulationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SimulationPanel.Location = new System.Drawing.Point(0, 0);
            this.SimulationPanel.Name = "SimulationPanel";
            this.SimulationPanel.Size = new System.Drawing.Size(984, 961);
            this.SimulationPanel.TabIndex = 0;
            // 
            // lblDebug
            // 
            this.lblDebug.AutoSize = true;
            this.lblDebug.Location = new System.Drawing.Point(781, 939);
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(48, 13);
            this.lblDebug.TabIndex = 0;
            this.lblDebug.Text = "devInfos";
            // 
            // lblDebugDistance
            // 
            this.lblDebugDistance.AutoSize = true;
            this.lblDebugDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebugDistance.Location = new System.Drawing.Point(12, 880);
            this.lblDebugDistance.Name = "lblDebugDistance";
            this.lblDebugDistance.Size = new System.Drawing.Size(289, 39);
            this.lblDebugDistance.TabIndex = 1;
            this.lblDebugDistance.Text = "lblDebugDistance";
            // 
            // SimulationScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 961);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Controls.Add(this.SimulationPanel);
            this.DoubleBuffered = true;
            this.Icon = global::SpaceFlight.Properties.Resources.Rocket_symbol;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SimulationScreen";
            this.Text = "SpaceFlight";
            this.TopMost = true;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SimulationScreen_KeyPress);
            this.SimulationPanel.ResumeLayout(false);
            this.SimulationPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel SimulationPanel;
        private Button button1;
        private Label lblDebug;
        private Label lblDebugDistance;
    }
}

