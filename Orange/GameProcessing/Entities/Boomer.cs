using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Orange.GameData.Materials;
using Microsoft.Xna.Framework.Input;


namespace Orange.GameProcessing.Entities
{
    public class Boomer : MovableCharacter
    {
        public bool attemptPutBoom;
        public int boomLength;
        public int boomStackMax;
        public int boomStackCount;
        public Boomer(Vector2 gridPos, string texture)
        {
            {
                moveSpeed = 3;
                gridPosition = gridPos;
                mapPosition = gridPosition * 42;
                newMapPosition = mapPosition;
                state = 0;
                animation = new Animation(texture, mapPosition, (int)gridPosition.Y, 8, 9);
                animation.delay = 50;
                animation.PlayAnimation(10, 10);
                animation.SwitchAnimation(0, 12);
                animation.original.X = animation.Width / 2;
                animation.original.Y = 105;
            }
            {
                boomLength = 1;
                boomStackMax = 1;
                boomStackCount = 0;
            }
        }
        public override void moveUP()
        {
            if (moving) return; 
            base.moveUP();
            //if (faceDirection != 8)
                animation.PlayAnimation(23, 27);
            Z = (int)gridPosition.Y + 2;
        }

        public override void moveDOWN()
        {
            if (moving) return; 
            base.moveDOWN();
            //if (faceDirection != 2)
                animation.PlayAnimation(28, 32);
            Z = (int)gridPosition.Y+2;
        }

        public override void moveLEFT()
        {
            if (moving) return;
            base.moveLEFT();
            //if (faceDirection != 4)
                animation.PlayAnimation(13, 17);
        }

        public override void moveRIGHT()
        {
            if (moving) return; 
            base.moveRIGHT();
            //if (faceDirection != 6)
                animation.PlayAnimation(18, 22);
        }

        public override void Update()
        {
            base.Update();
            if (IsDead() && animation.isStop)
            {
                Dispose();
            }
            else if(!IsDead())
            {
                UpdateInput();
                bool lastMoving = moving;
                UpdatePixelMove();
                if (lastMoving && !moving)
                    animation.PlayAnimation(animation.frameStart - 1, animation.frameStart - 1);
            }
        }
        public override void Kill()
        {
            if (IsDead()) return;
            base.Kill();
            animation.isLoop = false;
            animation.PlayAnimation(68, 78);
        }
        private void UpdateInput()
        {
            if (OrangeInput.press(Keys.Up))
                moveUP();
            if (OrangeInput.press(Keys.Down))
                moveDOWN();
            if (OrangeInput.press(Keys.Left))
                moveLEFT();
            if (OrangeInput.press(Keys.Right))
                moveRIGHT();
            if (OrangeInput.trigger(Keys.Space))
            {
                if (boomStackCount < boomStackMax)
                {
                    attemptPutBoom = true;
                }
            }
        }
    }
}
