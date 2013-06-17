using System;
using Orange.GameData.Materials;
using Microsoft.Xna.Framework;

namespace Orange.GameProcessing.Entities
{
    public class Character
    {
        protected Animation animation;
        public Vector2 mapPosition;
        public Vector2 gridPosition;
        public Vector2 GridPosition
        {
            get { return gridPosition; }
            set
            {
                gridPosition = value;
                mapPosition = gridPosition * 42;
            }
        }
        public int state;// 0= alive, 1= dead, >1= ...
        public bool passable;
        public Character()
        {
            gridPosition = Vector2.Zero;
            mapPosition = gridPosition * 42;
            state = 0;
            passable = false;
        }
        public Character(Vector2 gridPos, string texture)
        {
            gridPosition = gridPos;
            mapPosition = gridPosition * 42;
            state = 0;
            passable = false;
            animation = new Animation(texture, gridPos * 42, (int)gridPos.Y+1, 8);
            animation.original.X = animation.Width / 2;
            animation.original.Y = animation.Height;
        }
        public int Z
        {
            get { return animation.Z; }
            set
            {
                animation.Z = value;
            }
        }
        public void UpdateOffset(Vector2 offset)
        {
            animation.position.X = mapPosition.X - offset.X;
            animation.position.Y = mapPosition.Y - offset.Y;
        }
        public bool IsDead()
        {
            return state == 1;
        }
        public bool IsDispose()
        {
            return state == 2;
        }
        public virtual void Update()
        {
            animation.Update();
        }
        public virtual void Draw()
        {
            animation.Draw();
        }
        public virtual void Kill()
        {
            state = 1;
        }
        public virtual void Dispose()
        {
            state = 2;
            animation.Dispose();
        }
    }
}
