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
    public class SceneOpen : Scene
    {
        private TextSprite txtTitle, txtSubTitle;
        private List<Texture2D> textureList = new List<Texture2D>();
        public SceneOpen()
        {
            txtTitle = new TextSprite(110f, 200f, Color.Black, "Orange code name", "Tahoma50");
            txtSubTitle = new TextSprite(280f, 280f, Color.Black, 
                "Press Enter to continue\nPress Esc for amazing thing\nPress F2 for Win scene\nPress F3 Lose scene", "Tahoma15");
        }
        public override void UnloadContent()
        {
        }
        public override void Update()
        {
            if (OrangeInput.trigger(Keys.Enter))
            {
                //UnloadContent();
                Global.currentScene = new SceneMap();
            }
            if (OrangeInput.trigger(Keys.Escape))
            {
                txtSubTitle.text = "Press Enter to continue\nAmazing thing!";
            }
            if (OrangeInput.trigger(Keys.F2))
            {
                Global.currentScene = new SceneWin();
            }
            if (OrangeInput.trigger(Keys.F3))
            {
                Global.currentScene = new SceneLose();
            }

        }
        public override void Draw()
        {
            txtTitle.Draw();
            txtSubTitle.Draw();
        }
    }
}
