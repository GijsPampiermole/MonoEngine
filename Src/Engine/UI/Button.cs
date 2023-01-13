using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Tiled;
using System;

namespace Engine.Src.Engine.UI
{
    internal class Button
    {
        private TiledMapObject _object;
        private Vector2 _position;
        private readonly Rectangle _rect, _destrect;
        private Color _shade = Color.White;
        private readonly float _layerDepth;
        private SpriteBatch SpriteBatch;

        public event EventHandler OnClick;
        private Texture2D _transparant;

        public Button(Vector2 p, TiledMapObject o, float d, Texture2D i)
        {
            _object = o;
            _position = p;
            _destrect = new Rectangle((int)_position.X, (int)_position.Y, (int)o.Size.Width, (int)o.Size.Height);
            _rect = new((int)p.X, (int)p.Y, (int)o.Size.Width, (int)o.Size.Height);
            _layerDepth = d / 100;
            _transparant = i;
        }

        private void Click()
        {
            OnClick?.Invoke(this, EventArgs.Empty);
        }

        public void Update()
        {
            if(GlobalVariables.MouseCursor.Intersects(_rect))
            {
                _shade = Color.DarkGray;
                if(GlobalVariables.Clicked)
                {
                    Click();
                }
            }
        }

        public void Draw()
        {
            GlobalVariables.SpriteBatch.Begin();
            GlobalVariables.SpriteBatch.Draw(_transparant, _destrect, null, _shade, 0.0f, Vector2.Zero, SpriteEffects.None, _layerDepth);
            GlobalVariables.SpriteBatch.End();
        }
    }
}
