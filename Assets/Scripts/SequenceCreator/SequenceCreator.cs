using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SequenceCreator : MonoBehaviour 
{
	public Camera cam;
	public GameObject tapObject, bombObject;
	public Transform parentObject;
	bool positioning = false;
	GameObject spawnedObject;
	Sequences sequences;
	Sequence sequence;

	public Text errorText;
	public InputField Name;
	// Use this for initialization
	void Start () 
	{
		sequences = Sequences.Load(Application.dataPath +"/sequences.xml");
		sequence = new Sequence();
	}
	
	// Update is called once per frame
	void Update () 
	{

		//Debug.Log(Input.mousePosition);
		Vector3 tmpVec = cam.ScreenToWorldPoint(Input.mousePosition);
		Vector3 tmpLocalPos = parentObject.InverseTransformPoint(tmpVec);
		//Debug.Log(tmpLocalPos);
		if(!positioning && ((tmpLocalPos.x < 2.5f && tmpLocalPos.x > -2.5f) && ((tmpLocalPos.y < 1.5f && tmpLocalPos.y > -1.5f))))
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
			else if(Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
			{
				//Spawn Bomb
				if(Input.GetMouseButtonDown(0))
				{
					//Input
					RaycastHit hit;
					Ray ray = cam.ScreenPointToRay(Input.mousePosition);
					if(Physics.Raycast(ray,out hit ))
					{
						if(hit.collider.tag == "tapObject" || hit.collider.tag == "bombObject")
						{
							Destroy(hit.collider.gameObject);
						}


					}
				}
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
		else if(positioning)
		{
			tmpLocalPos.x = Mathf.Round(tmpLocalPos.x * 10f) / 10f;
			tmpLocalPos.y = Mathf.Round(tmpLocalPos.y * 10f) / 10f;
			spawnedObject.transform.localPosition = new Vector3(Mathf.Clamp(tmpLocalPos.x,-2.5f,2.5f),Mathf.Clamp( tmpLocalPos.y,-1.5f,1.5f),1);

		}

		if(Input.GetMouseButtonUp(0) && positioning)
		{
			positioning = false;
			if(spawnedObject.tag == "tapObject")
			{
				Dot newDot = new Dot();
				newDot.Number = (sequence.Dots.Count+1).ToString();
				newDot.X = spawnedObject.transform.localPosition.x.ToString();
				newDot.Y = spawnedObject.transform.localPosition.y.ToString();
				sequence.Dots.Add(newDot);
			}
			else if (spawnedObject.tag == "bombObject");
			{
				Bomb newBomb = new Bomb();
				newBomb.Number = (sequence.Bombs.Count+1).ToString();
				newBomb.X = spawnedObject.transform.localPosition.x.ToString();
				newBomb.Y = spawnedObject.transform.localPosition.y.ToString();
				sequence.Bombs.Add(newBomb);
			}
			spawnedObject = null;
		}
	}

	public void CreateSequence()
	{
		errorText.text = "";
		if(!string.IsNullOrEmpty(Name.text))
		{
			sequence.Name = Name.text ;
			sequence.Number = (sequences.SequenceList.Count+1).ToString();
			sequences.SequenceList.Add(sequence);
			sequences.Save(Application.dataPath +"/sequences.xml");
			Clear();
		}
		else
		{
			errorText.text = "ERROR : ENTER NAME";
		}


	}

	public void Clear()
	{
		sequence = null;
		sequence = new Sequence();
		for(int i = 0; i < parentObject.childCount; ++i)
		{
			Destroy(parentObject.GetChild(i).gameObject);
		}
	}
}
