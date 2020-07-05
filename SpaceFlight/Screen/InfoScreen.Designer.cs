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
            this.lblRocketName = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.gbxStatus = new System.Windows.Forms.GroupBox();
            this.gbxInformation = new System.Windows.Forms.GroupBox();
            this.lblInfModel = new System.Windows.Forms.Label();
            this.lblInfManufacturer = new System.Windows.Forms.Label();
            this.lblInfHeight = new System.Windows.Forms.Label();
            this.lblStatThrust = new System.Windows.Forms.Label();
            this.lblStatAcceleration = new System.Windows.Forms.Label();
            this.lblStatSpeed = new System.Windows.Forms.Label();
            this.gbxLocation = new System.Windows.Forms.GroupBox();
            this.lblLocClosest = new System.Windows.Forms.Label();
            this.lblLocAngle = new System.Windows.Forms.Label();
            this.lblLocCoords = new System.Windows.Forms.Label();
            this.lblStatDrag = new System.Windows.Forms.Label();
            this.lblStatGravity = new System.Windows.Forms.Label();
            this.lblStatWeight = new System.Windows.Forms.Label();
            this.lblStatFuelWeight = new System.Windows.Forms.Label();
            this.sldCtrlAngle = new System.Windows.Forms.TrackBar();
            this.lblCtrlAngle = new System.Windows.Forms.Label();
            this.sldCtrlThrust = new System.Windows.Forms.TrackBar();
            this.lblCtrlThrust = new System.Windows.Forms.Label();
            this.lblInfModelVal = new System.Windows.Forms.Label();
            this.lblInfManufacturerVal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStatThrustVal = new System.Windows.Forms.Label();
            this.lblStatAccelerationVal = new System.Windows.Forms.Label();
            this.lblSpeedVal = new System.Windows.Forms.Label();
            this.lblStatDragVal = new System.Windows.Forms.Label();
            this.lblStatGravityVal = new System.Windows.Forms.Label();
            this.lblStatWeightVal = new System.Windows.Forms.Label();
            this.lblStatFuelWeightVal = new System.Windows.Forms.Label();
            this.lblLocClosestVal = new System.Windows.Forms.Label();
            this.lblLocAngleVal = new System.Windows.Forms.Label();
            this.lblLocCoordsVal = new System.Windows.Forms.Label();
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
            this.lblRocketName.Location = new System.Drawing.Point(109, 19);
            this.lblRocketName.Name = "lblRocketName";
            this.lblRocketName.Size = new System.Drawing.Size(68, 13);
            this.lblRocketName.TabIndex = 0;
            this.lblRocketName.Text = "Rocketname";
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.Location = new System.Drawing.Point(319, 19);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(65, 13);
            this.lblClock.TabIndex = 1;
            this.lblClock.Text = "T+ 01:12:12";
            // 
            // gbxStatus
            // 
            this.gbxStatus.Controls.Add(this.lblStatFuelWeightVal);
            this.gbxStatus.Controls.Add(this.lblStatWeightVal);
            this.gbxStatus.Controls.Add(this.lblStatGravityVal);
            this.gbxStatus.Controls.Add(this.lblStatDragVal);
            this.gbxStatus.Controls.Add(this.lblSpeedVal);
            this.gbxStatus.Controls.Add(this.lblStatAccelerationVal);
            this.gbxStatus.Controls.Add(this.lblStatThrustVal);
            this.gbxStatus.Controls.Add(this.lblStatFuelWeight);
            this.gbxStatus.Controls.Add(this.lblStatWeight);
            this.gbxStatus.Controls.Add(this.lblStatGravity);
            this.gbxStatus.Controls.Add(this.lblStatDrag);
            this.gbxStatus.Controls.Add(this.lblStatSpeed);
            this.gbxStatus.Controls.Add(this.lblStatAcceleration);
            this.gbxStatus.Controls.Add(this.lblStatThrust);
            this.gbxStatus.Location = new System.Drawing.Point(250, 45);
            this.gbxStatus.Name = "gbxStatus";
            this.gbxStatus.Size = new System.Drawing.Size(200, 213);
            this.gbxStatus.TabIndex = 2;
            this.gbxStatus.TabStop = false;
            this.gbxStatus.Text = "Status";
            // 
            // gbxInformation
            // 
            this.gbxInformation.Controls.Add(this.label4);
            this.gbxInformation.Controls.Add(this.lblInfManufacturerVal);
            this.gbxInformation.Controls.Add(this.lblInfModelVal);
            this.gbxInformation.Controls.Add(this.lblInfHeight);
            this.gbxInformation.Controls.Add(this.lblInfManufacturer);
            this.gbxInformation.Controls.Add(this.lblInfModel);
            this.gbxInformation.Location = new System.Drawing.Point(44, 45);
            this.gbxInformation.Name = "gbxInformation";
            this.gbxInformation.Size = new System.Drawing.Size(200, 103);
            this.gbxInformation.TabIndex = 3;
            this.gbxInformation.TabStop = false;
            this.gbxInformation.Text = "Information";
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
            // lblInfManufacturer
            // 
            this.lblInfManufacturer.AutoSize = true;
            this.lblInfManufacturer.Location = new System.Drawing.Point(6, 49);
            this.lblInfManufacturer.Name = "lblInfManufacturer";
            this.lblInfManufacturer.Size = new System.Drawing.Size(73, 13);
            this.lblInfManufacturer.TabIndex = 5;
            this.lblInfManufacturer.Text = "Manufacturer:";
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
            // lblStatThrust
            // 
            this.lblStatThrust.AutoSize = true;
            this.lblStatThrust.Location = new System.Drawing.Point(36, 26);
            this.lblStatThrust.Name = "lblStatThrust";
            this.lblStatThrust.Size = new System.Drawing.Size(40, 13);
            this.lblStatThrust.TabIndex = 0;
            this.lblStatThrust.Text = "Thrust:";
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
            // lblStatSpeed
            // 
            this.lblStatSpeed.AutoSize = true;
            this.lblStatSpeed.Location = new System.Drawing.Point(36, 73);
            this.lblStatSpeed.Name = "lblStatSpeed";
            this.lblStatSpeed.Size = new System.Drawing.Size(41, 13);
            this.lblStatSpeed.TabIndex = 2;
            this.lblStatSpeed.Text = "Speed:";
            // 
            // gbxLocation
            // 
            this.gbxLocation.Controls.Add(this.lblLocCoordsVal);
            this.gbxLocation.Controls.Add(this.lblLocAngleVal);
            this.gbxLocation.Controls.Add(this.lblLocClosestVal);
            this.gbxLocation.Controls.Add(this.lblLocCoords);
            this.gbxLocation.Controls.Add(this.lblLocAngle);
            this.gbxLocation.Controls.Add(this.lblLocClosest);
            this.gbxLocation.Location = new System.Drawing.Point(44, 155);
            this.gbxLocation.Name = "gbxLocation";
            this.gbxLocation.Size = new System.Drawing.Size(200, 103);
            this.gbxLocation.TabIndex = 4;
            this.gbxLocation.TabStop = false;
            this.gbxLocation.Text = "Location";
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
            // lblLocAngle
            // 
            this.lblLocAngle.AutoSize = true;
            this.lblLocAngle.Location = new System.Drawing.Point(42, 50);
            this.lblLocAngle.Name = "lblLocAngle";
            this.lblLocAngle.Size = new System.Drawing.Size(37, 13);
            this.lblLocAngle.TabIndex = 1;
            this.lblLocAngle.Text = "Angle:";
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
            // lblStatDrag
            // 
            this.lblStatDrag.AutoSize = true;
            this.lblStatDrag.Location = new System.Drawing.Point(42, 97);
            this.lblStatDrag.Name = "lblStatDrag";
            this.lblStatDrag.Size = new System.Drawing.Size(33, 13);
            this.lblStatDrag.TabIndex = 3;
            this.lblStatDrag.Text = "Drag:";
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
            // lblStatWeight
            // 
            this.lblStatWeight.AutoSize = true;
            this.lblStatWeight.Location = new System.Drawing.Point(32, 145);
            this.lblStatWeight.Name = "lblStatWeight";
            this.lblStatWeight.Size = new System.Drawing.Size(44, 13);
            this.lblStatWeight.TabIndex = 5;
            this.lblStatWeight.Text = "Weight:";
            // 
            // lblStatFuelWeight
            // 
            this.lblStatFuelWeight.AutoSize = true;
            this.lblStatFuelWeight.Location = new System.Drawing.Point(11, 170);
            this.lblStatFuelWeight.Name = "lblStatFuelWeight";
            this.lblStatFuelWeight.Size = new System.Drawing.Size(64, 13);
            this.lblStatFuelWeight.TabIndex = 6;
            this.lblStatFuelWeight.Text = "Fuel weight:";
            // 
            // sldCtrlAngle
            // 
            this.sldCtrlAngle.Location = new System.Drawing.Point(44, 286);
            this.sldCtrlAngle.Maximum = 12;
            this.sldCtrlAngle.Minimum = -12;
            this.sldCtrlAngle.Name = "sldCtrlAngle";
            this.sldCtrlAngle.Size = new System.Drawing.Size(200, 45);
            this.sldCtrlAngle.TabIndex = 5;
            // 
            // lblCtrlAngle
            // 
            this.lblCtrlAngle.AutoSize = true;
            this.lblCtrlAngle.Location = new System.Drawing.Point(120, 270);
            this.lblCtrlAngle.Name = "lblCtrlAngle";
            this.lblCtrlAngle.Size = new System.Drawing.Size(34, 13);
            this.lblCtrlAngle.TabIndex = 7;
            this.lblCtrlAngle.Text = "Angle";
            // 
            // sldCtrlThrust
            // 
            this.sldCtrlThrust.Location = new System.Drawing.Point(250, 286);
            this.sldCtrlThrust.Name = "sldCtrlThrust";
            this.sldCtrlThrust.Size = new System.Drawing.Size(200, 45);
            this.sldCtrlThrust.TabIndex = 8;
            // 
            // lblCtrlThrust
            // 
            this.lblCtrlThrust.AutoSize = true;
            this.lblCtrlThrust.Location = new System.Drawing.Point(340, 270);
            this.lblCtrlThrust.Name = "lblCtrlThrust";
            this.lblCtrlThrust.Size = new System.Drawing.Size(37, 13);
            this.lblCtrlThrust.TabIndex = 9;
            this.lblCtrlThrust.Text = "Thrust";
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
            // lblInfManufacturerVal
            // 
            this.lblInfManufacturerVal.AutoSize = true;
            this.lblInfManufacturerVal.Location = new System.Drawing.Point(85, 49);
            this.lblInfManufacturerVal.Name = "lblInfManufacturerVal";
            this.lblInfManufacturerVal.Size = new System.Drawing.Size(70, 13);
            this.lblInfManufacturerVal.TabIndex = 8;
            this.lblInfManufacturerVal.Text = "Manufacturer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Height in meter";
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
            // lblStatAccelerationVal
            // 
            this.lblStatAccelerationVal.AutoSize = true;
            this.lblStatAccelerationVal.Location = new System.Drawing.Point(83, 50);
            this.lblStatAccelerationVal.Name = "lblStatAccelerationVal";
            this.lblStatAccelerationVal.Size = new System.Drawing.Size(110, 13);
            this.lblStatAccelerationVal.TabIndex = 8;
            this.lblStatAccelerationVal.Text = "Acceleration in m/s^2";
            // 
            // lblSpeedVal
            // 
            this.lblSpeedVal.AutoSize = true;
            this.lblSpeedVal.Location = new System.Drawing.Point(84, 74);
            this.lblSpeedVal.Name = "lblSpeedVal";
            this.lblSpeedVal.Size = new System.Drawing.Size(70, 13);
            this.lblSpeedVal.TabIndex = 9;
            this.lblSpeedVal.Text = "Speed in m/s";
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
            // lblStatGravityVal
            // 
            this.lblStatGravityVal.AutoSize = true;
            this.lblStatGravityVal.Location = new System.Drawing.Point(85, 122);
            this.lblStatGravityVal.Name = "lblStatGravityVal";
            this.lblStatGravityVal.Size = new System.Drawing.Size(68, 13);
            this.lblStatGravityVal.TabIndex = 11;
            this.lblStatGravityVal.Text = "Gravity in kN";
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
            // lblStatFuelWeightVal
            // 
            this.lblStatFuelWeightVal.AutoSize = true;
            this.lblStatFuelWeightVal.Location = new System.Drawing.Point(84, 171);
            this.lblStatFuelWeightVal.Name = "lblStatFuelWeightVal";
            this.lblStatFuelWeightVal.Size = new System.Drawing.Size(87, 13);
            this.lblStatFuelWeightVal.TabIndex = 13;
            this.lblStatFuelWeightVal.Text = "Fuel weight in kg";
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
            // lblLocAngleVal
            // 
            this.lblLocAngleVal.AutoSize = true;
            this.lblLocAngleVal.Location = new System.Drawing.Point(85, 50);
            this.lblLocAngleVal.Name = "lblLocAngleVal";
            this.lblLocAngleVal.Size = new System.Drawing.Size(88, 13);
            this.lblLocAngleVal.TabIndex = 4;
            this.lblLocAngleVal.Text = "Angle in Degrees";
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
            // InfoScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 338);
            this.Controls.Add(this.lblCtrlThrust);
            this.Controls.Add(this.sldCtrlThrust);
            this.Controls.Add(this.lblCtrlAngle);
            this.Controls.Add(this.sldCtrlAngle);
            this.Controls.Add(this.gbxLocation);
            this.Controls.Add(this.gbxInformation);
            this.Controls.Add(this.gbxStatus);
            this.Controls.Add(this.lblClock);
            this.Controls.Add(this.lblRocketName);
            this.Name = "InfoScreen";
            this.Text = "InfoScreen";
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblInfManufacturerVal;
        private System.Windows.Forms.Label lblInfModelVal;
        private System.Windows.Forms.Label lblStatFuelWeightVal;
        private System.Windows.Forms.Label lblStatWeightVal;
        private System.Windows.Forms.Label lblStatGravityVal;
        private System.Windows.Forms.Label lblStatDragVal;
        private System.Windows.Forms.Label lblSpeedVal;
        private System.Windows.Forms.Label lblStatAccelerationVal;
        private System.Windows.Forms.Label lblStatThrustVal;
        private System.Windows.Forms.Label lblLocCoordsVal;
        private System.Windows.Forms.Label lblLocAngleVal;
        private System.Windows.Forms.Label lblLocClosestVal;
    }
}