﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpaceFlight.Physics;
using SpaceFlight.Physics.Units;
using SpaceFlight.Screen.Calculator;

namespace SpaceFlight.Screen.Controllers
{
    class ForceDrawer : BufferedScreen
    {

        public List<Force> Drag;
        public Force Thrust;
        public List<Force> Gravity;
        public Force ResultingForce;
        public Speed Speed;
        public Angle TargetAngle;
        public Angle CurrentAngle;

        public ForceDrawer(Panel panel) : base(panel)
        {
            _drawTimer.Enabled = false;
            // Setup forces
            Thrust = new Force(Angle.Zero, 0);
            Gravity = Drag = new List<Force>();
        }

        public void Redraw()
        {
            _graphicsBuffer.Graphics.Clear(Color.FromArgb(240, 240, 240));
            var g = _graphicsBuffer.Graphics;
            var factor = CalcForceScalingFactor();
            var center = (float ) _panel.Height / 2;

            foreach (var dragForce in Drag)
                DrawForce(g, dragForce, Color.Red, factor, center);

            foreach (var gravityForce in Gravity)
                DrawForce(g, gravityForce, Color.Blue, factor, center);

            DrawForce(g, Thrust, Color.Green, factor, center);
            DrawForce(g, ResultingForce, Color.Black, factor, center);
            g.DrawEllipse(new Pen(Color.Black, 1), new Rectangle(1,1, _panel.Height - 2, _panel.Height - 2));

            DrawAngle(g, Speed.Angle, Color.OrangeRed, center);
            DrawAngle(g, TargetAngle, Color.Chocolate, center);
            DrawAngle(g, CurrentAngle, Color.Black, center);

            _graphicsBuffer.Render(_panelGraphics);
        }

        private void DrawAngle(Graphics g, Angle angle, Color c, float center)
        {
            var aCalc = new AngularCalculator((float)angle.Degree, new PointF(center, center));
            var points = new List<PointF>
            {
                aCalc.Turn(new PointF(center - 1, 0)),
                aCalc.Turn(new PointF(center - 1, 15)),
                aCalc.Turn(new PointF(center + 1, 15)),
                aCalc.Turn(new PointF(center + 1, 0))
            };

            var b = new SolidBrush(c);
            var array = points.ToArray();
            g.FillPolygon(b, array);
        }

        private void DrawForce(Graphics g, Force force, Color c, float factor, float center)
        {
            var aCalc = new AngularCalculator((float) force.Angle.Degree, new PointF(center, center));
            var height = (float) Math.Round(center - (float) force.Value / factor);

            if (force.Value / factor < 15)
                return;

            var points = new List<PointF>
            {
                aCalc.Turn(new PointF(center-5, height+15)),
                aCalc.Turn(new PointF(center-1, height+15)),
                aCalc.Turn(new PointF(center-1, center)),
                aCalc.Turn(new PointF(center+1, center)),
                aCalc.Turn(new PointF(center+1, height+15)),
                aCalc.Turn(new PointF(center+5, height+15)),
                aCalc.Turn(new PointF(center, height+1)),
            };

            var b = new SolidBrush(c);
            var array = points.ToArray();
            g.FillPolygon(b, array);
        }

        private float CalcForceScalingFactor()
        {
            var forces = new List<Force>{Thrust, ResultingForce};
            var allForces = forces.Concat(Drag).Concat(Gravity);
            double biggest = -1;

            foreach (var force in allForces)
                biggest = force.Value > biggest ? force.Value : biggest;

            return (float) (biggest / (((float)_panel.Height -2) / 2));
        }
    }
}
