using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Orange.GameProcessing.Entities;

namespace Orange.GameProcessing.Logics
{
    public class MovingSolver
    {
        public bool[,] moveMap;
        public void Solve(List<Mob> characters)
        {
            foreach (MovableCharacter item in characters)
            {
                SolveSingleCharacter(item);
            }
        }
        public void Solve(List<Boomer> characters)
        {
            foreach (MovableCharacter item in characters)
            {
                SolveSingleCharacter(item);
            }
        }

        private void SolveSingleCharacter(MovableCharacter item)
        {
            int x = (int)item.GridPosition.X;
            int y = (int)item.GridPosition.Y;
            if (item.attemptMoveUP)
            {
                if (y != 0 && !moveMap[x, y - 1])
                {
                    item.doMoveUP();
                }
                item.attemptMoveUP = false;
            }
            else if (item.attemptMoveDOWN)
            {
                if (y != moveMap.GetLength(1) - 1 && !moveMap[x, y + 1])
                {
                    item.doMoveDOWN(); 
                }
                item.attemptMoveDOWN = false;
            }
            else if (item.attemptMoveLEFT)
            {
                if (x != 0 && !moveMap[x - 1, y])
                {
                    item.doMoveLEFT(); 
                }
                item.attemptMoveLEFT = false;
            }
            else if (item.attemptMoveRIGHT)
            {
                if (x != moveMap.GetLength(0) - 1 && !moveMap[x + 1, y])
                {
                    item.doMoveRIGHT();
                }
                item.attemptMoveRIGHT = false;
            }
        }
    }
}
