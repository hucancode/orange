using System;
using System.Collections.Generic;
using System.Text;
using Orange.GameProcessing.Entities;
using Microsoft.Xna.Framework;

namespace Orange.GameProcessing.Logics
{
    class FireSolver
    {
        public Map map;
        public void Solve()
        {
            if (map.mobs.Count == 0) return;
            if (map.fires.Count == 0) return;
            bool[,] fireMap = new bool[(int)map.size.X, (int)map.size.Y];
            foreach (Fire item in map.fires)
            {
                if (item.Killed) continue;
                int x = (int)item.GridPosition.X;
                int y = (int)item.GridPosition.Y;
                fireMap[x, y] = true;
                item.Kill();
            }
            foreach (Mob item in map.mobs)
            {
                int x = (int)item.GridPosition.X;
                int y = (int)item.GridPosition.Y;
                if(fireMap[x, y])
                    item.Kill();
            }
            foreach (Boom item in map.booms)
            {
                int x = (int)item.GridPosition.X;
                int y = (int)item.GridPosition.Y;
                if (fireMap[x, y])
                    item.Kill();
            }
            foreach (Boomer item in map.boomers)
            {
                int x = (int)item.GridPosition.X;
                int y = (int)item.GridPosition.Y;
                if (fireMap[x, y])
                    item.Kill();
            }
            foreach (Brick item in map.bricks)
            {
                int x = (int)item.GridPosition.X;
                int y = (int)item.GridPosition.Y;
                if (fireMap[x, y] && item.Vulnerable)
                {
                    item.Kill();
                    map.brickMap[x, y] = false;
                    PowerUp power = new PowerUp(new Vector2(x,y));
                    map.powers.Add(power);
                }
            }
        }
    }
}
