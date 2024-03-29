using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Orange.GameRender.Scenes;
//------------------------------
// Project Orange
// started: 22/11/2011
// coded by ngoa ho
//------------------------------
namespace Orange
{
    public class Orange : Game
    {
        GraphicsDeviceManager graphics;
        public Orange()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";

        }
        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            OrangeInput.Initialize();
            Global.ExcuteExit = false;
            Global.Content = this.Content;
            Global.defaultFont = Content.Load<SpriteFont>("Font/Tahoma15");
            Global.graphicsDevice = GraphicsDevice;
            Global.spriteBatch = new SpriteBatch(GraphicsDevice);
            Global.currentScene = new SceneTitle();
            base.Initialize();
        }
        protected override void LoadContent()
        { }
        protected override void UnloadContent()
        { }
        protected override void Update(GameTime gameTime)
        {
            Global.gameTime = gameTime;
            Global.currentScene.Update();
            OrangeInput.Update();
            if (Global.ExcuteExit) Exit();
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            Global.graphicsDevice.Clear(Color.CornflowerBlue);
            Global.spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            Global.currentScene.Draw();
            Global.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
