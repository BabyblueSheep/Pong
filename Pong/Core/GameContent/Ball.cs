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

        public Ball(Rectangle hitbox)
        {
            hitbox = new Rectangle((int)Position.X, (int)Position.Y, Hitbox.X, Hitbox.Y);
        }

        public void RandomStart()
        {
            Random rd = new Random();
            rd2 = rd.Next(0, 4);

            switch (rd2)
            {
                case 0:
                    Velocity.X = 5f;
                    Velocity.Y = 5f;
                    break;
                case 1:
                    Velocity.X = -5f;
                    Velocity.Y = 5f;
                    break;
                case 2:
                    Velocity.X = 5f;
                    Velocity.Y = -5f;
                    break;
                case 3:
                    Velocity.X = -5f;
                    Velocity.Y = -5f;
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

        public void BouncePaddle()
        {

        }
    }
}