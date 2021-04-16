﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Core.GameContent;

namespace Pong.Core
{
    public class Game1 : Game
    {
        public Texture2D paddle;
        public Texture2D ball;

        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public PaddleClass PlayerPaddle;
        public PaddleClass EnemyPaddle;
        public Ball Ball;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            PlayerPaddle = new PaddleClass(new Rectangle(10, GraphicsDevice.Viewport.Height / 2, 16, 70));
            EnemyPaddle = new PaddleClass(new Rectangle(GraphicsDevice.Viewport.Width - 36, GraphicsDevice.Viewport.Height / 2, 16, 70));
            Ball = new Ball(new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2));

            PlayerPaddle.Position = new Vector2(10, GraphicsDevice.Viewport.Height / 2);
            EnemyPaddle.Position = new Vector2(GraphicsDevice.Viewport.Width - 36, GraphicsDevice.Viewport.Height / 2);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            paddle = Content.Load<Texture2D>("paddle");
            ball = Content.Load<Texture2D>("ball");
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if ((Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up)) && PlayerPaddle.Position.Y != 0)
            {
                PlayerPaddle.Position.Y -= 2;
            }
            if ((Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down)) && PlayerPaddle.Position.Y != GraphicsDevice.Viewport.Height - 70)
            {
                PlayerPaddle.Position.Y += 2;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            spriteBatch.Draw(paddle, PlayerPaddle.Position, Color.White);
            spriteBatch.Draw(ball, Ball.Position, Color.White);
            spriteBatch.Draw(paddle, EnemyPaddle.Position, Color.White);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}