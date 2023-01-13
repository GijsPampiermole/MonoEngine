﻿using Engine.Src.Engine.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using System;
using System.Collections.Generic;

namespace Engine.Src.Scenes
{
    internal class MainMenu : GameScreen
    {
        private new Game1 Game => (Game1)base.Game;

        private SpriteBatch _spriteBatch;

        private readonly UIManager _ui = new();
        private readonly ButtonFunctions _btnF = new();

        TiledMap _tiledMap;
        TiledMapRenderer _tiledMapRenderer;
        public TiledMapObjectLayer ButtonLayer { get; private set; } = null;
        private List<Rectangle> buttonObjects;

        public MainMenu(Game game) : base(game) 
        {

        }

        public override void LoadContent()
        {
            _tiledMap = Content.Load<TiledMap>("MainMenu");
            _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);

            ButtonLayer = _tiledMap.GetLayer<TiledMapObjectLayer>("Buttons");

            buttonObjects = new List<Rectangle>();

            _ui.AddButton(new(200, 200), new(400, 400), 1).OnClick += _btnF.Quit;

            foreach (var o in ButtonLayer.Objects)
            {
                
            }

            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        public override void Update(GameTime gameTime)
        {
            _ui.Update();
            //_tiledMapRenderer.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.Black);
            _ui.Draw();
            //_tiledMapRenderer.Draw();
        }
    }
}
