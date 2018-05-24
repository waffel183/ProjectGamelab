using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ConcentratieGame
{
    public class Ball
    {
        private GraphicsDeviceManager _graphics;
        private Texture2D _texture;
        private Color _color;
        private Vector2 _position = new Vector2(100, 0);
        private float _x, _y, _concentrationValue;

        public Texture2D Texture { set { _texture = value; } }

        public Ball(float x, float y, Color color, GraphicsDeviceManager graphics)
        {
            this._x = x;
            this._y = y;
            this._color = color;
            this._graphics = graphics;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_texture, new Vector2(_x, _y), _color);
            spriteBatch.End();
        }

        public void Update()
        {
            this._x = _position.X;
            this._y = _position.Y;
            //_graphics.PreferredBackBufferWidth = 100;
            //_graphics.PreferredBackBufferHeight = 500;
        }
    }
}