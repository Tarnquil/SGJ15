using UnityEngine;
using System.Collections;

public class TapSequence : MonoBehaviour
{
		public int numberInSequence;
		public GameObject tapObject;
		public GameObject bombObject;
		public Vector2[] spawnPositions;
		public Vector2[] bombPositions;
		public float[] timeBetweenSpawns;
		public int tappedObject;
		public Sequencer sequencer;
		public bool bombs;
		void Start ()
		{
				StartSequence ();
		}

		void Update ()
		{

				if (tappedObject == numberInSequence) {
						sequencer = this.gameObject.transform.parent.gameObject.GetComponent<Sequencer> ();
						sequencer.FinishedSequence ();
						//Destroy (this.gameObject);
				}

		}

		public void StartSequence ()
		{
			StartCoroutine("PlaySequence");
		}

		IEnumerator PlaySequence ()
		{
			int j = 0;
			for (int i = 0; i < spawnPositions.Length; i++) 
			{
				
				Vector3 newPos = spawnPositions [i];
				GameObject obj = Instantiate (tapObject) as GameObject;
				obj.transform.parent = this.gameObject.transform;
				obj.transform.rotation = Quaternion.identity;
				obj.transform.localPosition = newPos;
				//obj.transform.parent = null;
				yield return new WaitForSeconds (timeBetweenSpawns [i]);
				
				if(bombs && j < bombPositions.Length)
				{
					j++;
					Vector3 newBombPos = bombPositions[i];
					GameObject bombObj = Instantiate (bombObject) as GameObject;
					bombObj.transform.parent = this.gameObject.transform;
					bombObj.transform.rotation = Quaternion.identity;
					bombObj.transform.localPosition = newBombPos;
					yield return new WaitForSeconds (timeBetweenSpawns [i]);
				}
			}
		}
}
