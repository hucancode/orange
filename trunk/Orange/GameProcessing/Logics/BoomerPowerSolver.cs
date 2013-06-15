using System;
using System.Collections.Generic;
using System.Text;
using Orange.GameProcessing.Entities;

namespace Orange.GameProcessing.Logics
{
    class BoomerPowerSolver
    {
        public Map map;
        public void Solve()
        {
            if (map.boomers.Count == 0) return;
            if (map.powers.Count == 0) return;
            foreach (Boomer item in map.boomers)
            {
                foreach (PowerUp pow in map.powers)
                {
                    if (pow.state == 2) continue;
                    if (item.GridPosition.X == pow.GridPosition.X &&
                        item.GridPosition.Y == pow.GridPosition.Y)
                    {
                        if (pow.Kind == PowerKind.FIRE_BOOST)
                        {
                            item.boomLength++;
                        }
                        else if (pow.Kind == PowerKind.MAX_BOOM_BOOST)
                        {
                            item.boomStackMax++;
                        }
                        else if (pow.Kind == PowerKind.SPEED_BOOST)
                        {
                            if (item.moveSpeed < 6) item.moveSpeed++;
                        }
                        pow.Kill();
                    }
                }
            }
        }
    }
}
