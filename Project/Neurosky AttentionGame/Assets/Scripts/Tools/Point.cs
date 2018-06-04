using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point
{
    private Transform _transform;
    private float _x;
    private float _y;
    private float _r;

    public float X
    {
        get
        {
            return _x;
        }

        set
        {
            _x = value;
        }
    }

    public float Y
    {
        get
        {
            return _y;
        }

        set
        {
            _y = value;
        }
    }

    public float R
    {
        get
        {
            return _r;
        }

        set
        {
            _r = value;
        }
    }

    public Transform transform
    {
        get
        {
            return _transform;
        }

        set
        {
            _transform = value;
        }
    }

    public Point(float x, float y, float r, Transform transform)
    {
        this.X = x;
        this.Y = y;
        this.R = r;
        this.transform = transform;
    }

    public void Update()
    {
        this.transform.position = new Vector2(this.X, this.Y);
    }
}
