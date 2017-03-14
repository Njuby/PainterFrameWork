using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PainterFramework
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Painter : GameEnvironment
    {
        //GraphicsDeviceManager graphics;
        //SpriteBatch spriteBatch;

        public Painter()
        {
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            //load background
            base.LoadContent();
            //Console.Write("Loading content");
            screen = new Point(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            //add gamestate
            GameStateManager.AddGameState("playingState", new PainterGameWorld());
            GameStateManager.AddGameState("GameOverState", new GameOver());
            GameStateManager.AddGameState("StartState", new StartState());

            //default gamestate
            GameStateManager.SwitchTo("StartState");
            //play music
            //AssetManager.PlayMusic("snd_music");
        }
    }
}
