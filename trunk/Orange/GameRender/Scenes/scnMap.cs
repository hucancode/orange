using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

//using Mango.GameProcessing.Logics;
using Orange.GameProcessing.Entities;
using Orange.GameData.Materials;

namespace Orange.GameRender.Scenes
{
    public class scnMap : Scene
    {
        Map map;
        public scnMap()
        {
            map = new Map("Background/back1Sprite", 13, 11);
            map.viewOffset.X = -65;
            map.viewOffset.Y = -120;
        }
        public override void UnloadContent()
        {
        }
        public override void Update()
        {
            map.Update();
            if (OrangeInput.trigger(Keys.Enter))
            {
                //UnloadContent();
                //Global.currentScene = new scnOpen();
            }
        }
        public override void Draw()
        {
            map.Draw();
        }
    }
}
