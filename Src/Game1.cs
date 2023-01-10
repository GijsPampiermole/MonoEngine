using Engine.Src.Engine;
using Engine.Src.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using MonoGame.Extended.ViewportAdapters;
using System;

namespace Engine.Src
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private OrthographicCamera _camera;

        private ScreenManager _screenManager;
        Camera _cam = new Camera();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 960;
            _graphics.PreferredBackBufferHeight = 640;
            _graphics.ApplyChanges();

            _screenManager = new ScreenManager();
            Components.Add(_screenManager);
        }

        public void LoadMainMenu()
        {
            _screenManager.LoadScreen(new MainMenu(this), new FadeTransition(GraphicsDevice, Color.Black));
        }

        public void LoadVillage()
        {
            _screenManager.LoadScreen(new Village(this), new FadeTransition(GraphicsDevice, Color.Black));
        }

        public void LoadGrassland()
        {
            _screenManager.LoadScreen(new Grassland(this), new FadeTransition(GraphicsDevice, Color.Black));
        }

        public void LoadStoneMap()
        {
            _screenManager.LoadScreen(new StoneMap(this), new FadeTransition(GraphicsDevice, Color.Black));
            _cam.setCameraPos(480, 320);
        }

        protected override void Initialize()
        {
            // Add camera and set base position
            var viewportadapter = new BoxingViewportAdapter(Window, GraphicsDevice, 960, 640);
            _camera = new OrthographicCamera(viewportadapter);
            GlobalVariables._camera = _camera;
            _cam.setCameraPos(0, 0);

            base.Initialize();
            LoadMainMenu();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
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
            else if (keyboardState.IsKeyDown(Keys.R))
            {
                LoadVillage();
            }
            else if (keyboardState.IsKeyDown(Keys.T))
            {
                LoadGrassland();
            }
            else if (keyboardState.IsKeyDown(Keys.Y))
            {
                LoadStoneMap();
            }

            _cam.MoveCamera(gameTime);
            _camera.LookAt(GlobalVariables._cameraPosition);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(blendState: BlendState.AlphaBlend);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}