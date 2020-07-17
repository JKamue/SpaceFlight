using System;
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
            var center = _panel.Height / 2;

            foreach (var dragForce in Drag)
                DrawForce(g, dragForce, Color.Red, factor, center);

            foreach (var gravityForce in Gravity)
                DrawForce(g, gravityForce, Color.Blue, factor, center);

            DrawForce(g, Thrust, Color.Green, factor, center);
            DrawForce(g, ResultingForce, Color.Black, factor, center);
            g.DrawEllipse(new Pen(Color.Black, 1), new Rectangle(1,1, _panel.Height - 2, _panel.Height - 2));
            DrawSpeed(g, Speed, Color.OrangeRed, center);

            _graphicsBuffer.Render(_panelGraphics);
        }

        private void DrawSpeed(Graphics g, Speed speed, Color c, decimal center)
        {
            var aCalc = new AngularCalculator((float)Speed.Angle.Degree, new PointM(center, center));
            var points = new List<PointM>
            {
                aCalc.Turn(new PointM(center - 1, 0)),
                aCalc.Turn(new PointM(center - 1, 15)),
                aCalc.Turn(new PointM(center + 1, 15)),
                aCalc.Turn(new PointM(center + 1, 0))
            };

            var b = new SolidBrush(c);
            var array = points.ToArray();
            g.FillPolygon(b, array);
        }

        private void DrawForce(Graphics g, Force force, Color c, decimal factor, decimal center)
        {
            var aCalc = new AngularCalculator(force.Angle.Degree, new PointM(center, center));
            var height = Math.Round(center - force.Value / factor);

            if (force.Value / factor < 15)
                return;

            var points = new List<PointM>
            {
                aCalc.Turn(new PointM(center-5, height+15)),
                aCalc.Turn(new PointM(center-1, height+15)),
                aCalc.Turn(new PointM(center-1, center)),
                aCalc.Turn(new PointM(center+1, center)),
                aCalc.Turn(new PointM(center+1, height+15)),
                aCalc.Turn(new PointM(center+5, height+15)),
                aCalc.Turn(new PointM(center, height+1)),
            };

            var b = new SolidBrush(c);
            var array = points.ToArray();
            g.FillPolygon(b, array);
        }

        private decimal CalcForceScalingFactor()
        {
            var forces = new List<Force>{Thrust, ResultingForce};
            var allForces = forces.Concat(Drag).Concat(Gravity);
            var biggest = -1m;

            foreach (var force in allForces)
                biggest = force.Value > biggest ? force.Value : biggest;

            return biggest / ((decimal) (_panel.Height - 2) / 2);
        }
    }
}
