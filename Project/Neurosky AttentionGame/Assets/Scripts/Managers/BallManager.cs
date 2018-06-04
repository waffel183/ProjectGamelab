using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {

    [SerializeField] private GameObject _ballPrefab;
    private VectorObject _ballPosRel;
    private GameObject _middleBall;
    private GameObject _ball;
    private Ball _middleBallScript;
    private Ball _ballScript;

    void Start () {
        _middleBall = Instantiate(_ballPrefab);
        _middleBallScript = _middleBall.GetComponent<Ball>();
        _middleBallScript.Setup(new Point(0, 0, 10, _middleBall.transform), new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0));

        _ball = Instantiate(_ballPrefab);
        _ballScript = _ball.GetComponent<Ball>();
        _ballScript.Setup(new Point(200, 200, 10, _ball.transform), new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0));
        _ball.AddComponent<VectorObject>();

        _ballPosRel = _ball.GetComponent<VectorObject>();
        _ballPosRel.Setup(new Point(200, 200, 10, _ball.transform), new Vector2(2.5f, 0), new Vector2(0, 0), new Vector2(0, 0));
        _ballPosRel.Updator();
        _ballScript.DAngle = 0.02f;
	}
	
	void Update () {
        _middleBallScript.Updator();
        _ballPosRel.Angle += _ballScript.DAngle;

        _ballScript.SumVector(_middleBallScript.Pos, _ballPosRel.Pos, _ballScript.Pos);
        _ballScript.Updator();
    }
}
