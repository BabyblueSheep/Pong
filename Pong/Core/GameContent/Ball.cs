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

        public void RandomStart()
        {
            Random rd = new Random();
            rd2 = rd.Next(0, 2);

            switch (rd2)
            {
                case 0:
                    Velocity.X = -3f;
                    Velocity.Y = 3f;
                    break;
                case 1:
                    Velocity.X = -3f;
                    Velocity.Y = -3f;
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
                bounce = 0;
            }
            if (Hitbox.Intersects(enemypaddle.Hitbox) && bounce == 0)
            {
                Velocity.X = -Velocity.X;
                bounce = 1;
            }
        }

        public void Return(Game width)
        {
            if (Position.X <= 0)
            {
                Position = new Vector2(width.GraphicsDevice.Viewport.Width / 2, width.GraphicsDevice.Viewport.Height / 2);
                RandomStart();
            }
        }
    }
}