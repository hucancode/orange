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
    public class scnOpen : Scene
    {
        private TextSprite txtTitle, txtSubTitle;
        private List<Texture2D> textureList = new List<Texture2D>();
        public scnOpen()
        {
            txtTitle = new TextSprite(110f, 200f, Color.Black, "Orange code name", "Tahoma50");
            txtSubTitle = new TextSprite(280f, 280f, Color.Black, "Press Enter to continue\nPress Esc for amazing thing", "Tahoma15");
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
            if (OrangeInput.trigger(Keys.Escape))
            {
                txtSubTitle.text = "Press Enter to continue\nAmazing thing!";
            }

        }
        public override void Draw()
        {
            txtTitle.Draw();
            txtSubTitle.Draw();
        }
    }
}
