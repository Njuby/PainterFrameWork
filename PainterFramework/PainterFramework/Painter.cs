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
            //voor
            //graphics = new GraphicsDeviceManager(this);
            //Content.RootDirectory = "Content";
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            Console.Write("Loading content");

            GameStateManager.AddGameState("playingState", new GameWorld());
            GameStateManager.SwitchTo("playingState");

            AssetManager.PlayMusic("snd_music");
        }
    }
}
