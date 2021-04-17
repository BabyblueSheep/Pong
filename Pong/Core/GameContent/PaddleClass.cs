using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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
        public void Move(Game height)
        {
            if ((Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up)) && Position.Y != 0)
            {
                Position.Y -= 2;
            }
            if ((Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down)) && Position.Y != height.GraphicsDevice.Viewport.Height - 70)
            {
                Position.Y += 2;
            }
        }
    }
}