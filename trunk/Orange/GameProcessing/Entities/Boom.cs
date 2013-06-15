using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Orange.GameData.Materials;
using System.IO;
using System.Xml;

namespace Orange.GameProcessing.Entities
{
    public class Boom : Character
    {
        public bool Vulnerable;
        public bool attempExplode;
        public Boomer owner;

        private int waitTime;
        private int kind;
        private int[] idleFrame;
        private int[] explodeFrame;
        // state: 2 = waiting, 3 = firing, 4= disable
        public Boom(Vector2 gridPos, string name)
        {
            gridPosition = gridPos;
            mapPosition = gridPosition * 42;
            waitTime = 160;
            {// load from xml
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
                animation.original = new Vector2(ox, oy);
                animation.delay = 60;

                int idleStart = int.Parse(idleTAG.GetAttribute("begin"));
                int idleEnd = int.Parse(idleTAG.GetAttribute("end"));
                idleFrame = new int[2] {idleStart,idleEnd };
                int dieStart = int.Parse(dieTAG.GetAttribute("begin"));
                int dieEnd = int.Parse(dieTAG.GetAttribute("end"));
                explodeFrame = new int[2] {dieStart,dieEnd };
            }
            animation.newAnimation(idleFrame[0], idleFrame[1]);
        }
        public override void Update()
        {
            base.Update();
            if (state == 2) return;
            if (attempExplode) state = 1;
            waitTime--;
            if (waitTime <= 0 && !attempExplode)
                Kill();
            if (animation.isStop)
                state = 2;
        }
        public void Kill()
        {
            waitTime = 0;
            animation.isLoop = false;
            animation.newAnimation(explodeFrame[0], explodeFrame[1]);
            attempExplode = true;
            owner.boomStackCount--;
        }
    }
}
