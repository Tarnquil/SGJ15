using UnityEngine;
using System.Collections;

public class TapSequence : MonoBehaviour
{
		public int numberInSequence;
		public GameObject tapObject;
		public Vector2[] spawnPositions;
		public float[] timeBetweenSpawns;
		public int tappedObject;
		public Sequencer sequencer;

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
				StartCoroutine ("PlaySequence");
		}

		IEnumerator PlaySequence ()
		{
				for (int i = 0; i < spawnPositions.Length; i++) {

						Vector3 newPos = spawnPositions [i];
						GameObject obj = Instantiate (tapObject) as GameObject;
						obj.transform.parent = this.gameObject.transform;
						obj.transform.rotation = Quaternion.identity;
						obj.transform.localPosition = newPos;
						//obj.transform.parent = null;
						yield return new WaitForSeconds (timeBetweenSpawns [i]);
				}
		}
}
