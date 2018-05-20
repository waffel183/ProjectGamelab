using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ConcentratieGame
{
    abstract class Background
    {
        public enum BackgroundState { Rotate }

        protected BackgroundState _state;
        protected Color _color;
        protected Texture2D _texture;
        protected float _x, _y, _x2, _y2;

        public Texture2D Texture { set { _texture = value; } }

        public Background(float x, float y, float x2, float y2, Color color, BackgroundState state)
        {
            this._x = x;
            this._y = y;
            this._x2 = x2;
            this._y2 = y2;
            this._color = color;
            this._state = state;
        }
    }

    class BckSpiral : Background
    {
        public BckSpiral(float x, float y, float x2, float y2, Color color, BackgroundState state) : base(x, y, x2, y2, color, state) { }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_texture, new Rectangle((int)_x, (int)_y, (int)_x2, (int)_y2), _color);
            spriteBatch.End();
        }
    }
}
