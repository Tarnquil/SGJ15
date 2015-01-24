using UnityEngine;
using System.Collections;

public class Sequencer : MonoBehaviour
{
	public GameObject[] sequences;
	public int sequenceNumber = 0;
	// Use this for initialization
	void Start()
	{

	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	public void FinishedSequence()
	{

	}

	public void SpawnSequence()
	{
		GameObject obj = Instantiate(sequences[sequenceNumber],
		                              this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;
		obj.transform.parent = this.gameObject.transform;
		sequenceNumber++;

	}
}
