using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace ConcentratieGame
{
    public class Ball
    {
        private GraphicsDeviceManager _graphics;
        private Texture2D _texture;
        private Color _color;
        private Vector2 _position;
        private Vector2 _positionRelative;
        private float _x, _y, _concentrationValue, _range, _angle;

        public Texture2D Texture { get { return _texture; } set { _texture = value; } }
        public Color Color { get { return _color; } set { _color = value; } }
        public Vector2 Position { get { return _position; } set { _position = value; } }
        public float Range { get { return _range; } set { _range = value; } }
        public float Angle { get { return _angle; }
            set {
                _angle = value;
                float r = (float)Math.Sqrt(_x * _x + _y * _y);
                Position = new Vector2(r * (float)Math.Cos(_angle), r * (float)Math.Sin(_angle));
            }
        }

        public Ball(Color color, GraphicsDeviceManager graphics, float range, float angle)
        {
            this.Color = color;
            this._graphics = graphics;
            this.Position = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            this._x = 200;
            this._y = 200;
            this.Range = range;
            this.Angle = angle;
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
            _positionRelative = new Vector2(Range, 0);
            //_graphics.PreferredBackBufferWidth = 100;
            //_graphics.PreferredBackBufferHeight = 500;
            Position = Vector2.Add(new Vector2(_graphics.PreferredBackBufferWidth/2, _graphics.PreferredBackBufferHeight/2), _positionRelative);
            Angle += (float)0.01;
        }
    }
}