using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PortalSokoban
{
    public class PortalSokobanGame : Game
    {

        private Board board;

        public const int GAME_WIDTH = 1920;
        public const int GAME_HEIGHT = 1080;
        public const int GAME_UPSCALE_FACTOR = 1;

        private float dt;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        InputSystem inputSystem;
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
            //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
            // TODO: Add your initialization logic here
            inputSystem = new InputSystem();
            board = new Board(Content, 32, 18);
            base.Initialize();
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
            dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            // TODO: Add your update logic here
            inputSystem.Update(dt);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);
            Matrix matrix = Matrix.CreateScale(GAME_UPSCALE_FACTOR);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: matrix);

            // TODO: Add your drawing code here

            board.Draw(_spriteBatch, new Vector2(GAME_WIDTH / 2, GAME_HEIGHT / 2));
            _spriteBatch.End();
            base.Draw(gameTime);

        }
    }
}