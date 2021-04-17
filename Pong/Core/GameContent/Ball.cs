using Microsoft.Xna.Framework;

namespace Pong.Core.GameContent
{
    public class Ball
    {
        public Vector2 Position;
        public Rectangle Hitbox;
        public Vector2 Velocity;

        public Ball(Rectangle hitbox)
        {
            hitbox = new Rectangle((int)Position.X, (int)Position.Y, Hitbox.X, Hitbox.Y);
        }

        public void Bounce(Game height)
        {
            if (Position.Y <= 0)
            {
                Velocity.Y = Velocity.Y;
            }
            if (Position.Y >= (height.GraphicsDevice.Viewport.Height - 16))
            {
                Velocity.Y = -Velocity.Y;
            }
        }

        public void Move()
        {
            Position.X += Velocity.X;
            Position.Y += Velocity.Y;
        }
    }
}