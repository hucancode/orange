using System;
using System.Collections.Generic;
using System.Text;
using Orange.GameProcessing.Entities;

namespace Orange.GameProcessing.Logics
{
    class BoomSolver
    {
        public Map map;
        public void Solve()
        {
            foreach (Boom item in map.booms)
            {
                if (item.attempExplode && item.state != 1)
                {
                    //map.AddFire((int)(item.gridPosition.X), (int)(item.gridPosition.Y),
                    //    "water_boom", 6);
                    int fire_length = item.owner.boomLength;
                    for (int i = 1; i <= fire_length; i++)
                    {
                        int x = (int)(item.gridPosition.X + i);
                        int y = (int)(item.gridPosition.Y);
                        if (x < 0) break;
                        if (y < 0) break;
                        if (x >= map.brickMap.GetLength(0)) break;
                        if (y >= map.brickMap.GetLength(1)) break;
                        map.AddFire(x, y, "water_boom", 6);
                        if (map.brickMap[x, y]) 
                            break;
                        if (map.boomMap[x, y]) 
                            break;
                    }
                    for (int i = -1; i >= -fire_length; i--)
                    {
                        int x = (int)(item.gridPosition.X + i);
                        int y = (int)(item.gridPosition.Y);
                        if (x < 0) break;
                        if (y < 0) break;
                        if (x >= map.brickMap.GetLength(0)) break;
                        if (y >= map.brickMap.GetLength(1)) break;
                        map.AddFire(x, y, "water_boom", 4);
                        if (map.brickMap[x, y]) 
                            break;
                        if (map.boomMap[x, y]) 
                            break;
                    }
                    for (int i = 1; i <= fire_length; i++)
                    {
                        int x = (int)(item.gridPosition.X);
                        int y = (int)(item.gridPosition.Y + i);
                        if (x < 0) break;
                        if (y < 0) break;
                        if (x >= map.brickMap.GetLength(0)) break;
                        if (y >= map.brickMap.GetLength(1)) break;
                        map.AddFire(x, y, "water_boom", 2);
                        if (map.brickMap[x, y]) 
                            break;
                        if (map.boomMap[x, y]) 
                            break;
                    }
                    for (int i = -1; i >= -fire_length; i--)
                    {
                        int x = (int)(item.gridPosition.X);
                        int y = (int)(item.gridPosition.Y + i);
                        if (x < 0) break;
                        if (y < 0) break;
                        if (x >= map.brickMap.GetLength(0)) break;
                        if (y >= map.brickMap.GetLength(1)) break;
                        map.AddFire(x, y, "water_boom", 8);
                        if (map.brickMap[x, y]) 
                            break;
                        if (map.boomMap[x, y])
                            break;
                    }
                }
            }
        }
    }
}
