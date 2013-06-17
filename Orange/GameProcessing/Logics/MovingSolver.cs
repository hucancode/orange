using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Orange.GameProcessing.Entities;

namespace Orange.GameProcessing.Logics
{
    public class MovingSolver
    {
        public Map map;
        public void Solve()
        {
            foreach (MovableCharacter item in map.mobs)
            {
                SolveSingleCharacter(item);
            }
            foreach (MovableCharacter item in map.boomers)
            {
                SolveSingleCharacter(item);
            }
        }
        private bool Available(int x, int y)
        {
            return !(map.brickMap[x, y] || map.boomMap[x, y]);
        }
        private void SolveSingleCharacter(MovableCharacter item)
        {
            int x = (int)item.GridPosition.X;
            int y = (int)item.GridPosition.Y;
            if (item.attemptMoveUP)
            {
                if (y != 0 && Available(x, y - 1))
                {
                    item.doMoveUP();
                }
                item.attemptMoveUP = false;
            }
            else if (item.attemptMoveDOWN)
            {
                if (y != map.brickMap.GetLength(1) - 1 && Available(x, y + 1))
                {
                    item.doMoveDOWN(); 
                }
                item.attemptMoveDOWN = false;
            }
            else if (item.attemptMoveLEFT)
            {
                if (x != 0 && Available(x - 1, y))
                {
                    item.doMoveLEFT(); 
                }
                item.attemptMoveLEFT = false;
            }
            else if (item.attemptMoveRIGHT)
            {
                if (x != map.brickMap.GetLength(0) - 1 && Available(x + 1, y))
                {
                    item.doMoveRIGHT();
                }
                item.attemptMoveRIGHT = false;
            }
        }
    }
}
