using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Orange.GameData.Materials;

namespace Orange.GameProcessing.Entities
{
    public enum PowerKind
    {
        FIRE_BOOST,
        MAX_BOOM_BOOST,
        SPEED_BOOST
    };
    public class PowerUp : Character
    {
        public PowerKind Kind;
        private Sprite sprite;
        public PowerUp(Vector2 gridPos)
        {
            gridPosition = gridPos;
            mapPosition = gridPosition * 42;
            state = 0;
            sprite = new Sprite("etc/boost_speed",
                mapPosition, (int)mapPosition.Y);
            sprite.original = new Vector2(20, 40);
        }
        public void RefreshIcon()
        {
            if (Kind == PowerKind.SPEED_BOOST)
            {
                sprite = new Sprite("etc/boost_speed",
                mapPosition, (int)mapPosition.Y);
            }
            else if (Kind == PowerKind.MAX_BOOM_BOOST)
            {
                sprite = new Sprite("etc/boost_max_boom",
                mapPosition, (int)mapPosition.Y);
            }
            else if (Kind == PowerKind.FIRE_BOOST)
            {
                sprite = new Sprite("etc/boost_boom_length",
                mapPosition, (int)mapPosition.Y);
            }
            sprite.original = new Vector2(20, 40);
        }
        public override void Update()
        {
            //base.Update();
        }
        public override void Draw()
        {
            sprite.Draw();
        }
        public override void UpdateOffset(Vector2 offset)
        {
            sprite.position.X = mapPosition.X - offset.X;
            sprite.position.Y = mapPosition.Y - offset.Y;
        }
        public void Kill()
        {
            if (IsDead()) return;
            state = 2;
        }
    }
}
