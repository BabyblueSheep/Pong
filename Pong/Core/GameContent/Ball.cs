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
    }
}