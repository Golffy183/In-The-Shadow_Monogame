﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace In_The_Shadow
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public GameplayScreen mGameplayScreen;
        public GameplayScreen2 mGameplayScreen2;
        public TitleScreen mTitleScreen;
        public screen mCurrentScreen;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            IsMouseVisible = true;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            mGameplayScreen = new GameplayScreen(this, new EventHandler(GameplayScreenEvent));
            mGameplayScreen2 = new GameplayScreen2(this, new EventHandler(GameplayScreenEvent));
            mTitleScreen = new TitleScreen(this, new EventHandler(GameplayScreenEvent));
            mCurrentScreen = mGameplayScreen;
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            mCurrentScreen.Update(gameTime);
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            mCurrentScreen.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        public void GameplayScreenEvent(object obj, EventArgs e)
        {
            mCurrentScreen = (screen)obj;
        }
    }
}