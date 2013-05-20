using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Orange.GameData.Materials;
using Microsoft.Xna.Framework.Input;


namespace Orange.GameProcessing.Entities
{
    // TODO: implement Kill() method (done!)
    public class Boomer : MovableCharacter
    {
        public bool attemptPutBoom;
        public Boomer(Vector2 gridPos, string texture)
        {
            moveSpeed = 3;
            gridPosition = gridPos;
            mapPosition = gridPosition * 42;
            newMapPosition = mapPosition;
            state = 0;
            animation = new Animation(texture, gridPos * 42, (int)gridPos.Y, 8,9);
            animation.delay = 50;
            animation.newAnimation(10, 10);
            animation.switchAnimation(0, 12);
            animation.original.X = animation.Width / 2;
            animation.original.Y = 105;
        }
        public override void moveUP()
        {
            if (moving) return; 
            base.moveUP();
            //if (faceDirection != 8)
                animation.newAnimation(23, 27);
            Z = (int)gridPosition.Y + 2;
        }

        public override void moveDOWN()
        {
            if (moving) return; 
            base.moveDOWN();
            //if (faceDirection != 2)
                animation.newAnimation(28, 32);
            Z = (int)gridPosition.Y+2;
        }

        public override void moveLEFT()
        {
            if (moving) return;
            base.moveLEFT();
            //if (faceDirection != 4)
                animation.newAnimation(13, 17);
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
            UpdateInput();
            bool lastMoving = moving;
            UpdatePixelMove();
            if(lastMoving && !moving)
                animation.newAnimation(animation.frStart - 1, animation.frStart - 1);
        }
        public void Kill()
        {
            state = 1;
            animation.isLoop = false;
            animation.newAnimation(68, 78);
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
                attemptPutBoom = true;
            }
        }
    }
}
