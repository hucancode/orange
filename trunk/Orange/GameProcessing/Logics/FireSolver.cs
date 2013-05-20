using System;
using System.Collections.Generic;
using System.Text;
using Orange.GameProcessing.Entities;

namespace Orange.GameProcessing.Logics
{
    class FireSolver
    {
        public List<Fire> fireList;
        public List<Mob> mobList;
        public List<Boom> boomList;
        public List<Boomer> boomerList;
        public void Solve(int mapWidth, int mapHeight)
        {
            if (mobList.Count == 0) return;
            if (fireList.Count == 0) return;
            bool[,] fireMap = new bool[mapWidth, mapHeight];
            foreach (Fire item in fireList)
            {
                if (item.Killed) continue;
                int x = (int)item.GridPosition.X;
                int y = (int)item.GridPosition.Y;
                fireMap[x, y] = true;
                item.Kill();
            }
            foreach (Mob item in mobList)
            {
                int x = (int)item.GridPosition.X;
                int y = (int)item.GridPosition.Y;
                if(fireMap[x, y])
                    item.Kill();
            }
            foreach (Boom item in boomList)
            {
                int x = (int)item.GridPosition.X;
                int y = (int)item.GridPosition.Y;
                if (fireMap[x, y])
                    item.Kill();
            }
            foreach (Boomer item in boomerList)
            {
                int x = (int)item.GridPosition.X;
                int y = (int)item.GridPosition.Y;
                if (fireMap[x, y])
                    item.Kill();
            }
        }
    }
}
