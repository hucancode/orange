using System;
using System.Collections.Generic;
using System.Text;
using Orange.GameProcessing.Entities;

namespace Orange.GameProcessing.Logics
{
    class MobBoomerSolver
    {
        public Map map;
        public void Solve()
        {
            int width = map.brickMap.GetLength(0);
            int height = map.brickMap.GetLength(1);
            bool[,] fireMap = new bool[width, height];
            foreach (Mob item in map.mobs)
            {
                if (item.IsDead()) continue;
                fireMap[(int)item.GridPosition.X, (int)item.GridPosition.Y] = true;
            }
            foreach (Boomer item in map.boomers)
            {
                if (item.IsDead()) continue;
                int x = (int)item.GridPosition.X;
                int y = (int)item.GridPosition.Y;
                if (fireMap[x, y])
                    item.Kill();
            }
        }
    }
}
