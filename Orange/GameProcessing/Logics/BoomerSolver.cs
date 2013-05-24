﻿using System;
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
                map.AddBoom(x, y, "WaterBoom");
                item.attemptPutBoom = false;
            }
        }
    }
}