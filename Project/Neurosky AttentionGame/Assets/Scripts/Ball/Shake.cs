using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    private bool _isActive = true;

    [SerializeField] private float _range;
    [SerializeField] private float _speed;

    public bool IsActive
    {
        get
        {
            return _isActive;
        }
    }

    public float Range
    {
        get
        {
            return _range;
        }

        set
        {
            _range = value;
        }
    }

    public float Speed
    {
        get
        {
            return _speed;
        }

        set
        {
            _speed = value;
        }
    }

    void Update () {
        if (IsActive) ShakeUpdate();
	}

    public void ShakeStart()
    {
        _isActive = true;
    }

    public void ShakeStop()
    {
        _isActive = true;
    }

    private void ShakeUpdate()
    {
        float shakeX = Random.Range(-Range, Range);
        float shakeY = Random.Range(-Range, Range);
        Vector3 newPosition = new Vector3(
            Mathf.Lerp(transform.position.x, shakeX, Time.deltaTime * Speed),
            Mathf.Lerp(transform.position.y, shakeY, Time.deltaTime * Speed),
            transform.position.z
        );
        transform.position = newPosition;
    }
}
