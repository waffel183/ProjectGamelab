using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : VectorObject
{
    private SpriteRenderer _spriteRenderer;

    public SpriteRenderer SpriteRenderer
    {
        get
        {
            return _spriteRenderer;
        }
        set
        {
            _spriteRenderer = value;
        }
    }
}
