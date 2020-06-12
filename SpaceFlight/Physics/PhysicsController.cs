using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceFlight.Physics
{
    class PhysicsController
    {
        private List<PhysicsObject> movingObjects;
        private List<PhysicsObject> gravityObjects;

        private Timer physTimer;

        public PhysicsController(int msPerTick)
        {
            physTimer = new Timer();
            physTimer.Interval = msPerTick;
            physTimer.Tick += Tick;
            physTimer.Start();

            movingObjects = new List<PhysicsObject>();
            gravityObjects = new List<PhysicsObject>();
        }

        public void AddMovingObject(PhysicsObject ob) => movingObjects.Add(ob);

        public void AddGravityObject(PhysicsObject ob) => gravityObjects.Add(ob);

        public void Tick(object s, EventArgs e)
        {
            foreach (var movingObject in movingObjects)
            {
                movingObject.Tick();
            }
        }
    }
}
