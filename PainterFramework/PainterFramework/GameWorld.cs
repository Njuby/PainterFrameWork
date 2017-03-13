using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PainterFramework
{
    class GameWorld : GameObjectList
    {
        private SpriteGameObject backround = null;
        private RotatableSpriteObject cannonBarrel = null;
        private ThreeColorGameObject cannonColor = null;
        private ThreeColorGameObject can1 = null, can2 = null, can3 = null;

        public GameWorld()
        {
            backround = new SpriteGameObject("spr_background");
            cannonBarrel = new RotatableSpriteObject("spr_cannon_barrel");
            cannonBarrel.Position = new Vector2(74, 404);
            cannonBarrel.Origin = new Vector2(34, 34);

            cannonColor = new ThreeColorGameObject("spr_cannon_red", "spr_cannon_green", "spr_cannon_blue");
            cannonColor.Position = new Vector2(58, 388);
            //start waarde geven om error te voorkomen.
            cannonColor.Color = Color.Blue;

            can1 = new PaintCan(450f, Color.Red);
            can2 = new PaintCan(575f, Color.Green);
            can3 = new PaintCan(700f, Color.Blue);    

            this.Add(backround);
            this.Add(cannonBarrel);
            this.Add(cannonColor);
            this.Add(can1);
            this.Add(can2);
            this.Add(can3);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.KeyPressed(Keys.R))
                cannonColor.Color = Color.Red;
            else if (inputHelper.KeyPressed(Keys.G))
                cannonColor.Color = Color.Green;
            else if (inputHelper.KeyPressed(Keys.B))
                cannonColor.Color = Color.Blue;

            double opposite = inputHelper.MousePosition.Y - cannonBarrel.GlobalPosition.Y;
            double adjectent = inputHelper.MousePosition.X - cannonBarrel.GlobalPosition.X;
            cannonBarrel.Angle = (float)Math.Atan2(opposite, adjectent);
        }

       

    }
}
