using UnityEngine;
using System.Collections;

public class TapSequence : MonoBehaviour
{
		public int numberInSequence;
		public GameObject tapObject;
		public Vector2[] spawnPositions;
		public float[] timeBetweenSpawns;

		void Start ()
		{
				StartSequence ();
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
						yield return new WaitForSeconds (timeBetweenSpawns [i]);
				}
		}
}
