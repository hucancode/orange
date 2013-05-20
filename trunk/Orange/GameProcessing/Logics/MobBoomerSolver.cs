using System;
using System.Collections.Generic;
using System.Text;
using Orange.GameProcessing.Entities;

namespace Orange.GameProcessing.Logics
{
    class MobBoomerSolver
    {
        public List<Mob> mobList;
        public List<Boomer> boomerList;
        public void Solve(int mapWidth, int mapHeight)
        {
            bool[,] fireMap = new bool[mapWidth, mapHeight];
            foreach (Mob item in mobList)
            {
                if (item.state == 1) continue;
                fireMap[(int)item.GridPosition.X, (int)item.GridPosition.Y] = true;
            }
            foreach (Boomer item in boomerList)
            {
                if (item.state == 1) continue;
                int x = (int)item.GridPosition.X;
                int y = (int)item.GridPosition.Y;
                if (fireMap[x, y])
                    item.Kill();
            }
        }
    }
}
