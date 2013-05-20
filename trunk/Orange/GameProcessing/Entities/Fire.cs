using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Orange.GameData.Materials;

namespace Orange.GameProcessing.Entities
{
    public class Fire: Character
    {
        public bool Killed;
        public bool Disposed;
        public Fire()
        {
            animation = new Animation("Boom/WaterTraceBody", mapPosition, 2, 2,4);
            animation.newAnimation(0, 1);
        }
        public Fire(Vector2 pos, string name, int direction)
        {
            gridPosition = pos;
            mapPosition = gridPosition * 42;
            animation = new Animation(name, new Vector2(mapPosition.X+67,mapPosition.Y+98), 2, 2,4);
            animation.original = new Vector2(21, 21);
            if (direction == 2)
            {
                animation.angle = (float)Math.PI * 3 / 2;
            }
            else if (direction == 4)
            {
                animation.angle = (float)Math.PI;
            }
            else if (direction == 8)
            {
                animation.angle = (float)Math.PI / 2;
            }
            else if (direction == 6)
            {
                animation.angle = 0;
            }
            animation.delay = 60;
            animation.isLoop = false;
            animation.newAnimation(0, 1);
        }
        public override void Update()
        {
            base.Update();
            if (Disposed) return;
            if (animation.isStop && !Killed)
            {
                Kill();
            }
            else if (animation.isStop)
            {
                Disposed = true;
                Dispose();
            }
        }
        public void Kill()
        {
            Killed = true;
            animation.newAnimation(2, 7);
        }
    }
}
