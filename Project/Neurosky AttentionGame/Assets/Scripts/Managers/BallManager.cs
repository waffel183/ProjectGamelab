using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {

    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private float _startPosRel;
    private TGCConnectionController _controller;
    private ConcentrationBar _concentrationBar;
    private VectorObject _ballPosRel;
    private GameObject _middleBall;
    private GameObject _ball;
    private Ball _middleBallScript;
    private Ball _ballScript;
    private DisplayData _data;

    private float _attention;
    private float _concentrationRelative;

    public float startTime;
    public float endTime;

    private Vector2 _centre;
    private float _angle;
    private float _radius;

    Vector2 offset;

    void Start () {
        _controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
        //_data = GameObject.Find("Main Camera").GetComponent<DisplayData>();
        _concentrationBar = GameObject.Find("ConcentrationBarController").GetComponent<ConcentrationBar>();


        _middleBall = Instantiate(_ballPrefab);
        _middleBallScript = _middleBall.GetComponent<Ball>();
        _middleBallScript.Setup(new Point(0, 0, 10, _middleBall.transform), new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0));
        _middleBallScript.Updator();

        _centre = _middleBallScript.Point.transform.position;

        _ball = Instantiate(_ballPrefab);
        _ballScript = _ball.GetComponent<Ball>();
        _ballScript.Setup(new Point(200, 200, 10, _ball.transform), new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0));
        _ball.AddComponent<VectorObject>();

        _ballPosRel = _ball.GetComponent<VectorObject>();
        _ballPosRel.Setup(new Point(200, 200, 10, _ball.transform), new Vector2(_startPosRel, 0), new Vector2(0, 0), new Vector2(0, 0));
        _ballPosRel.Updator();
        _ballScript.DAngle = 1.5f;
	}

    void Update () {

        /*
        if (_data.Attention > 0)
        {
            _concentrationRelative = _startPosRel / (_data.Attention / 100);

            _ballPosRel.Pos = new Vector2(_concentrationRelative, 0);
        }
        */
        _angle += _ballScript.DAngle * Time.deltaTime;
        if (_concentrationBar.attention > 0)
        {
            _attention = _concentrationBar.attention * 1.0f;
            _radius = _startPosRel / (_attention / 100);
            offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * _radius;
        }
        else
        {
            offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * _startPosRel;
        }
        _ballScript.Point.transform.position = _centre + offset;
    
    }
}
