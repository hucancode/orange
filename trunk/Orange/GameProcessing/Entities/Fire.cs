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
        public bool Killed;
        public bool Disposed;
        private int[] birthFrame;
        private int[] explodeFrame;
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
                int ox = int.Parse(textureTAG.GetAttribute("offset_x"));
                int oy = int.Parse(textureTAG.GetAttribute("offset_y"));
                animation = new Animation("Boom/" + texture,
                    mapPosition, (int)gridPosition.Y + 1, dx, dy);
                //animation.original = new Vector2(ox, oy);
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
                int birthStart = int.Parse(birthTAG.GetAttribute("begin"));
                int birthEnd = int.Parse(birthTAG.GetAttribute("end"));
                birthFrame = new int[2] { birthStart, birthEnd };
                int dieStart = int.Parse(moveTAG.GetAttribute("begin"));
                int dieEnd = int.Parse(moveTAG.GetAttribute("end"));
                explodeFrame = new int[2] { dieStart, dieEnd };
            }
            
            animation.delay = 60;
            animation.isLoop = false;
            animation.newAnimation(birthFrame[0], birthFrame[1]);
        }
        public override void Update()
        {
            base.Update();
            if (Disposed) return;
            if (animation.isStop && !Killed)
            {
                Kill();
            }
            else if (animation.isStop)
            {
                Disposed = true;
                Dispose();
            }
        }
        public void Kill()
        {
            Killed = true;
            animation.newAnimation(explodeFrame[0], explodeFrame[1]);
        }
    }
}
