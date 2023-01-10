using Microsoft.Xna.Framework;
using MonoGame.Extended.Screens;

namespace Engine.Src.Scenes
{
    internal class Village : GameScreen
    {
        private new Game1 Game => (Game1)base.Game;

        public Village(Game game) : base(game) { }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.LightCoral);
        }
    }
}
