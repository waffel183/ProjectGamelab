using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorObject : MonoBehaviour
{
    private Point _point;
    private Vector2 _pos, _vel, _acc;
    private VectorObject _posRel;
    private float _dAngle = 0, _angle = 0, _r;

    public virtual void Setup(Point point, Vector2 pos, Vector2 vel, Vector2 acc)
    {
        this.Point = point;
        this.Pos = pos;
        this.Vel = vel;
        this.Acc = acc;
        this.Angle = Mathf.Atan2(this.Pos.y, this.Pos.x);
        this.R = Mathf.Sqrt(Mathf.Pow(this.Pos.x, 2) + Mathf.Pow(this.Pos.y, 2));
    }

    public Point Point
    {
        get
        {
            return _point;
        }

        set
        {
            _point = value;
        }
    }

    public Vector2 Pos
    {
        get
        {
            return _pos;
        }

        set
        {
            _pos = value;
            this.R = Mathf.Sqrt(Mathf.Pow(value.x, 2) + Mathf.Pow(value.y, 2));
            Debug.Log("Angle before Pos set" + this.Angle);
            this.Angle = Mathf.Atan2(value.y, value.x);
            Debug.Log("Angle after Pos set" + this.Angle);
        }
    }

    public Vector2 Vel
    {
        get
        {
            return _vel;
        }

        set
        {
            _vel = value;
        }
    }

    public Vector2 Acc
    {
        get
        {
            return _acc;
        }

        set
        {
            _acc = value;
        }
    }

    /*public VectorObject PosRel
    {
        get
        {
            return _posRel;
        }
        
        set
        {
            _posRel = value;
        }
    }*/

    public float DAngle
    {
        get
        {
            return _dAngle;
        }

        set
        {
            _dAngle = value;
        }
    }

    public float Angle
    {
        get
        {
            return Mathf.Atan2(this.Pos.y, this.Pos.x);
        }

        set
        {
            _angle = value;
            this._pos.x = this.R * Mathf.Cos(value);
            this._pos.y = this.R * Mathf.Sin(value);
        }
    }

    public float R
    {
        get
        {
            return Mathf.Sqrt(Mathf.Pow(this.Pos.x, 2) + Mathf.Pow(this.Pos.y, 2));
        }

        set
        {
            if (value < 0)
            {
                this.Angle += Mathf.PI;
            }
            _r = Mathf.Abs(value);
            this._pos.x = this.R * Mathf.Cos(this.Angle);
            this._pos.y = this.R * Mathf.Sin(this.Angle);
        }
    }

    public void Updator()
    {
        Vel += Acc;
        Pos += Vel;
        Point.X = Pos.x;
        Point.Y = Pos.y;
        Angle = Mathf.Atan2(this.Pos.y, this.Pos.x);
        Point.Update();
    }

    public void SumVector(Vector2 v1, Vector2 v2, Vector2 target)
    {
        target.x = v1.x + v2.x;
        target.y = v1.y + v2.y;
    }
}
