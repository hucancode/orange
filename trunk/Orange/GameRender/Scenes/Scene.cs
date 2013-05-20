using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Orange.GameRender.Scenes
{
    public abstract class Scene
    {
        public abstract void UnloadContent();
        public abstract void Update();
        public abstract void Draw();
    }
}
