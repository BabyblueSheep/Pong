using Microsoft.Xna.Framework;

namespace Pong.Core.GameContent
{
    public class PaddleClass
    {
        public Vector2 Position;
        public Rectangle Hitbox;

        public PaddleClass(Rectangle hitbox)
        {
            hitbox = new Rectangle((int)Position.X, (int)Position.Y, Hitbox.X, Hitbox.Y);
        }
    }
}