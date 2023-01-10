using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace Engine.Src.Scenes
{
    internal class StoneMap : GameScreen
    {
        private new Game1 Game => (Game1)base.Game;

        private SpriteBatch _spriteBatch;

        TiledMap _tiledMap;
        TiledMapRenderer _tiledMapRenderer;

        public StoneMap(Game game) : base(game) { }

        public override void LoadContent()
        {
            _tiledMap = Content.Load<TiledMap>("Stonemap");
            _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);

            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        public override void Update(GameTime gameTime)
        {
            _tiledMapRenderer.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.Black);
            _tiledMapRenderer.Draw(GlobalVariables._camera.GetViewMatrix());
        }
    }
}