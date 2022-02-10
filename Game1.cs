using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace GameObject_Proof_of_Concept
{
    public class Game1 : Game
    {
        // image content
        Texture2D RedSquare;

        // objects
        List<GameObject> GameObjects;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            GameObjects = new List<GameObject>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            RedSquare = Content.Load<Texture2D>("RedSquare");
            CreatePlayer();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (GameObject go in GameObjects)
            {
                go.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            foreach (GameObject go in GameObjects)
            {
                go.Draw();
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        protected void CreatePlayer()
        {
            GameObject player = new GameObject();
            
            // add transform first since the other things depend on it.
            Transform tr = new Transform(player, new Point(300, 300));
            player.AddComponent(tr);

            SpriteRenderer sr = new SpriteRenderer(player, _spriteBatch, RedSquare);
            player.AddComponent(sr);

            this.GameObjects.Add(player);
        }
    }
}
