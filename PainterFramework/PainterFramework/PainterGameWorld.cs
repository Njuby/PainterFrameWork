using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PainterFramework
{
    class PainterGameWorld : GameObjectList
    {
        private SpriteGameObject backround = null;
        private RotatableSpriteObject cannonBarrel = null;
        private ThreeColorGameObject cannonColor = null;
        private ThreeColorGameObject can1 = null, can2 = null, can3 = null;
        private TextGameObject scoreText;
        private GameObjectList livesSprites;
        private int maxLives;
        private int score;
        private int lives;
        Ball ball = new Ball();
        private SpriteGameObject scoreBoard;


        public PainterGameWorld()
        {

            //create objects
            backround = new SpriteGameObject("spr_background");
            cannonBarrel = new RotatableSpriteObject("spr_cannon_barrel");
            cannonBarrel.Position = new Vector2(74, 404);
            cannonBarrel.Origin = new Vector2(34, 34);
            scoreBoard = new SpriteGameObject("spr_scorebar");
            livesSprites = new GameObjectList();
            livesSprites.Position = new Vector2(0, 16);

            ball = new Ball();

            cannonColor = new ThreeColorGameObject("spr_cannon_red", "spr_cannon_green", "spr_cannon_blue");
            cannonColor.Position = new Vector2(58, 388);
            //start waarde geven om error te voorkomen.
            cannonColor.Color = Color.Blue;
            
            can1 = new PaintCan(450f, Color.Red);
            can2 = new PaintCan(575f, Color.Green);
            can3 = new PaintCan(700f, Color.Blue);

            scoreText = new TextGameObject("GameFont");
            scoreText.Position = new Vector2(8, 8);


            //add objects
            this.Add(backround);
            
            this.Add(cannonBarrel);
            this.Add(cannonColor);
          
            this.Add(can1);
            this.Add(can2);
            this.Add(can3);

            this.Add(scoreBoard);
            this.Add(scoreText);

            this.Add(ball);

            //give values
            this.score = 0;
            scoreText.Text = "Score: " + "0";
            this.lives = 5;
            this.maxLives = lives;

            for (int lifeNr = 0; lifeNr < maxLives; lifeNr++)
            {
                SpriteGameObject life = new SpriteGameObject("spr_lives", 0, lifeNr.ToString());
                life.Position = new Vector2(lifeNr * life.BoundingBox.Width, 30);
                livesSprites.Add(life);
            }

           this.Add(livesSprites);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            //manage cannonBarrelColor
            if (inputHelper.KeyPressed(Keys.R))
                cannonColor.Color = Color.Red;
            else if (inputHelper.KeyPressed(Keys.G))
                cannonColor.Color = Color.Green;
            else if (inputHelper.KeyPressed(Keys.B))
                cannonColor.Color = Color.Blue;

            //calculate angle for shooting
            double opposite = inputHelper.MousePosition.Y - cannonBarrel.GlobalPosition.Y;
            double adjectent = inputHelper.MousePosition.X - cannonBarrel.GlobalPosition.X;
            cannonBarrel.Angle = (float)Math.Atan2(opposite, adjectent);

            if (inputHelper.MouseLeftButtonPressed() && !ball.Shooting)
            {
                ball.Shoot(inputHelper, cannonColor, cannonBarrel);
            }
        }
        
        //calculates score
        public int Score
        {
            get { return score; }
            set
            {
                score = value;
                if (scoreText != null)
                    scoreText.Text = "Score: " + value;
            }
        }
        //calculates lives
        public int Lives
        {
            get { return lives; }
            set
            {
                if (value > maxLives)
                    return;

                //only amount of lifes numbre sprites are visible
                for (int lifeNr = 0; lifeNr < maxLives; lifeNr++)
                {
                    SpriteGameObject sgo = (SpriteGameObject)livesSprites.Find(lifeNr.ToString());
                    sgo.Visible = (lifeNr < value);
                }
                lives = value;
            }
        }

        public bool IsOutsideGameWorld(Vector2 aPosition)
        {
            //return true when following gives true
            return aPosition.X < 0 || aPosition.X > Painter.Screen.X || aPosition.Y > Painter.Screen.Y;
        }

        public override void Update(GameTime gameTime)
        {
            if (ball.CollidesWith(can1))
            {
                can1.Color = ball.Color;
                ball.Reset();
            }
            if (ball.CollidesWith(can2))
            {
                can2.Color = ball.Color;
                ball.Reset();
            }
            if (ball.CollidesWith(can3))
            {
                can3.Color = ball.Color;
                ball.Reset();
            }

            if (lives <= 0)
            {
                Painter.GameStateManager.SwitchTo("GameOverState");
                lives = 5;
                score = 0;
                scoreText.Text = "score: " + score;
            }

            base.Update(gameTime);
        }
    }
}
