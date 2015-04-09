using UnityEngine;
using System.Collections;

public class TakeScreenCap : MonoBehaviour
{

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.C))
		{
			Application.CaptureScreenshot("ScreenCap.png",4);
		}
	}
}
