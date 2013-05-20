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
                XmlElement mobTAG = (XmlElement)document.FirstChild;
                if (mobTAG.Name != "boom") mobTAG = (XmlElement)mobTAG.NextSibling;
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
                    mapPosition, (int)gridPos.Y + 1, dx, dy);
                animation.original = new Vector2(ox, oy);
                animation.delay = 60;


                int idleStart = int.Parse(idleTAG.GetAttribute("begin"));
                int idleEnd = int.Parse(idleTAG.GetAttribute("end"));
                idleFrame = new int[2] {idleStart,idleEnd };
                int dieStart = int.Parse(dieTAG.GetAttribute("begin"));
                int dieEnd = int.Parse(dieTAG.GetAttribute("end"));
                explodeFrame = new int[2] {dieStart,dieEnd };


            }
            if(false){// load from text
                string data = File.ReadAllText("Content/Boom/" + name + ".txt");
                string[] lines = data.Split('\n');
                string texture = lines[0].TrimEnd('\r');
                string[] frame = lines[1].TrimEnd('\r').Split(',');
                string[] offset = lines[2].TrimEnd('\r').Split(',');
                animation = new Animation("Boom/" + texture, mapPosition, (int)gridPos.Y + 1, int.Parse(frame[0]), int.Parse(frame[1]));
                animation.original = new Vector2(float.Parse(offset[0]), float.Parse(offset[1]));
                animation.delay = 60;
                string[] idleRandom = lines[3].TrimEnd('\r').Split('|');
                Random r = new Random();
                string[] idle = idleRandom[r.Next(0, idleRandom.Length - 1)].Split(',');
                idleFrame = new int[2] { int.Parse(idle[0]), int.Parse(idle[1]) };
                string[] explode = lines[4].TrimEnd('\r').Split(',');
                explodeFrame = new int[2] { int.Parse(explode[0]), int.Parse(explode[1]) };
                kind = int.Parse(lines[5].TrimEnd('\r'));
                animation.newAnimation(idleFrame[0], idleFrame[1]);
            }
        }
        public override void Update()
        {
            base.Update();
            if (state == 1) return;
            waitTime--;
            if (waitTime <= 0)
                Kill();
            if (animation.isStop)
                state = 1;
        }
        public void Kill()
        {
            waitTime = 0;
            animation.isLoop = false;
            animation.newAnimation(explodeFrame[0], explodeFrame[1]);
            attempExplode = true;
        }
    }
}
