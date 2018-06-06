using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {

    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private float _radius;
    private TGCConnectionController _controller;
    private ConcentrationBar _concentrationBar;
    private GameObject _middleBall;
    private GameObject _ball;
    private Ball _middleBallScript;
    private Ball _ballScript;
    private DisplayData _data;

    private float _currentAttention;
    private float _startAttention;
    private float _attentionPercentage;

    private Vector2 _centre;
    private float _angle;
    private float _startRadius;
    Vector2 offset;

    private bool _haveStartAttention = false;

    void Start () {
        _controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
        //_data = GameObject.Find("Main Camera").GetComponent<DisplayData>();
        _concentrationBar = GameObject.Find("ConcentrationBarController").GetComponent<ConcentrationBar>();


        _middleBall = Instantiate(_ballPrefab);
        _middleBallScript = _middleBall.GetComponent<Ball>();
        _middleBallScript.Setup(new Point(0, 0, 10, _middleBall.transform), new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0));
        _middleBallScript.Updator();

        _centre = _middleBallScript.Point.transform.position;
        _startRadius = _radius;

        _ball = Instantiate(_ballPrefab);
        _ballScript = _ball.GetComponent<Ball>();
        _ballScript.Setup(new Point(200, 200, 10, _ball.transform), new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0));
        _ballScript.DAngle = 1.5f;
	}

    void Update () {
        _angle += _ballScript.DAngle * Time.deltaTime;
        /*
        if (_data.Attention > 0)
        {
            if (!_haveStartAttention)
            {
                _startAttention = _concentrationBar.attention * 1.0f;
                _haveStartAttention = true;
            }
            _currentAttention = _concentrationBar.attention * 1.0f;
            _attentionPercentage = _currentAttention / _startAttention * 100;
            _radius = _startRadius / (_attentionPercentage / 100);
            offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * _radius;
        }
        */
        if (_concentrationBar.attention > 0)
        {
            if (!_haveStartAttention)
            {
                _startAttention = _concentrationBar.attention * 1.0f;
                _haveStartAttention = true;
            }
            _currentAttention = _concentrationBar.attention * 1.0f;
            _attentionPercentage = _currentAttention / _startAttention * 100;
            _radius = _startRadius / (_attentionPercentage / 100);
            offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * _radius;
        }

        else
        {
            offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * _startRadius;
        }
        _ballScript.Point.transform.position = _centre + offset;
        

    }
}
