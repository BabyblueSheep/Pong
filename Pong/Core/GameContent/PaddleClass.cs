using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pong.Core.GameContent
{
    public class PaddleClass
    {
        public Vector2 Position;
        public Rectangle Hitbox;

        public PaddleClass()
        {
        }
        public void PlayerMove(Game height)
        {
            if ((Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up)) && Position.Y != 0)
            {
                Position.Y -= 3;
            }
            if ((Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down)) && Position.Y != height.GraphicsDevice.Viewport.Height - 70)
            {
                Position.Y += 3;
            }
        }

        public void EnemyMove(Game height)
        {
            if ((Ball.Position.Y >= Position.Y) && Position.Y <= height.GraphicsDevice.Viewport.Height - 70)
            {
                Position.Y += 3;
            }
            if ((Ball.Position.Y <= Position.Y) && Position.Y >= 0)
            {
                Position.Y -= 3;
            }
        }
    }
}