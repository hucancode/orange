using System;
using System.Collections.Generic;
using System.Text;
using Orange.GameProcessing.Entities;

namespace Orange.GameProcessing.Logics
{
    class MobAISolver
    {
        public Map map;
        private bool[,] safeMap;
        private bool[,] playerMap;
        private bool safeMapCreated;
        private bool playerMapCreated;
        public void Solve()
        {
            safeMapCreated = false;
            playerMapCreated = false;
            foreach (Mob item in map.mobs)
            {
                if (item.IsDead()) continue;
                if (item.moving) continue;
                SolveMobAction(item);
                SolveMobAggressive(item);
            }
        }
        private void SolveMobAction(Mob mob)
        {
            Random r = new Random();
            int value;
            if (mob.action == MobAction.MOVING_RANDOMLY)
            {
                value = r.Next(4);
                if (value == 0)
                {
                    mob.moveUP();
                }
                else if (value == 1)
                {
                    mob.moveDOWN();
                }
                else if (value == 2)
                {
                    mob.moveLEFT();
                }
                else
                {
                    mob.moveRIGHT();
                }
            }
            else if (mob.action == MobAction.EVADE_BOOM)
            {
                // create a map called safe map
                if (!safeMapCreated)
                {
                    safeMap = new bool[13, 11];
                    for (int i = 0; i < 13; i++)
                    {
                        for (int j = 0; j < 11; j++)
                        {
                            safeMap[i, j] = map.brickMap[i, j];
                        }
                    }
                    foreach (Boom item in map.booms)
                    {
                        int x = (int)item.gridPosition.X;
                        int y = (int)item.gridPosition.Y;
                        int length = item.owner.boomLength;
                        for (int i = -length; i <= length; i++)
                        {
                            int xi = x + i;
                            int yi = y + i;
                            if (xi >= 13 || xi<0) continue;
                            safeMap[x + i, y] = false;
                            if (yi >= 11 || yi<0) continue;
                            safeMap[x, y + i] = false;
                        }
                    }
                    safeMapCreated = true;
                }
                // go to safe point in the safe map that have min cost
                int mob_x = (int)mob.gridPosition.X;
                int mob_y = (int)mob.gridPosition.Y;
                int des_x = -1;
                int des_y = -1;
                double min_cost = 0;
                for (int i = 0; i < 13; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        if (des_x != -1)
                        {
                            if (safeMap[i, j])
                            {
                                double cost = Math.Sqrt(Math.Pow(mob_x - i, 2) +
                                    Math.Pow(mob_y - j, 2));
                                if (cost < min_cost)
                                {
                                    des_x = i;
                                    des_y = j;
                                    min_cost = cost;
                                }
                            }
                        }
                        else
                        {
                            if (safeMap[i, j])
                            {
                                des_x = i;
                                des_y = j;
                                min_cost = Math.Sqrt(Math.Pow(mob_x - i, 2) +
                                    Math.Pow(mob_y - j, 2));
                            }
                        }
                    }
                }
                if (des_x == -1)
                {
                    mob.action = MobAction.MOVING_RANDOMLY;
                }
                else
                {
                    mob.actionGoalX = des_x;
                    mob.actionGoalY = des_y;
                }
            }
            else if (mob.action == MobAction.MOVING_TOWARD_PLAYER)
            {
                // create a map called player map
                if (!playerMapCreated)
                {
                    playerMap = new bool[13, 11];
                    for (int i = 0; i < 13; i++)
                    {
                        for (int j = 0; j < 11; j++)
                        {
                            playerMap[i, j] = false;
                        }
                    }
                    foreach (Boomer item in map.boomers)
                    {
                        int x = (int)item.gridPosition.X;
                        int y = (int)item.gridPosition.Y;
                        playerMap[x, y] = true;
                    }
                    playerMapCreated = true;
                }
                // go to player point in the player map that have min cost
                int mob_x = (int)mob.gridPosition.X;
                int mob_y = (int)mob.gridPosition.Y;
                int des_x = -1;
                int des_y = -1;
                double min_cost = 0;
                for (int i = 0; i < 13; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        if (des_x != -1)
                        {
                            if (playerMap[i, j])
                            {
                                double cost = Math.Sqrt(Math.Pow(mob_x - i, 2) +
                                    Math.Pow(mob_y - j, 2));
                                if (cost < min_cost)
                                {
                                    des_x = i;
                                    des_y = j;
                                    min_cost = cost;
                                }
                            }
                        }
                        else
                        {
                            if (playerMap[i, j])
                            {
                                des_x = i;
                                des_y = j;
                                min_cost = Math.Sqrt(Math.Pow(mob_x - i, 2) +
                                    Math.Pow(mob_y - j, 2));
                            }
                        }
                    }
                }
                if (des_x == -1)
                {
                    mob.action = MobAction.MOVING_RANDOMLY;
                }
                else
                {
                    mob.actionGoalX = des_x;
                    mob.actionGoalY = des_y;
                }
            }
        }
        private void SolveMobAggressive(Mob mob)
        {
            if (mob.aggressive == MobAggressive.FOCUS_BOOM)
            {
                Random r = new Random();
                int n = r.Next(100);
                if (n < 50)
                {
                    mob.action = MobAction.EVADE_BOOM;
                }
                else if (n < 75)
                {
                    mob.action = MobAction.MOVING_TOWARD_PLAYER;
                }
                else
                {
                    mob.action = MobAction.MOVING_RANDOMLY;
                }
            }
            else if (mob.aggressive == MobAggressive.FOCUS_BOOMER)
            {
                Random r = new Random();
                int n = r.Next(100);
                if (n < 50)
                {
                    mob.action = MobAction.MOVING_TOWARD_PLAYER;
                }
                else if (n < 75)
                {
                    mob.action = MobAction.EVADE_BOOM;
                }
                else
                {
                    mob.action = MobAction.MOVING_RANDOMLY;
                }
            }
            else if (mob.aggressive == MobAggressive.BALANCE_FOCUS)
            {
                Random r = new Random();
                int n = r.Next(100);
                if (n < 40)
                {
                    mob.action = MobAction.MOVING_TOWARD_PLAYER;
                }
                else if (n < 80)
                {
                    mob.action = MobAction.EVADE_BOOM;
                }
                else
                {
                    mob.action = MobAction.MOVING_RANDOMLY;
                }
            }
            else if (mob.aggressive == MobAggressive.PASSIVE)
            {
                Random r = new Random();
                int n = r.Next(100);
                if (n < 10)
                {
                    mob.action = MobAction.MOVING_TOWARD_PLAYER;
                }
                else if (n < 20)
                {
                    mob.action = MobAction.EVADE_BOOM;
                }
                else
                {
                    mob.action = MobAction.MOVING_RANDOMLY;
                }
            }
        }
    }
}
