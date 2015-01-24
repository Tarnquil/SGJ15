using UnityEngine;
using System.Collections;

public class Sequencer : MonoBehaviour
{
		public GameObject[] sequences;
		// Use this for initialization
		void Start ()
		{
				FinishedSequence ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void FinishedSequence ()
		{
				GameObject obj = Instantiate (sequences [UnityEngine.Random.Range (0, sequences.Length)],
		                              this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;
				obj.transform.parent = this.gameObject.transform;

		}
}
