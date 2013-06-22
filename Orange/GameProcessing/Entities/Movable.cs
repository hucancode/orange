using Microsoft.Xna.Framework;
using Orange.GameData.Materials;
using System;
using Orange.GameProcessing.Logics;

namespace Orange.GameProcessing.Entities
{
    public class MovableCharacter: Character
    {
        public float moveSpeed;
        protected int direction;
        protected Vector2 newMapPosition;
        public bool moving;
        public bool attemptMoveUP;
        public bool attemptMoveDOWN;
        public bool attemptMoveLEFT;
        public bool attemptMoveRIGHT;
        public MovableCharacter()
            :base()
        {
            moveSpeed = 8;
            attemptMoveUP = false;
            attemptMoveDOWN = false;
            attemptMoveLEFT = false;
            attemptMoveRIGHT = false;
        }
        public MovableCharacter(Vector2 gridPos)
            : base(gridPos)
        {
            moveSpeed = 8;
            attemptMoveUP = false;
            attemptMoveDOWN = false;
            attemptMoveLEFT = false;
            attemptMoveRIGHT = false;
        }
        public virtual void moveUP()
        {
            if (moving) return;
            attemptMoveUP = true;
        }
        public virtual void doMoveUP()
        {
            moving = true;
            newMapPosition.Y -= 42;
            direction = 0;
        }
        public virtual void moveDOWN()
        {
            if (moving) return;
            attemptMoveDOWN = true;
        }
        public virtual void doMoveDOWN()
        {
            moving = true;
            newMapPosition.Y += 42;
            direction = 2;
        }
        public virtual void moveLEFT()
        {
            if (moving) return;
            attemptMoveLEFT = true;
        }
        public virtual void doMoveLEFT()
        {
            moving = true;
            newMapPosition.X -= 42;
            direction = 3;
        }
        public virtual void moveRIGHT()
        {
            if (moving) return;
            attemptMoveRIGHT = true;
        }
        public virtual void doMoveRIGHT()
        {
            moving = true;
            newMapPosition.X += 42;
            direction = 1;
        }
        protected void UpdatePixelMove()
        {
            if (newMapPosition != mapPosition)
            {
                if (newMapPosition.X != mapPosition.X)
                {
                    if (Math.Abs(newMapPosition.X - mapPosition.X) <= moveSpeed)
                    {
                        mapPosition.X = newMapPosition.X;
                        gridPosition.X = mapPosition.X / 42;
                    }
                    else if (newMapPosition.X > mapPosition.X)
                        mapPosition.X += moveSpeed;
                    else
                        mapPosition.X -= moveSpeed;
                }
                else
                {
                    if (Math.Abs(newMapPosition.Y - mapPosition.Y) <= moveSpeed)
                    {
                        mapPosition.Y = newMapPosition.Y;
                        gridPosition.Y = mapPosition.Y / 42;
                    }
                    else if (newMapPosition.Y > mapPosition.Y)
                        mapPosition.Y += moveSpeed;
                    else
                        mapPosition.Y -= moveSpeed;
                }
            }
            else
            {
                if (moving) moving = false;
            }
        }
    }
}
