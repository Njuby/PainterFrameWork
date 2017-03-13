using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace PainterFramework
{
    class PaintCan : ThreeColorGameObject
    {
        SpriteSheet currentSprite;
        protected Color targetColor;
        protected float minVelocity;
        protected float positionOffset;

        public PaintCan(float positionOffset, Color targetcol)
            : base("spr_can_red", "spr_can_green", "spr_can_BLue")
        {
            //start waarde om error te voorkomen
            currentSprite = new SpriteSheet("spr_can_blue");
            sprite = currentSprite;
            this.positionOffset = positionOffset;
            this.targetColor = targetcol;

            minVelocity = 30;
            this.Reset();
        }

        public override void Reset()
        {
            base.Reset();
            {
                position = new Vector2(this.positionOffset, -BoundingBox.Height);
                velocity = Vector2.Zero;
            }
        }

        //UPDATE
        public override void Update(GameTime gameTime)
        {
            if (velocity.Y == 0.0f && GameEnvironment.Random.NextDouble() < 0.01)
            {
                velocity = CalculatedRandomVelocity();
                Color = CalculatedRandomColor();
            }

            //Gameworld is as property of all GameObjects referencing the root parentobject
            PainterGameWorld pgw = GameWorld as PainterGameWorld;
            //when the cans drops down the screen and color matches get 10 points else lose 1 life
            if (pgw.IsOutsideGameWorld(GlobalPosition))
            {
                if (color == targetColor)
                {
                    pgw.Score += 10;
                    //Painter.AssetManager.PlaySound("snd_collect_points");
                }
                else
                {
                    pgw.Lives--;
                }
                Reset();
            }

            minVelocity += 0.001f; 
            base.Update(gameTime);
        }

        public Vector2 CalculatedRandomVelocity()
        {
            return new Vector2(0.0f, (float)GameEnvironment.Random.NextDouble() * 30 + minVelocity);
        }

        public Color CalculatedRandomColor()
        {
            int randomval = GameEnvironment.Random.Next(3);
            if (randomval == 0)
                return Color.Red;
            else if (randomval == 1)
                return Color.Green;
            else 
                return Color.Blue;
        }
    }
}
