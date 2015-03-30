using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SequenceCreator : MonoBehaviour 
{
	public Camera cam;
	public GameObject tapObject, bombObject;
	public Transform parentObject;
	bool positioning = false;
	GameObject spawnedObject;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log(Input.mousePosition);
		Vector3 tmpVec = cam.ScreenToWorldPoint(Input.mousePosition);
		Vector3 tmpLocalPos = parentObject.InverseTransformPoint(tmpVec);
		Debug.Log(tmpLocalPos);
		if(!positioning)
		{
			if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			{
				//Spawn Bomb
				if(Input.GetMouseButtonDown(0))
				{
					//Input
					spawnedObject = (GameObject)Instantiate(bombObject);
					spawnedObject.transform.parent = parentObject;
					positioning = true;
				}
			}
			//Delete Object
			if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			{
				
			}
			else
			{
				//Spawn Tap Object
				if(Input.GetMouseButtonDown(0))
				{
					spawnedObject = (GameObject)Instantiate(tapObject);
					spawnedObject.transform.parent = parentObject;
					positioning = true;
				}
			}
		}
		else
		{
			spawnedObject.transform.localPosition = new Vector3(tmpLocalPos.x,tmpLocalPos.y,1);
		}

		if(Input.GetMouseButtonUp(0))
		{
			positioning = false;
			spawnedObject = null;
		}
	}
}
