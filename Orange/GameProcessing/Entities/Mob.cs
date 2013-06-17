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
    public class Mob : MovableCharacter
    {
        private int[] idleFrame;
        private int[] moveFrame;
        private int[] birthFrame;
        private int[] dieFrame;
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
                int ox = int.Parse(textureTAG.GetAttribute("offset_x"));
                int oy = int.Parse(textureTAG.GetAttribute("offset_y"));
                animation = new Animation("Mob/" + texture, mapPosition, (int)gridPos.Y, dx, dy);
                animation.original = new Vector2(ox, oy);
                animation.delay = 60;

                int idleStart = int.Parse(idleTAG.GetAttribute("begin"));
                int idleEnd = int.Parse(idleTAG.GetAttribute("end"));
                idleFrame=new int[2]{idleStart,idleEnd};
                int moveStart = int.Parse(moveTAG.GetAttribute("begin"));
                int moveEnd = int.Parse(moveTAG.GetAttribute("end"));
                moveFrame = new int[2] { moveStart, moveEnd }; 
                int birthStart = int.Parse(birthTAG.GetAttribute("begin"));
                int birthEnd = int.Parse(birthTAG.GetAttribute("end"));
                birthFrame = new int[2] { birthStart, birthEnd }; 
                int dieStart = int.Parse(dieTAG.GetAttribute("begin"));
                int dieEnd = int.Parse(dieTAG.GetAttribute("end"));
                dieFrame = new int[2] { dieStart, dieEnd };
            }
        }

        public override void moveUP()
        {
            if (moving) return;
            base.moveUP();
            //if (faceDirection != 8)
            animation.PlayAnimation(21, 26);
            Z = (int)gridPosition.Y + 2;
        }

        public override void moveDOWN()
        {
            if (moving) return;
            base.moveDOWN();
            //if (faceDirection != 2)
            animation.PlayAnimation(27, 32);
            Z = (int)gridPosition.Y + 2;
        }

        public override void moveLEFT()
        {
            if (moving) return;
            base.moveLEFT();
            //if (faceDirection != 4)
            animation.PlayAnimation(9, 14);
        }

        public override void moveRIGHT()
        {
            if (moving) return;
            base.moveRIGHT();
            //if (faceDirection != 6)
            animation.PlayAnimation(18, 22);
        }

        public override void Update()
        {
            base.Update();
            if (IsDead() && animation.isStop)
            {
                Dispose();
            }
            bool lastMoving = moving;
            UpdatePixelMove();
            if (lastMoving && !moving)
                animation.PlayAnimation(animation.frStart - 1, animation.frStart - 1);
            UpdateAutoMove();
           
        }
        public void Kill()
        {
            state = 1;
            animation.isLoop = false;
            animation.PlayAnimation(1, 9);
        }
        private void UpdateAutoMove()
        {
            if (OrangeInput.trigger(Keys.C))
                Console.WriteLine(gridPosition.ToString());
            if (!moving)
            {
                Random r = new Random();
                int i = r.Next(4);
                if (i == 0)
                {
                    Console.WriteLine("Up");
                    moveUP();
                }
                else if (i == 1)
                {
                    Console.WriteLine("Down");
                    moveDOWN();
                }
                else if (i == 2)
                {
                    Console.WriteLine("Left");
                    moveLEFT();
                }
                else
                {
                    Console.WriteLine("Right");
                    moveRIGHT();
                }
            }
        }
    }
}
