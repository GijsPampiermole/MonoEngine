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

        private ScreenManager _screenManager;

        private OrthographicCamera _camera;
        private Vector2 _cameraPosition;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();

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

        private void LoadGrassland()
        {
            _screenManager.LoadScreen(new Grassland(this), new FadeTransition(GraphicsDevice, Color.Black));
        }

        private void LoadStoneMap()
        {
            _screenManager.LoadScreen(new StoneMap(this), new FadeTransition(GraphicsDevice, Color.Black));
        }

        private Vector2 GetMovementDirection()
        {
            var movementDirection = Vector2.Zero;
            var state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Down))
            {
                movementDirection += Vector2.UnitY;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                movementDirection -= Vector2.UnitY;
            }
            if (state.IsKeyDown(Keys.Left))
            {
                movementDirection -= Vector2.UnitX;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                movementDirection += Vector2.UnitX;
            }

            // Can't normalize the zero vector so test for it before normalizing
            if (movementDirection != Vector2.Zero)
            {
                movementDirection.Normalize();
            }

            return movementDirection;
        }

        private void MoveCamera(GameTime gameTime)
        {
            var speed = 200;
            var seconds = gameTime.GetElapsedSeconds();
            var movementDirection = GetMovementDirection();
            _cameraPosition += movementDirection * seconds * speed;
            _cameraPosition.Y = Convert.ToInt32(_cameraPosition.Y);
            _cameraPosition.X = Convert.ToInt32(_cameraPosition.X);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            var viewportadapter = new BoxingViewportAdapter(Window, GraphicsDevice, 800, 600);
            _camera = new OrthographicCamera(viewportadapter);
            GlobalVariables._camera = _camera;
            _cameraPosition.X = 400;
            _cameraPosition.Y = 300;

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

            MoveCamera(gameTime);
            _camera.LookAt(_cameraPosition);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(blendState: BlendState.AlphaBlend);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}