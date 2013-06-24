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
    public class SceneTitle : Scene
    {
        // TODO: implement scene title
        private Sprite background;
        private Sprite newgame;
        private Sprite continue_game;
        private Sprite exit;
        private int index;
        public SceneTitle()
        {
            int x = 279-80;
            int y = 371;
            background = new Sprite("etc/title", Vector2.Zero, 0);
            background.position.X -= 80;
            newgame = new Sprite("etc/newgame_up", new Vector2(x,y), 1);
            continue_game = new Sprite("etc/continue_normal", new Vector2(x, y+35), 1);
            exit = new Sprite("etc/exit_normal", new Vector2(x, y+35*2), 1);
            index = 0;
        }
        public override void UnloadContent()
        {
        }
        public override void Update()
        {
            if (OrangeInput.trigger(Keys.Enter))
            {
                Decision();
            }
            else if (OrangeInput.trigger(Keys.Up))
            {
                index--;
                if (index < 0) index = 2;
                if (index > 2) index = 0;
                RefreshButton();

            }
            else if (OrangeInput.trigger(Keys.Down))
            {
                index++;
                if (index < 0) index = 2;
                if (index > 2) index = 0;
                RefreshButton();
            }
        }
        private void Decision()
        {
            if (index == 0)
            {
                Global.currentScene = new SceneMap();
            }
            else if(index == 1)
            {
            }
            else if (index == 2)
            {
                Global.ExcuteExit = true;
            }
        }
        private void RefreshButton()
        {
            newgame.texture = Global.Content.Load<Texture2D>("etc/newgame_normal");
            continue_game.texture = Global.Content.Load<Texture2D>("etc/continue_normal");
            exit.texture = Global.Content.Load<Texture2D>("etc/exit_normal");
            if (index == 0)
            {
                newgame.texture = Global.Content.Load<Texture2D>("etc/newgame_up");
            }
            else if (index == 1)
            {
                continue_game.texture = Global.Content.Load<Texture2D>("etc/continue_up");
            }
            else if (index == 2)
            {
                exit.texture = Global.Content.Load<Texture2D>("etc/exit_up");
            }
        }
        public override void Draw()
        {
            background.Draw();
            newgame.Draw();
            continue_game.Draw();
            exit.Draw();
        }
    }
}
