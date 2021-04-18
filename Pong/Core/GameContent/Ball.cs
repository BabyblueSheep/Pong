using Microsoft.Xna.Framework;
using System;

namespace Pong.Core.GameContent
{
    public class Ball
    {
        public static Vector2 Position;
        public Rectangle Hitbox;
        public Vector2 Velocity;

        int rd2;
        int bounce = 1;
        int counter = 0;

        public void RandomStart()
        {
            Random rd = new Random();
            rd2 = rd.Next(0, 4);

            switch (rd2)
            {
                case 0:
                    Velocity.X = 3f;
                    Velocity.Y = 3f;
                    bounce = 0;
                    break;
                case 1:
                    Velocity.X = 3f;
                    Velocity.Y = -3f;
                    bounce = 0;
                    break;
                case 2:
                    Velocity.X = -3f;
                    Velocity.Y = 3f;
                    bounce = 1;
                    break;

                case 3:
                    Velocity.X = -3f;
                    Velocity.Y = -3f;
                    bounce = 1;
                    break;
            }
        }

        public void Bounce(Game height)
        {
            if ((Position.Y <= 0) || (Position.Y >= (height.GraphicsDevice.Viewport.Height - 16)))
            {
                Velocity.Y = -Velocity.Y;
            }
        }

        public void Move()
        {
            Position.X += Velocity.X;
            Position.Y += Velocity.Y;
        }

        public void BouncePaddle(PaddleClass playerpaddle, PaddleClass enemypaddle)
        {
            if (Hitbox.Intersects(playerpaddle.Hitbox) && bounce == 1)
            {
                Velocity.X = -Velocity.X;
                if (Velocity.X != 11f && counter > 5)
                {
                    Velocity.X += 1f;
                    counter = 1;
                }
                if (Velocity.Y != 11f && counter > 5)
                {
                    Velocity.Y += 1f;
                    counter = 1;
                }
                bounce = 0;
                counter += 1;
            }
            if (Hitbox.Intersects(enemypaddle.Hitbox) && bounce == 0)
            {
                Velocity.X = -Velocity.X;
                if (Velocity.X != -18f && counter > 5)
                {
                    Velocity.X -= 1f;
                    counter = 1;
                }
                if (Velocity.Y != -18f && counter > 5)
                {
                    Velocity.Y -= 1f;
                    counter = 1;
                }
                bounce = 1;
                counter += 1;
            }
        }

        public void Return(Game width, Score score)
        {
            if (Position.X <= 0)
            {
                Position = new Vector2(width.GraphicsDevice.Viewport.Width / 2, width.GraphicsDevice.Viewport.Height / 2);
                Velocity = new Vector2(3f, 3f);
                score.enemyscore++;
                RandomStart();
            }
            if (Position.X >= width.GraphicsDevice.Viewport.Width)
            {
                Position = new Vector2(width.GraphicsDevice.Viewport.Width / 2, width.GraphicsDevice.Viewport.Height / 2);
                Velocity = new Vector2(3f, 3f);
                score.playerscore++;
                RandomStart();
            }

        }
    }
}