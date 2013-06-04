using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

using Orange.GameProcessing.Entities;
using Orange.GameData.Materials;

namespace Orange.GameRender.Scenes
{
    class SceneLose:Scene
    {
        private Sprite banner_lose;
        public SceneLose()
        {
            banner_lose = new Sprite("stuff/banner_lose", Vector2.Zero, 1);
            banner_lose.position=new Vector2(400 - banner_lose.texture.Width / 2,
                300 - banner_lose.texture.Height / 2);
        }
        public override void UnloadContent()
        {
            
        }
        public override void Update()
        {
            if (OrangeInput.trigger(Keys.Enter))
            {
                //UnloadContent();
                Global.currentScene = new scnMap();
            }
        }
        public override void Draw()
        {
            banner_lose.Draw();
        }

    }
}
