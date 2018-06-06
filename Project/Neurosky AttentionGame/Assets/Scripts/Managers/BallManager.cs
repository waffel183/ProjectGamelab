using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {

    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private float _startPosRel;
    private TGCConnectionController _controller;
    private VectorObject _ballPosRel;
    private GameObject _middleBall;
    private GameObject _ball;
    private Ball _middleBallScript;
    private Ball _ballScript;

    private float _attention;
    private float _concentrationRelative;

    void Start () {
        _controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();

        _controller.UpdateAttentionEvent += OnUpdateAttention;

        _middleBall = Instantiate(_ballPrefab);
        _middleBallScript = _middleBall.GetComponent<Ball>();
        _middleBallScript.Setup(new Point(0, 0, 10, _middleBall.transform), new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0));

        _ball = Instantiate(_ballPrefab);
        _ballScript = _ball.GetComponent<Ball>();
        _ballScript.Setup(new Point(200, 200, 10, _ball.transform), new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0));
        _ball.AddComponent<VectorObject>();

        _ballPosRel = _ball.GetComponent<VectorObject>();
        _ballPosRel.Setup(new Point(200, 200, 10, _ball.transform), new Vector2(_startPosRel, 0), new Vector2(0, 0), new Vector2(0, 0));
        _ballPosRel.Updator();
        _ballScript.DAngle = 0.02f;
	}

    void OnUpdateAttention(int value)
    {
        _attention = value*1.0f;
    }

    void Update () {
        _middleBallScript.Updator();
        _ballPosRel.Angle += _ballScript.DAngle;

        _concentrationRelative = _startPosRel / (_attention / 100);

        _ballPosRel.Pos = new Vector2(_concentrationRelative,0);

        _ballScript.SumVector(_middleBallScript.Pos, _ballPosRel.Pos, _ballScript.Pos);
        _ballScript.Updator();
    }
}
