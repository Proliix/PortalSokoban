﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PortalSokoban
{
    public class PortalSokobanGame : Game
    {

        private Board board;
        
        const int GAME_WIDTH = 640;
        const int GAME_HEIGHT = 360;
        const int GAME_UPSCALE_FACTOR = 3;



        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public PortalSokobanGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferHeight = GAME_HEIGHT * GAME_UPSCALE_FACTOR;
            _graphics.PreferredBackBufferWidth = GAME_WIDTH * GAME_UPSCALE_FACTOR;
            _graphics.ApplyChanges();
            // TODO: Add your initialization logic here

            base.Initialize();
            board = new Board(Content,32,18);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            // TODO: Add your drawing code here

            board.Draw(_spriteBatch, new Vector2(GAME_WIDTH / 2, GAME_HEIGHT / 2));
            base.Draw(gameTime);
            
        }
    }
}