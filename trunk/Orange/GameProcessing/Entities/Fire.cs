using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Orange.GameData.Materials;
using System.Xml;
using System.IO;

namespace Orange.GameProcessing.Entities
{
    public class Fire: Character
    {
        public bool Disposed;
        private int[] birthFrame;
        private int[] explodeFrame;
        private Vector2 birthOff;
        private Vector2 explodeOff;
        public Fire(Vector2 pos, string name, int direction)
        {
            gridPosition = pos;
            mapPosition = gridPosition * 42;
            {
                string data = File.ReadAllText("Content/Boom/" + name + ".xml");
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
                animation = new Animation("Boom/" + texture,
                    mapPosition, (int)gridPosition.Y + 1, dx, dy);
                animation.delay = 60;
                if (direction == 4)
                {
                    animation.angle = (float)Math.PI * 3 / 2;
                    animation.original = new Vector2(0,
                        animation.Height / 2);
                }
                else if (direction == 2)
                {
                    animation.angle = (float)Math.PI;
                    animation.original = new Vector2(animation.Width / 2,
                        0);
                }
                else if (direction == 6)
                {
                    animation.angle = (float)Math.PI / 2;
                    animation.original = new Vector2(animation.Width, 
                        animation.Height/2);
                }
                else if (direction == 8)
                {
                    animation.angle = 0;
                    animation.original = new Vector2(animation.Width/2,
                        animation.Height);
                }
                explodeFrame = new int[2] { int.Parse(moveTAG.GetAttribute("begin")), 
                    int.Parse(moveTAG.GetAttribute("end"))};
                explodeOff = new Vector2(
                    int.Parse(idleTAG.GetAttribute("offset_x")),
                    int.Parse(idleTAG.GetAttribute("offset_y"))
                    );
                birthFrame = new int[2] { int.Parse(birthTAG.GetAttribute("begin")), 
                    int.Parse(birthTAG.GetAttribute("end")) };
                birthOff = new Vector2(
                    int.Parse(birthTAG.GetAttribute("offset_x")),
                    int.Parse(birthTAG.GetAttribute("offset_y"))
                    );
            }
            
            animation.delay = 60;
            animation.isLoop = false;
            animation.PlayAnimation(birthFrame[0], birthFrame[1]);
            //animation.original = birthOff;
        }
        public override void Update()
        {
            base.Update();
            if (IsDispose()) return;
            if (animation.isStop && !IsDead())
            {
                Kill();
            }
            else if (animation.isStop)
            {
                Dispose();
            }
        }
        public void Kill()
        {
            if (IsDead()) return;
            base.Kill();
            animation.PlayAnimation(explodeFrame[0], explodeFrame[1]);
            //animation.original = explodeOff;
        }
    }
}
