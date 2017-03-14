using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PainterFramework
{
    class GameOver : GameObjectList
    {
        private TextGameObject gameOver;
        private TextGameObject reStart;

        public GameOver()
        {
            gameOver = new TextGameObject("gameFont");
            gameOver.Position = new Vector2(10, 50);

            reStart = new TextGameObject("gameFont");
            reStart.Position = new Vector2(10, 70);

            this.Add(gameOver);
            this.Add(reStart);

            gameOver.Text = "Game Over Dude! Game Over!";
            reStart.Text = "Press 'SPACE' to restart";
        }

       
       

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.KeyPressed(Keys.Space))
            {
                Painter.GameStateManager.SwitchTo("playingState");
            }
            base.HandleInput(inputHelper);
        }
    }
}
