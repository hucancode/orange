﻿using System;
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
        private Vector2 idleOff;
        private Vector2 explodeOff;
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
                animation = new Animation("Boom/" + texture,
                    mapPosition, (int)gridPosition.Y + 1, dx, dy);
                animation.delay = 60;

                idleFrame = new int[2] { int.Parse(idleTAG.GetAttribute("begin")), 
                    int.Parse(idleTAG.GetAttribute("end")) };
                idleOff = new Vector2(
                    int.Parse(idleTAG.GetAttribute("offset_x")),
                    int.Parse(idleTAG.GetAttribute("offset_y"))
                    );
                explodeFrame = new int[2] { int.Parse(dieTAG.GetAttribute("begin")), 
                    int.Parse(dieTAG.GetAttribute("end"))};
                explodeOff = new Vector2(
                    int.Parse(dieTAG.GetAttribute("offset_x")),
                    int.Parse(dieTAG.GetAttribute("offset_y"))
                    );
            }
            animation.PlayAnimation(idleFrame[0], idleFrame[1]);
            animation.original = idleOff;
        }
        public override void Update()
        {
            base.Update();
            if (IsDispose()) return;
            waitTime--;
            if (waitTime <= 0 && !attempExplode)
                Kill();
            if (animation.isStop)
                Dispose();
        }
        public override void Kill()
        {
            if (IsDead()) return;
            base.Kill();
            waitTime = 0;
            animation.isLoop = false;
            animation.PlayAnimation(explodeFrame[0], explodeFrame[1]);
            animation.original = explodeOff;
            attempExplode = true;
            owner.boomStackCount--;
        }
    }
}
