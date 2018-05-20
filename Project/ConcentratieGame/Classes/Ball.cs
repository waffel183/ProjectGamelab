using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ConcentratieGame
{
    public class Ball
    {
        private Texture2D _texture;
        private Color color;
        private float _x, _y;

        public Texture2D Texture { set { _texture = value; } }

        public Ball(float x, float y, Color color)
        {
            this._x = x;
            this._y = y;
            this.color = color;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_texture, new Vector2(_x, _y), color);
            spriteBatch.End();
        }
    }
}