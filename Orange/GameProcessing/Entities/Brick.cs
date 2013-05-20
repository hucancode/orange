using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Orange.GameData.Materials;
using System.IO;

namespace Orange.GameProcessing.Entities
{
    public class Brick : Character
    {
        public bool Vulnerable;
        private int[] idleFrame;
        private int[] explodeFrame;
        public Brick(Vector2 gridPos, string name)
        {
            gridPosition = gridPos;
            mapPosition = gridPosition * 42;
            string data = File.ReadAllText("Content/Brick/" + name + ".txt");
            string[] lines = data.Split('\n');
            string texture = lines[0].TrimEnd('\r');
            string[] frame = lines[1].TrimEnd('\r').Split(',');
            string[] offset = lines[2].TrimEnd('\r').Split(',');
            animation = new Animation("Brick/" + texture, mapPosition, (int)gridPos.Y+1, int.Parse(frame[0]), int.Parse(frame[1]));
            animation.original = new Vector2(float.Parse(offset[0]),float.Parse(offset[1]));
            animation.delay = 60;
            animation.Z = (int)gridPos.Y;
            string[] idleRandom = lines[3].TrimEnd('\r').Split('|');
            Random r = new Random();
            string[] idle = idleRandom[r.Next(0, idleRandom.Length - 1)].Split(',');
            idleFrame = new int[2] { int.Parse(idle[0]), int.Parse(idle[1]) };
            string[] explode = lines[4].TrimEnd('\r').Split(',');
            explodeFrame = new int[2] { int.Parse(explode[0]), int.Parse(explode[1]) };
            Vulnerable = lines[5].TrimEnd('\r') == "1";
            Passable = lines[6].TrimEnd('\r') == "1";
            animation.newAnimation(idleFrame[0], idleFrame[1]);
        }
        public override void Update()
        {
            base.Update();
            if (animation.isStop) state = 1;
        }
        public void Kill()
        {
            animation.isLoop = false;
            animation.newAnimation(explodeFrame[0], explodeFrame[1]);
        }
    }
}
