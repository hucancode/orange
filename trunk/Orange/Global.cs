using Orange.GameRender.Scenes;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Orange
{
    public class Global
    {
        public static Scene currentScene;
        public static ContentManager Content;
        public static GraphicsDevice graphicsDevice;
        public static SpriteBatch spriteBatch;
        public static bool ExcuteExit;
        public static SpriteFont defaultFont;
        public static GameTime gameTime;
    }
}