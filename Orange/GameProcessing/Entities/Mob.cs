using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Orange.GameData.Materials;
using System.Xml;
using System.IO;

namespace Orange.GameProcessing.Entities
{
    public enum MobAction
	{
        MOVING_RANDOMLY, 
        MOVING_TOWARD_PLAYER,
        EVADE_BOOM
	}
    public enum MobAggressive
	{
        PASSIVE,
        FOCUS_BOOM,
        FOCUS_BOOMER,
        BALANCE_FOCUS
	}
    public class Mob : MovableCharacter
    {
        private int[] idleFrame;
        private int[] moveFrame;
        private int[] birthFrame;
        private int[] dieFrame;
        private Vector2 idleOff;
        private Vector2 moveOff;
        private Vector2 birthOff;
        private Vector2 dieOff;
        public MobAggressive aggressive;
        public MobAction action;
        public int actionGoalX;
        public int actionGoalY;
        //..
        private int idleDelay;
        private bool lastMoving;
        public Mob(Vector2 gridPos, string name)
            //:base(gridPos,name)
        {
            {
                moveSpeed = 1;
                gridPosition = gridPos;
                mapPosition = gridPosition * 42;
                newMapPosition = mapPosition;
                state = 0;
            }
            {
                string data = File.ReadAllText("Content/Mob/" + name + ".xml");
                XmlDocument document = new XmlDocument();
                document.LoadXml(data);
                XmlElement mobTAG = (XmlElement)document.FirstChild.NextSibling;
                XmlElement textureTAG = (XmlElement)mobTAG.FirstChild;
                XmlElement attributeTAG = (XmlElement)textureTAG.NextSibling;
                XmlElement animationTAG = (XmlElement)attributeTAG.NextSibling;
                XmlElement idleTAG = (XmlElement)animationTAG.FirstChild;
                XmlElement moveTAG = (XmlElement)idleTAG.NextSibling;
                XmlElement birthTAG = (XmlElement)moveTAG.NextSibling;
                XmlElement dieTAG = (XmlElement)birthTAG.NextSibling;

                string texture = textureTAG.GetAttribute("file");
                int dx = int.Parse(textureTAG.GetAttribute("divide_x"));
                int dy = int.Parse(textureTAG.GetAttribute("divide_y"));
                animation = new Animation("Mob/" + texture, mapPosition, (int)gridPos.Y, dx, dy);
                
                animation.delay = 60;

                idleFrame = new int[2] { int.Parse(idleTAG.GetAttribute("begin")), 
                    int.Parse(idleTAG.GetAttribute("end")) };
                idleOff = new Vector2(
                    int.Parse(idleTAG.GetAttribute("offset_x")),
                    int.Parse(idleTAG.GetAttribute("offset_y"))
                    );
                moveFrame = new int[2] { int.Parse(moveTAG.GetAttribute("begin")), 
                    int.Parse(moveTAG.GetAttribute("end"))};
                moveOff = new Vector2(
                    int.Parse(moveTAG.GetAttribute("offset_x")),
                    int.Parse(moveTAG.GetAttribute("offset_y"))
                    );
                birthFrame = new int[2] { int.Parse(birthTAG.GetAttribute("begin")), 
                    int.Parse(birthTAG.GetAttribute("end")) };
                birthOff = new Vector2(
                    int.Parse(birthTAG.GetAttribute("offset_x")),
                    int.Parse(birthTAG.GetAttribute("offset_y"))
                    );
                dieFrame = new int[2] { int.Parse(dieTAG.GetAttribute("begin")), 
                    int.Parse(dieTAG.GetAttribute("end"))};
                dieOff = new Vector2(
                    int.Parse(dieTAG.GetAttribute("offset_x")),
                    int.Parse(dieTAG.GetAttribute("offset_y"))
                    );

                animation.PlayAnimation(idleFrame[0], idleFrame[1]);
                animation.original = idleOff;
                animation.SwitchAnimation(birthFrame[0], birthFrame[1]);
                animation.original = birthOff;
            }
            {
                action = MobAction.MOVING_RANDOMLY;
                actionGoalX = (int)gridPosition.X;
                actionGoalY = (int)gridPosition.Y;
                aggressive = MobAggressive.FOCUS_BOOM;
            }
        }

        public override void moveUP()
        {
            if (moving && idleDelay == 0) return;
            base.moveUP();
            direction = 0;
            int length = (moveFrame[1] - moveFrame[0] + 1) / 4;
            int start = length * direction + moveFrame[0];
            int end = start + length - 1;
            //Console.WriteLine("start\t" + start.ToString() + ",\tend\t" + end.ToString());
            animation.original = moveOff;
            animation.PlayAnimation(start, end);
            Z = (int)gridPosition.Y + 2;
        }

        public override void moveDOWN()
        {
            if (moving && idleDelay == 0) return;
            base.moveDOWN();
            direction = 2;
            int length = (moveFrame[1] - moveFrame[0] + 1) / 4;
            int start = length * direction + moveFrame[0];
            int end = start + length - 1;
            //Console.WriteLine("start\t" + start.ToString() + ",\tend\t" + end.ToString());
            animation.original = moveOff;
            animation.PlayAnimation(start, end);
            Z = (int)gridPosition.Y + 2;
            
        }

        public override void moveLEFT()
        {
            if (moving && idleDelay == 0) return;
            base.moveLEFT();
            direction = 3;
            int length = (moveFrame[1] - moveFrame[0] + 1) / 4;
            int start = length * direction + moveFrame[0];
            int end = start + length - 1;
            //Console.WriteLine("start\t" + start.ToString() + ",\tend\t" + end.ToString());
            animation.original = moveOff;
            animation.PlayAnimation(start, end);
        }

        public override void moveRIGHT()
        {
            if (moving && idleDelay == 0) return;
            base.moveRIGHT();
            direction = 1;
            int length = (moveFrame[1] - moveFrame[0] + 1) / 4;
            int start = length * direction + moveFrame[0];
            int end = start + length - 1;
            //Console.WriteLine("start\t" + start.ToString() + ",\tend\t" + end.ToString());
            animation.original = moveOff;
            animation.PlayAnimation(start, end);
        }

        public override void Update()
        {
            Console.WriteLine("off: {0} {1}",animation.original.X.ToString(), animation.original.Y.ToString());
            base.Update();
            if (IsDead() && animation.isStop)
            {
                Dispose();
            }
            if (!moving)
            {
                idleDelay--;
            }
            lastMoving = moving;
            UpdatePixelMove();
            //UpdateAutoMove();
        }

        private void PlayIdle()
        {
            idleDelay = 20;
            int length = (idleFrame[1] - idleFrame[0] + 1) / 4;
            int start = length * direction + idleFrame[0];
            int end = start + length - 1;
            //Console.WriteLine("start\t" + start.ToString() + ",\tend\t" + end.ToString());
            animation.PlayAnimation(start, end);
            animation.original = idleOff;
        }
        public override void Kill()
        {
            if (IsDead()) return;
            base.Kill();
            animation.isLoop = false;
            animation.PlayAnimation(dieFrame[0], dieFrame[1]);
            animation.original = dieOff;
        }
        public void UpdateAutoMove()
        {
            if (moving) return;
            int gx = (int)gridPosition.X;
            int gy = (int)gridPosition.Y;
            if (actionGoalX != gx || 
                actionGoalY != gy)
            {
                if (actionGoalX > gx)
                {
                    moveRIGHT();
                }
                else if (actionGoalX < gx)
                {
                    moveLEFT();
                }
                else if (actionGoalY < gy)
                {
                    moveDOWN();
                }
                else if (actionGoalY < gy)
                {
                    moveUP();
                }
            }
        }
    }
}
