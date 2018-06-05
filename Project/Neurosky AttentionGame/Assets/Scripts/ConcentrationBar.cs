using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConcentrationBar : MonoBehaviour {

    public Image Bar;

    TGCConnectionController controller;
    private int _attention;

	// Use this for initialization
	void Start () {
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();

        controller.UpdateAttentionEvent += OnUpdateAttention;
	}

    void OnUpdateAttention(int value)
    {
        _attention = value;
    }
	
	// Update is called once per frame
	void Update () {
        Bar.fillAmount = _attention/100.0f;
	}
}
