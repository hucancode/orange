using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

//using Mango.GameProcessing.Logics;
using Orange.GameProcessing.Entities;
using Orange.GameData.Materials;

namespace Orange.GameRender.Scenes
{
    class SceneWin:Scene
    {
        private Sprite banner_win;
        public SceneWin()
        {
            banner_win = new Sprite("etc/banner_win", Vector2.Zero, 1);
            banner_win.position = new Vector2(400-banner_win.texture.Width/2,
                300-banner_win.texture.Height/2);
            

        }
        public override void UnloadContent()
        {

        }
        public override void Update()
        {
          
        }
        public override void Draw()
        {
            banner_win.Draw();

        }

    }
}
