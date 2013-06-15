using System;
using System.Collections.Generic;
using System.Text;
using Orange.GameProcessing.Entities;

namespace Orange.GameProcessing.Logics
{
    class BoomerSolver
    {
        public Map map;
        public void Solve(List<Boomer> boomers)
        {
            foreach (Boomer item in boomers)
            {
                if (!item.attemptPutBoom) continue;
                int x = (int)item.gridPosition.X, y = (int)item.gridPosition.Y;
                if (map.boomMap[x, y]) continue;
                map.AddBoom(x, y, "water_boom", item);
                item.boomStackCount++;
                item.attemptPutBoom = false;
            }
        }
    }
}
