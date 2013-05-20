using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Orange.GameData.Materials;

namespace Orange.GameProcessing.Entities
{
    public class Mob : MovableCharacter
    {
        public Mob(Vector2 gridPos, string texture):
            base(gridPos,texture)
        {
            moveSpeed = 1;
            gridPosition = gridPos;
            mapPosition = gridPosition * 42;
            newMapPosition = mapPosition;
            state = 0;
            animation = new Animation(texture, gridPos * 42, (int)gridPos.Y, 5,7);
            animation.delay = 50;
            animation.newAnimation(9, 14);
            animation.switchAnimation(1, 9);
            animation.original.X = animation.Width / 2;
            animation.original.Y = 65;
        }

        public override void moveUP()
        {
            if (moving) return;
            base.moveUP();
            //if (faceDirection != 8)
            animation.newAnimation(21, 26);
            Z = (int)gridPosition.Y + 2;
        }

        public override void moveDOWN()
        {
            if (moving) return;
            base.moveDOWN();
            //if (faceDirection != 2)
            animation.newAnimation(27, 32);
            Z = (int)gridPosition.Y + 2;
        }

        public override void moveLEFT()
        {
            if (moving) return;
            base.moveLEFT();
            //if (faceDirection != 4)
            animation.newAnimation(9, 14);
        }

        public override void moveRIGHT()
        {
            if (moving) return;
            base.moveRIGHT();
            //if (faceDirection != 6)
            animation.newAnimation(18, 22);
        }

        public override void Update()
        {
            base.Update();
            if (state == 1 && animation.isStop)
            {
                Dispose();
            }
            bool lastMoving = moving;
            UpdatePixelMove();
            if (lastMoving && !moving)
                animation.newAnimation(animation.frStart - 1, animation.frStart - 1);
            UpdateAutoMove();
           
        }
        public void Kill()
        {
            state = 1;
            animation.isLoop = false;
            animation.newAnimation(1, 9);
        }
        private void UpdateAutoMove()
        {
            if (OrangeInput.trigger(Keys.C))
                Console.WriteLine(gridPosition.ToString());
            if (!moving)
            {
                Random r = new Random();
                int i = r.Next(4);
                if (i == 0)
                {
                    Console.WriteLine("Up");
                    moveUP();
                }
                else if (i == 1)
                {
                    Console.WriteLine("Down");
                    moveDOWN();
                }
                else if (i == 2)
                {
                    Console.WriteLine("Left");
                    moveLEFT();
                }
                else
                {
                    Console.WriteLine("Right");
                    moveRIGHT();
                }
            }
        }
    }
}
