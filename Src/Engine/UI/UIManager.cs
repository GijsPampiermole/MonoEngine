using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Src.Engine.UI
{
    internal class UIManager
    {
        private Texture2D ButtonTexture { get; set; }
        private readonly List<Button> _buttons = new();
        private Texture2D transparantTexture2D;

        public UIManager() { }

        public Button AddButton(Vector2 pos, TiledMapObject o, int depth)
        {
            transparantTexture2D = GlobalVariables.Content.Load<Texture2D>("Transparant");
            Button b = new(pos, o, depth, transparantTexture2D);
            _buttons.Add(b);

            return b;
        }

        public void Update()
        {
            foreach(var item in _buttons)
            {
                item.Update();
            }
        }
        
        public void Draw()
        {
            foreach(var item in _buttons)
            {
                item.Draw();
            }
        }
    }
}