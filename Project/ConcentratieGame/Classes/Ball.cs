using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ConcentratieGame
{
    public class Ball
    {
        private GraphicsDeviceManager _graphics;
        private Texture2D _texture;
        private Color _color;
        private Vector2 _position;
        private float _x, _y, _concentrationValue;

        public Texture2D Texture { get { return _texture; } set { _texture = value; } }
        public Color Color { get { return _color; } set { _color = value; } }
        public Vector2 Position { get { return _position; } set { _position = value; } }

        public Ball(float x, float y, Color color, GraphicsDeviceManager graphics)
        {
            this.Position = new Vector2(x, y);
            this.Color = color;
            this._graphics = graphics;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_texture, new Vector2(_x, _y), Color);
            spriteBatch.End();
        }

        public void Update()
        {
            _x = Position.X;
            _y = Position.Y;
            //_graphics.PreferredBackBufferWidth = 100;
            //_graphics.PreferredBackBufferHeight = 500;
        }
    }
}