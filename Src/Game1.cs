using Engine.Src.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;

namespace Engine.Src
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private ScreenManager _screenManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _screenManager = new ScreenManager();
            Components.Add(_screenManager);
        }

        private void LoadMainMenu()
        {
            _screenManager.LoadScreen(new MainMenu(this), new FadeTransition(GraphicsDevice, Color.Black));
        }

        private void LoadVillage()
        {
            _screenManager.LoadScreen(new Village(this), new FadeTransition(GraphicsDevice, Color.Black));
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            LoadMainMenu();
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

            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.E))
            {
                LoadMainMenu();
            }
            else if (keyboardState.IsKeyDown(Keys.F))
            {
                LoadVillage();
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}