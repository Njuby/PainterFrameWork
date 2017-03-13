using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PainterFramework
{
    class Ball : ThreeColorGameObject
    {
        public bool Shooting { get; set; }

        public Ball()
            : base ("spr_ball_red", "spr_ball_green", "spr_ball_blue")
        {
            this.Reset();
        }

        public override void Reset()
        {
            base.Reset();
            visible = false;
            velocity = Vector2.Zero;
            Shooting = false;
        }

        public override void Update(GameTime gameTime)
        {
            if (Shooting)
            {
                velocity.X *= 0.99f;
                velocity.Y += 6;
            }

            PainterGameWorld pgw = GameWorld as PainterGameWorld;
            if (pgw.IsOutsideGameWorld(GlobalPosition))
                Reset();

            base.Update(gameTime);
        }

        public void Shoot(InputHelper inputhelper, ThreeColorGameObject cannonColor, RotatableSpriteObject cannonBarrel)
        {
            Shooting = true;
            Color = cannonColor.Color;

            velocity = (inputhelper.MousePosition - cannonColor.GlobalPosition) * 1.2f;
            float opp = (float)Math.Sin(cannonBarrel.Angle) * cannonBarrel.Width * 0.6f;
            float adj = (float)Math.Cos(cannonBarrel.Angle) * cannonBarrel.Width * 0.6f;
            position = cannonColor.Position + new Vector2(adj, opp) + new Vector2(3, 3);
            visible = true;

            //Painter.AssetManager.PlaySound("snd_shoot_paint");
        }
    }
}
