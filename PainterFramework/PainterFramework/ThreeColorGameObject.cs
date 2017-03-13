using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace PainterFramework
{
    class ThreeColorGameObject : SpriteGameObject
    {
        protected SpriteSheet colorRed, colorGreen, colorBlue;
        protected Color color;

        public ThreeColorGameObject(string redAssetName, string greenAssetName, string blueAssetName) : base("")
        {
            //all colors
            colorRed = new SpriteSheet(redAssetName);
            colorGreen = new SpriteSheet(greenAssetName);
            colorBlue = new SpriteSheet(blueAssetName);
            //starting color
            Color = Color.Blue;
        }

        public override void Reset()
        {
            base.Reset();

            Color = Color.Blue;
        }

        public Color Color
        {
            get { return color; }
            set
            {
                //set value to color and A given Color to color(variable)
                if (value != Color.Red && value != Color.Green && value != Color.Blue)
                    return;
                color = value;
                if (color == Color.Red)
                    sprite = colorRed;
                else if (color == Color.Green)
                    sprite = colorGreen;
                else if (color == Color.Blue)
                    sprite = colorBlue;
            }
        }
    }
}
