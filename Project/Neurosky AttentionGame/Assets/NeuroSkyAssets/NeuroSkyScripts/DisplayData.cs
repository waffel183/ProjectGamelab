using UnityEngine;
using System.Collections;

public class DisplayData : MonoBehaviour
{
	public Texture2D[] signalIcons;
	
	private int indexSignalIcons = 1;
	
    TGCConnectionController controller;

    private int poorSignal1;
    public float Attention;

    void Start()
    {
		
		controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
		
		controller.UpdatePoorSignalEvent += OnUpdatePoorSignal;
        controller.UpdateAttentionEvent += OnUpdateAttention;

    }
	
	void OnUpdatePoorSignal(int value){
		poorSignal1 = value;
		if(value < 25){
      		indexSignalIcons = 0;
		}else if(value >= 25 && value < 51){
      		indexSignalIcons = 4;
		}else if(value >= 51 && value < 78){
      		indexSignalIcons = 3;
		}else if(value >= 78 && value < 107){
      		indexSignalIcons = 2;
		}else if(value >= 107){
      		indexSignalIcons = 1;
		}
	}
    void OnUpdateAttention(int value)
    {
        Attention = value * 1.0f;
    }


    void OnGUI()
    {
        
		GUILayout.BeginHorizontal();
		
		
        if (GUILayout.Button("Connect"))
        {
            controller.Connect();
        }
        if (GUILayout.Button("DisConnect"))
        {
            controller.Disconnect();
			indexSignalIcons = 1;
        }
		
		GUILayout.Space(Screen.width-250);
		GUILayout.Label(signalIcons[indexSignalIcons]);
		
		GUILayout.EndHorizontal();
        
    }
}
