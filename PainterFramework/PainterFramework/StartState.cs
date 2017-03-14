using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PainterFramework
{
    class StartState : GameObjectList
    {
        private TextGameObject start;
        //private TextGameObject reStart;

        public StartState()
        {
            start = new TextGameObject("gameFont");
            start.Position = new Vector2(10, 50);
            //reStart = new TextGameObject("gameFont");

            this.Add(start);
            //this.Add(reStart);

            start.Text = "Press 'SPACE' to Start";
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if(inputHelper.KeyPressed(Keys.Space))
            {
                Painter.GameStateManager.SwitchTo("playingState");
            }
            base.HandleInput(inputHelper);
        }
    }
}
