using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConcentrationBar : MonoBehaviour {

    public Image Bar;

    TGCConnectionController controller;
    DisplayData Data;
    //public int attention;

	// Use this for initialization
	void Start () {
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
        Data = GameObject.Find("Main Camera").GetComponent<DisplayData>();
	}
	
	// Update is called once per frame
	void Update () {
        Bar.fillAmount = Data.Attention/100.0f;
        //Bar.fillAmount = attention / 100.0f;
    }
}
