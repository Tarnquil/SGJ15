using UnityEngine;
using System.Collections;

public class LoadLevelOnTimer : MonoBehaviour
{
	public string levelName = "Menu";
	public float time = 3.0f;

	// Use this for initialization
	void Start ()
	{
		Invoke ("LoadLevel", time);

	}

	void LoadLevel ()
	{
		Application.LoadLevel (levelName);
	}

}
