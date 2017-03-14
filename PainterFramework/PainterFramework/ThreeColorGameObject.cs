using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace PainterFramework
{
    class ThreeColorGameObject : RotatableSpriteObject
    {
        protected SpriteSheet colorRedSprite, colorGreenSprite, colorBlueSprite;
        protected Color color;

        public ThreeColorGameObject(string redAssetName, string greenAssetName, string blueAssetName) : base("")
        {
            //all colors
            colorRedSprite = new SpriteSheet(redAssetName);
            colorGreenSprite = new SpriteSheet(greenAssetName);
            colorBlueSprite = new SpriteSheet(blueAssetName);
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
                    this.sprite = colorRedSprite;
                else if (color == Color.Green)
                    this.sprite = colorGreenSprite;
                else if (color == Color.Blue)
                    this.sprite = colorBlueSprite;
            }
        }
    }
}
