using Microsoft.Xna.Framework;

namespace Pong.Core.GameContent
{
    public class Ball
    {
        public Vector2 Position;
        public Rectangle Hitbox;

        public Ball(Vector2 position)
        {
            Position = position;
        }
    }
}