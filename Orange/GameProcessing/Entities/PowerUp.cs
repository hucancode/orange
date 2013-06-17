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
        public PowerUp(Vector2 gridPos)
        {
            gridPosition = gridPos;
            mapPosition = gridPosition * 42;
            state = 0;
            animation = new Animation("etc/11-1.Animation",
                    mapPosition, (int)gridPosition.Y, 18, 20);
            animation.original = new Vector2(27, 50);
            animation.delay = 60;
            animation.PlayAnimation(1, 2);
        }
        public void RefreshIcon()
        {
            if (Kind == PowerKind.SPEED_BOOST)
            {
                animation.PlayAnimation(3, 4);
            }
            else if (Kind == PowerKind.MAX_BOOM_BOOST)
            {
                animation.PlayAnimation(2, 3);
            }
            else if (Kind == PowerKind.FIRE_BOOST)
            {
                animation.PlayAnimation(1, 2);
            }
        }
        public override void Update()
        {
            base.Update();
            if (animation.isStop) state = 1;
        }
        public void Kill()
        {
            animation.isLoop = false;
            state = 2;
            //animation.newAnimation(1, 1);
        }
    }
}
