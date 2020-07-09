namespace SpaceFlight.Screen
{
    partial class InfoScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoScreen));
            this.lblRocketName = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.gbxStatus = new System.Windows.Forms.GroupBox();
            this.lblStatFuelWeightVal = new System.Windows.Forms.Label();
            this.lblStatWeightVal = new System.Windows.Forms.Label();
            this.lblStatGravityVal = new System.Windows.Forms.Label();
            this.lblStatDragVal = new System.Windows.Forms.Label();
            this.lblStatSpeedVal = new System.Windows.Forms.Label();
            this.lblStatAccelerationVal = new System.Windows.Forms.Label();
            this.lblStatThrustVal = new System.Windows.Forms.Label();
            this.lblStatFuelWeight = new System.Windows.Forms.Label();
            this.lblStatWeight = new System.Windows.Forms.Label();
            this.lblStatGravity = new System.Windows.Forms.Label();
            this.lblStatDrag = new System.Windows.Forms.Label();
            this.lblStatSpeed = new System.Windows.Forms.Label();
            this.lblStatAcceleration = new System.Windows.Forms.Label();
            this.lblStatThrust = new System.Windows.Forms.Label();
            this.gbxInformation = new System.Windows.Forms.GroupBox();
            this.lblInfHeightVal = new System.Windows.Forms.Label();
            this.lblInfManufacturerVal = new System.Windows.Forms.Label();
            this.lblInfModelVal = new System.Windows.Forms.Label();
            this.lblInfHeight = new System.Windows.Forms.Label();
            this.lblInfManufacturer = new System.Windows.Forms.Label();
            this.lblInfModel = new System.Windows.Forms.Label();
            this.gbxLocation = new System.Windows.Forms.GroupBox();
            this.lblLocCoordsVal = new System.Windows.Forms.Label();
            this.lblLocAngleVal = new System.Windows.Forms.Label();
            this.lblLocClosestVal = new System.Windows.Forms.Label();
            this.lblLocCoords = new System.Windows.Forms.Label();
            this.lblLocAngle = new System.Windows.Forms.Label();
            this.lblLocClosest = new System.Windows.Forms.Label();
            this.sldCtrlAngle = new System.Windows.Forms.TrackBar();
            this.lblCtrlAngle = new System.Windows.Forms.Label();
            this.sldCtrlThrust = new System.Windows.Forms.TrackBar();
            this.lblCtrlThrust = new System.Windows.Forms.Label();
            this.lblDebugFps = new System.Windows.Forms.Label();
            this.lblSldAngleVal = new System.Windows.Forms.Label();
            this.lblSldThrustVal = new System.Windows.Forms.Label();
            this.cbxSelectRocket = new System.Windows.Forms.ComboBox();
            this.pnlForcesScreen = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSetPlaybackSpeed = new System.Windows.Forms.Button();
            this.gbxStatus.SuspendLayout();
            this.gbxInformation.SuspendLayout();
            this.gbxLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sldCtrlAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sldCtrlThrust)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRocketName
            // 
            this.lblRocketName.AutoSize = true;
            this.lblRocketName.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRocketName.Location = new System.Drawing.Point(96, 50);
            this.lblRocketName.Name = "lblRocketName";
            this.lblRocketName.Size = new System.Drawing.Size(119, 26);
            this.lblRocketName.TabIndex = 0;
            this.lblRocketName.Text = "Rocketname";
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock.Location = new System.Drawing.Point(300, 50);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(102, 26);
            this.lblClock.TabIndex = 1;
            this.lblClock.Text = "T+ 01:12:12";
            // 
            // gbxStatus
            // 
            this.gbxStatus.Controls.Add(this.lblStatFuelWeightVal);
            this.gbxStatus.Controls.Add(this.lblStatWeightVal);
            this.gbxStatus.Controls.Add(this.lblStatGravityVal);
            this.gbxStatus.Controls.Add(this.lblStatDragVal);
            this.gbxStatus.Controls.Add(this.lblStatSpeedVal);
            this.gbxStatus.Controls.Add(this.lblStatAccelerationVal);
            this.gbxStatus.Controls.Add(this.lblStatThrustVal);
            this.gbxStatus.Controls.Add(this.lblStatFuelWeight);
            this.gbxStatus.Controls.Add(this.lblStatWeight);
            this.gbxStatus.Controls.Add(this.lblStatGravity);
            this.gbxStatus.Controls.Add(this.lblStatDrag);
            this.gbxStatus.Controls.Add(this.lblStatSpeed);
            this.gbxStatus.Controls.Add(this.lblStatAcceleration);
            this.gbxStatus.Controls.Add(this.lblStatThrust);
            this.gbxStatus.Location = new System.Drawing.Point(248, 79);
            this.gbxStatus.Name = "gbxStatus";
            this.gbxStatus.Size = new System.Drawing.Size(200, 213);
            this.gbxStatus.TabIndex = 2;
            this.gbxStatus.TabStop = false;
            this.gbxStatus.Text = "Status";
            // 
            // lblStatFuelWeightVal
            // 
            this.lblStatFuelWeightVal.AutoSize = true;
            this.lblStatFuelWeightVal.Location = new System.Drawing.Point(84, 171);
            this.lblStatFuelWeightVal.Name = "lblStatFuelWeightVal";
            this.lblStatFuelWeightVal.Size = new System.Drawing.Size(87, 13);
            this.lblStatFuelWeightVal.TabIndex = 13;
            this.lblStatFuelWeightVal.Text = "Fuel weight in kg";
            // 
            // lblStatWeightVal
            // 
            this.lblStatWeightVal.AutoSize = true;
            this.lblStatWeightVal.Location = new System.Drawing.Point(84, 146);
            this.lblStatWeightVal.Name = "lblStatWeightVal";
            this.lblStatWeightVal.Size = new System.Drawing.Size(67, 13);
            this.lblStatWeightVal.TabIndex = 12;
            this.lblStatWeightVal.Text = "Weight in kg";
            // 
            // lblStatGravityVal
            // 
            this.lblStatGravityVal.AutoSize = true;
            this.lblStatGravityVal.Location = new System.Drawing.Point(85, 122);
            this.lblStatGravityVal.Name = "lblStatGravityVal";
            this.lblStatGravityVal.Size = new System.Drawing.Size(68, 13);
            this.lblStatGravityVal.TabIndex = 11;
            this.lblStatGravityVal.Text = "Gravity in kN";
            // 
            // lblStatDragVal
            // 
            this.lblStatDragVal.AutoSize = true;
            this.lblStatDragVal.Location = new System.Drawing.Point(84, 98);
            this.lblStatDragVal.Name = "lblStatDragVal";
            this.lblStatDragVal.Size = new System.Drawing.Size(55, 13);
            this.lblStatDragVal.TabIndex = 10;
            this.lblStatDragVal.Text = "Dragin kN";
            // 
            // lblStatSpeedVal
            // 
            this.lblStatSpeedVal.AutoSize = true;
            this.lblStatSpeedVal.Location = new System.Drawing.Point(84, 74);
            this.lblStatSpeedVal.Name = "lblStatSpeedVal";
            this.lblStatSpeedVal.Size = new System.Drawing.Size(70, 13);
            this.lblStatSpeedVal.TabIndex = 9;
            this.lblStatSpeedVal.Text = "Speed in m/s";
            // 
            // lblStatAccelerationVal
            // 
            this.lblStatAccelerationVal.AutoSize = true;
            this.lblStatAccelerationVal.Location = new System.Drawing.Point(83, 50);
            this.lblStatAccelerationVal.Name = "lblStatAccelerationVal";
            this.lblStatAccelerationVal.Size = new System.Drawing.Size(110, 13);
            this.lblStatAccelerationVal.TabIndex = 8;
            this.lblStatAccelerationVal.Text = "Acceleration in m/s^2";
            // 
            // lblStatThrustVal
            // 
            this.lblStatThrustVal.AutoSize = true;
            this.lblStatThrustVal.Location = new System.Drawing.Point(82, 26);
            this.lblStatThrustVal.Name = "lblStatThrustVal";
            this.lblStatThrustVal.Size = new System.Drawing.Size(65, 13);
            this.lblStatThrustVal.TabIndex = 7;
            this.lblStatThrustVal.Text = "Thrust in kN";
            // 
            // lblStatFuelWeight
            // 
            this.lblStatFuelWeight.AutoSize = true;
            this.lblStatFuelWeight.Location = new System.Drawing.Point(45, 171);
            this.lblStatFuelWeight.Name = "lblStatFuelWeight";
            this.lblStatFuelWeight.Size = new System.Drawing.Size(30, 13);
            this.lblStatFuelWeight.TabIndex = 6;
            this.lblStatFuelWeight.Text = "Fuel:";
            // 
            // lblStatWeight
            // 
            this.lblStatWeight.AutoSize = true;
            this.lblStatWeight.Location = new System.Drawing.Point(32, 145);
            this.lblStatWeight.Name = "lblStatWeight";
            this.lblStatWeight.Size = new System.Drawing.Size(44, 13);
            this.lblStatWeight.TabIndex = 5;
            this.lblStatWeight.Text = "Weight:";
            // 
            // lblStatGravity
            // 
            this.lblStatGravity.AutoSize = true;
            this.lblStatGravity.Location = new System.Drawing.Point(32, 121);
            this.lblStatGravity.Name = "lblStatGravity";
            this.lblStatGravity.Size = new System.Drawing.Size(43, 13);
            this.lblStatGravity.TabIndex = 4;
            this.lblStatGravity.Text = "Gravity:";
            // 
            // lblStatDrag
            // 
            this.lblStatDrag.AutoSize = true;
            this.lblStatDrag.Location = new System.Drawing.Point(42, 97);
            this.lblStatDrag.Name = "lblStatDrag";
            this.lblStatDrag.Size = new System.Drawing.Size(33, 13);
            this.lblStatDrag.TabIndex = 3;
            this.lblStatDrag.Text = "Drag:";
            // 
            // lblStatSpeed
            // 
            this.lblStatSpeed.AutoSize = true;
            this.lblStatSpeed.Location = new System.Drawing.Point(36, 73);
            this.lblStatSpeed.Name = "lblStatSpeed";
            this.lblStatSpeed.Size = new System.Drawing.Size(41, 13);
            this.lblStatSpeed.TabIndex = 2;
            this.lblStatSpeed.Text = "Speed:";
            // 
            // lblStatAcceleration
            // 
            this.lblStatAcceleration.AutoSize = true;
            this.lblStatAcceleration.Location = new System.Drawing.Point(7, 49);
            this.lblStatAcceleration.Name = "lblStatAcceleration";
            this.lblStatAcceleration.Size = new System.Drawing.Size(69, 13);
            this.lblStatAcceleration.TabIndex = 1;
            this.lblStatAcceleration.Text = "Acceleration:";
            // 
            // lblStatThrust
            // 
            this.lblStatThrust.AutoSize = true;
            this.lblStatThrust.Location = new System.Drawing.Point(36, 26);
            this.lblStatThrust.Name = "lblStatThrust";
            this.lblStatThrust.Size = new System.Drawing.Size(40, 13);
            this.lblStatThrust.TabIndex = 0;
            this.lblStatThrust.Text = "Thrust:";
            // 
            // gbxInformation
            // 
            this.gbxInformation.Controls.Add(this.lblInfHeightVal);
            this.gbxInformation.Controls.Add(this.lblInfManufacturerVal);
            this.gbxInformation.Controls.Add(this.lblInfModelVal);
            this.gbxInformation.Controls.Add(this.lblInfHeight);
            this.gbxInformation.Controls.Add(this.lblInfManufacturer);
            this.gbxInformation.Controls.Add(this.lblInfModel);
            this.gbxInformation.Location = new System.Drawing.Point(42, 79);
            this.gbxInformation.Name = "gbxInformation";
            this.gbxInformation.Size = new System.Drawing.Size(200, 103);
            this.gbxInformation.TabIndex = 3;
            this.gbxInformation.TabStop = false;
            this.gbxInformation.Text = "Information";
            // 
            // lblInfHeightVal
            // 
            this.lblInfHeightVal.AutoSize = true;
            this.lblInfHeightVal.Location = new System.Drawing.Point(85, 73);
            this.lblInfHeightVal.Name = "lblInfHeightVal";
            this.lblInfHeightVal.Size = new System.Drawing.Size(78, 13);
            this.lblInfHeightVal.TabIndex = 9;
            this.lblInfHeightVal.Text = "Height in meter";
            // 
            // lblInfManufacturerVal
            // 
            this.lblInfManufacturerVal.AutoSize = true;
            this.lblInfManufacturerVal.Location = new System.Drawing.Point(85, 49);
            this.lblInfManufacturerVal.Name = "lblInfManufacturerVal";
            this.lblInfManufacturerVal.Size = new System.Drawing.Size(70, 13);
            this.lblInfManufacturerVal.TabIndex = 8;
            this.lblInfManufacturerVal.Text = "Manufacturer";
            // 
            // lblInfModelVal
            // 
            this.lblInfModelVal.AutoSize = true;
            this.lblInfModelVal.Location = new System.Drawing.Point(85, 26);
            this.lblInfModelVal.Name = "lblInfModelVal";
            this.lblInfModelVal.Size = new System.Drawing.Size(62, 13);
            this.lblInfModelVal.TabIndex = 7;
            this.lblInfModelVal.Text = "Modelname";
            // 
            // lblInfHeight
            // 
            this.lblInfHeight.AutoSize = true;
            this.lblInfHeight.Location = new System.Drawing.Point(40, 73);
            this.lblInfHeight.Name = "lblInfHeight";
            this.lblInfHeight.Size = new System.Drawing.Size(41, 13);
            this.lblInfHeight.TabIndex = 6;
            this.lblInfHeight.Text = "Height:";
            // 
            // lblInfManufacturer
            // 
            this.lblInfManufacturer.AutoSize = true;
            this.lblInfManufacturer.Location = new System.Drawing.Point(6, 49);
            this.lblInfManufacturer.Name = "lblInfManufacturer";
            this.lblInfManufacturer.Size = new System.Drawing.Size(73, 13);
            this.lblInfManufacturer.TabIndex = 5;
            this.lblInfManufacturer.Text = "Manufacturer:";
            // 
            // lblInfModel
            // 
            this.lblInfModel.AutoSize = true;
            this.lblInfModel.Location = new System.Drawing.Point(40, 26);
            this.lblInfModel.Name = "lblInfModel";
            this.lblInfModel.Size = new System.Drawing.Size(39, 13);
            this.lblInfModel.TabIndex = 4;
            this.lblInfModel.Text = "Model:";
            // 
            // gbxLocation
            // 
            this.gbxLocation.Controls.Add(this.lblLocCoordsVal);
            this.gbxLocation.Controls.Add(this.lblLocAngleVal);
            this.gbxLocation.Controls.Add(this.lblLocClosestVal);
            this.gbxLocation.Controls.Add(this.lblLocCoords);
            this.gbxLocation.Controls.Add(this.lblLocAngle);
            this.gbxLocation.Controls.Add(this.lblLocClosest);
            this.gbxLocation.Location = new System.Drawing.Point(42, 189);
            this.gbxLocation.Name = "gbxLocation";
            this.gbxLocation.Size = new System.Drawing.Size(200, 103);
            this.gbxLocation.TabIndex = 4;
            this.gbxLocation.TabStop = false;
            this.gbxLocation.Text = "Location";
            // 
            // lblLocCoordsVal
            // 
            this.lblLocCoordsVal.AutoSize = true;
            this.lblLocCoordsVal.Location = new System.Drawing.Point(85, 74);
            this.lblLocCoordsVal.Name = "lblLocCoordsVal";
            this.lblLocCoordsVal.Size = new System.Drawing.Size(25, 13);
            this.lblLocCoordsVal.TabIndex = 5;
            this.lblLocCoordsVal.Text = "x | y";
            // 
            // lblLocAngleVal
            // 
            this.lblLocAngleVal.AutoSize = true;
            this.lblLocAngleVal.Location = new System.Drawing.Point(85, 50);
            this.lblLocAngleVal.Name = "lblLocAngleVal";
            this.lblLocAngleVal.Size = new System.Drawing.Size(88, 13);
            this.lblLocAngleVal.TabIndex = 4;
            this.lblLocAngleVal.Text = "Angle in Degrees";
            // 
            // lblLocClosestVal
            // 
            this.lblLocClosestVal.AutoSize = true;
            this.lblLocClosestVal.Location = new System.Drawing.Point(85, 26);
            this.lblLocClosestVal.Name = "lblLocClosestVal";
            this.lblLocClosestVal.Size = new System.Drawing.Size(64, 13);
            this.lblLocClosestVal.TabIndex = 3;
            this.lblLocClosestVal.Text = "Altitude in m";
            // 
            // lblLocCoords
            // 
            this.lblLocCoords.AutoSize = true;
            this.lblLocCoords.Location = new System.Drawing.Point(13, 74);
            this.lblLocCoords.Name = "lblLocCoords";
            this.lblLocCoords.Size = new System.Drawing.Size(66, 13);
            this.lblLocCoords.TabIndex = 2;
            this.lblLocCoords.Text = "Coordinates:";
            // 
            // lblLocAngle
            // 
            this.lblLocAngle.AutoSize = true;
            this.lblLocAngle.Location = new System.Drawing.Point(42, 50);
            this.lblLocAngle.Name = "lblLocAngle";
            this.lblLocAngle.Size = new System.Drawing.Size(37, 13);
            this.lblLocAngle.TabIndex = 1;
            this.lblLocAngle.Text = "Angle:";
            // 
            // lblLocClosest
            // 
            this.lblLocClosest.AutoSize = true;
            this.lblLocClosest.Location = new System.Drawing.Point(2, 26);
            this.lblLocClosest.Name = "lblLocClosest";
            this.lblLocClosest.Size = new System.Drawing.Size(77, 13);
            this.lblLocClosest.TabIndex = 0;
            this.lblLocClosest.Text = "Closest Planet:";
            // 
            // sldCtrlAngle
            // 
            this.sldCtrlAngle.Location = new System.Drawing.Point(248, 416);
            this.sldCtrlAngle.Maximum = 180;
            this.sldCtrlAngle.Minimum = -179;
            this.sldCtrlAngle.Name = "sldCtrlAngle";
            this.sldCtrlAngle.Size = new System.Drawing.Size(200, 45);
            this.sldCtrlAngle.TabIndex = 5;
            // 
            // lblCtrlAngle
            // 
            this.lblCtrlAngle.AutoSize = true;
            this.lblCtrlAngle.Location = new System.Drawing.Point(324, 400);
            this.lblCtrlAngle.Name = "lblCtrlAngle";
            this.lblCtrlAngle.Size = new System.Drawing.Size(34, 13);
            this.lblCtrlAngle.TabIndex = 7;
            this.lblCtrlAngle.Text = "Angle";
            // 
            // sldCtrlThrust
            // 
            this.sldCtrlThrust.Location = new System.Drawing.Point(248, 354);
            this.sldCtrlThrust.Maximum = 100;
            this.sldCtrlThrust.Name = "sldCtrlThrust";
            this.sldCtrlThrust.Size = new System.Drawing.Size(200, 45);
            this.sldCtrlThrust.SmallChange = 2;
            this.sldCtrlThrust.TabIndex = 8;
            this.sldCtrlThrust.Value = 100;
            // 
            // lblCtrlThrust
            // 
            this.lblCtrlThrust.AutoSize = true;
            this.lblCtrlThrust.Location = new System.Drawing.Point(338, 338);
            this.lblCtrlThrust.Name = "lblCtrlThrust";
            this.lblCtrlThrust.Size = new System.Drawing.Size(37, 13);
            this.lblCtrlThrust.TabIndex = 9;
            this.lblCtrlThrust.Text = "Thrust";
            // 
            // lblDebugFps
            // 
            this.lblDebugFps.AutoSize = true;
            this.lblDebugFps.Location = new System.Drawing.Point(470, 501);
            this.lblDebugFps.Name = "lblDebugFps";
            this.lblDebugFps.Size = new System.Drawing.Size(21, 13);
            this.lblDebugFps.TabIndex = 14;
            this.lblDebugFps.Text = "fps";
            // 
            // lblSldAngleVal
            // 
            this.lblSldAngleVal.AutoSize = true;
            this.lblSldAngleVal.Location = new System.Drawing.Point(360, 400);
            this.lblSldAngleVal.Name = "lblSldAngleVal";
            this.lblSldAngleVal.Size = new System.Drawing.Size(17, 13);
            this.lblSldAngleVal.TabIndex = 15;
            this.lblSldAngleVal.Text = "0°";
            // 
            // lblSldThrustVal
            // 
            this.lblSldThrustVal.AutoSize = true;
            this.lblSldThrustVal.Location = new System.Drawing.Point(381, 338);
            this.lblSldThrustVal.Name = "lblSldThrustVal";
            this.lblSldThrustVal.Size = new System.Drawing.Size(33, 13);
            this.lblSldThrustVal.TabIndex = 16;
            this.lblSldThrustVal.Text = "100%";
            // 
            // cbxSelectRocket
            // 
            this.cbxSelectRocket.FormattingEnabled = true;
            this.cbxSelectRocket.Location = new System.Drawing.Point(118, 12);
            this.cbxSelectRocket.Name = "cbxSelectRocket";
            this.cbxSelectRocket.Size = new System.Drawing.Size(190, 21);
            this.cbxSelectRocket.TabIndex = 17;
            // 
            // pnlForcesScreen
            // 
            this.pnlForcesScreen.Location = new System.Drawing.Point(47, 298);
            this.pnlForcesScreen.Name = "pnlForcesScreen";
            this.pnlForcesScreen.Size = new System.Drawing.Size(195, 195);
            this.pnlForcesScreen.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(115, 496);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Forcedial";
            // 
            // btnSetPlaybackSpeed
            // 
            this.btnSetPlaybackSpeed.Location = new System.Drawing.Point(320, 12);
            this.btnSetPlaybackSpeed.Name = "btnSetPlaybackSpeed";
            this.btnSetPlaybackSpeed.Size = new System.Drawing.Size(75, 23);
            this.btnSetPlaybackSpeed.TabIndex = 19;
            this.btnSetPlaybackSpeed.Text = "1X";
            this.btnSetPlaybackSpeed.UseVisualStyleBackColor = true;
            this.btnSetPlaybackSpeed.Click += new System.EventHandler(this.btnSetPlaybackSpeed_Click);
            // 
            // InfoScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 523);
            this.Controls.Add(this.btnSetPlaybackSpeed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlForcesScreen);
            this.Controls.Add(this.cbxSelectRocket);
            this.Controls.Add(this.lblSldThrustVal);
            this.Controls.Add(this.lblSldAngleVal);
            this.Controls.Add(this.lblDebugFps);
            this.Controls.Add(this.lblCtrlThrust);
            this.Controls.Add(this.sldCtrlThrust);
            this.Controls.Add(this.lblCtrlAngle);
            this.Controls.Add(this.sldCtrlAngle);
            this.Controls.Add(this.gbxLocation);
            this.Controls.Add(this.gbxInformation);
            this.Controls.Add(this.gbxStatus);
            this.Controls.Add(this.lblClock);
            this.Controls.Add(this.lblRocketName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoScreen";
            this.Text = "InfoScreen";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InfoScreen_FormClosing);
            this.gbxStatus.ResumeLayout(false);
            this.gbxStatus.PerformLayout();
            this.gbxInformation.ResumeLayout(false);
            this.gbxInformation.PerformLayout();
            this.gbxLocation.ResumeLayout(false);
            this.gbxLocation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sldCtrlAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sldCtrlThrust)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRocketName;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.GroupBox gbxStatus;
        private System.Windows.Forms.GroupBox gbxInformation;
        private System.Windows.Forms.Label lblInfManufacturer;
        private System.Windows.Forms.Label lblInfModel;
        private System.Windows.Forms.Label lblInfHeight;
        private System.Windows.Forms.Label lblStatFuelWeight;
        private System.Windows.Forms.Label lblStatWeight;
        private System.Windows.Forms.Label lblStatGravity;
        private System.Windows.Forms.Label lblStatDrag;
        private System.Windows.Forms.Label lblStatSpeed;
        private System.Windows.Forms.Label lblStatAcceleration;
        private System.Windows.Forms.Label lblStatThrust;
        private System.Windows.Forms.GroupBox gbxLocation;
        private System.Windows.Forms.Label lblLocCoords;
        private System.Windows.Forms.Label lblLocAngle;
        private System.Windows.Forms.Label lblLocClosest;
        private System.Windows.Forms.TrackBar sldCtrlAngle;
        private System.Windows.Forms.Label lblCtrlAngle;
        private System.Windows.Forms.TrackBar sldCtrlThrust;
        private System.Windows.Forms.Label lblCtrlThrust;
        private System.Windows.Forms.Label lblInfHeightVal;
        private System.Windows.Forms.Label lblInfManufacturerVal;
        private System.Windows.Forms.Label lblInfModelVal;
        private System.Windows.Forms.Label lblStatFuelWeightVal;
        private System.Windows.Forms.Label lblStatWeightVal;
        private System.Windows.Forms.Label lblStatGravityVal;
        private System.Windows.Forms.Label lblStatDragVal;
        private System.Windows.Forms.Label lblStatSpeedVal;
        private System.Windows.Forms.Label lblStatAccelerationVal;
        private System.Windows.Forms.Label lblStatThrustVal;
        private System.Windows.Forms.Label lblLocCoordsVal;
        private System.Windows.Forms.Label lblLocAngleVal;
        private System.Windows.Forms.Label lblLocClosestVal;
        private System.Windows.Forms.Label lblDebugFps;
        private System.Windows.Forms.Label lblSldAngleVal;
        private System.Windows.Forms.Label lblSldThrustVal;
        private System.Windows.Forms.ComboBox cbxSelectRocket;
        private System.Windows.Forms.Panel pnlForcesScreen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSetPlaybackSpeed;
    }
}