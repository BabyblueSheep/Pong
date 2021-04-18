using Microsoft.Xna.Framework;
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
            PlayerPaddle = new PaddleClass();
            EnemyPaddle = new PaddleClass();
            Ball = new Ball();

            PlayerPaddle.Position = new Vector2(10, GraphicsDevice.Viewport.Height / 2);
            EnemyPaddle.Position = new Vector2(GraphicsDevice.Viewport.Width - 36, GraphicsDevice.Viewport.Height / 2);

            Ball.Position =  new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);

            Ball.RandomStart();

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

            PlayerPaddle.Hitbox = new Rectangle((int)PlayerPaddle.Position.X, (int)PlayerPaddle.Position.Y, 16, 70);
            EnemyPaddle.Hitbox = new Rectangle((int)EnemyPaddle.Position.X, (int)EnemyPaddle.Position.Y, 16, 70);

            Ball.Hitbox = new Rectangle((int)Ball.Position.X, (int)Ball.Position.Y, 16, 16);

            PlayerPaddle.PlayerMove(this);
            EnemyPaddle.EnemyMove(this);

            Ball.Move();
            Ball.Bounce(this);
            Ball.BouncePaddle(PlayerPaddle, EnemyPaddle);
            Ball.Return(this);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            spriteBatch.Draw(paddle, PlayerPaddle.Hitbox, Color.White);
            spriteBatch.Draw(ball, Ball.Hitbox, Color.White);
            spriteBatch.Draw(paddle, EnemyPaddle.Hitbox, Color.White);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
