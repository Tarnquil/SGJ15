using UnityEngine;
using System.Collections;

public class SwipeSequce : MonoBehaviour
{
		public int numberOfPairs = 0;
		public GameObject swipeObj;
		public GameObject swipeGoal;
		public Vector2[] swipeObjSpawn;
		public Vector2[] swipeGoalSpawn;


		// Use this for initialization
		void Start ()
		{
				for (int i = 0; i<numberOfPairs; i++) {
						int ident = -1;
						do {
								ident = Random.Range (0, 100);
						} while(GameObject.Find("SwipeObject"+ident));

						Vector3 newPos = swipeObjSpawn [i];
						GameObject obj = Instantiate (swipeObj) as GameObject;
						obj.transform.parent = this.gameObject.transform;
						obj.transform.rotation = Quaternion.identity;
						obj.transform.localPosition = newPos;
						obj.name = "SwipeObject" + ident;

						newPos = swipeGoalSpawn [i];
						obj = Instantiate (swipeGoal) as GameObject;
						obj.transform.parent = this.gameObject.transform;
						obj.transform.rotation = Quaternion.identity;
						obj.transform.localPosition = newPos;
						obj.name = "SwipeGoal" + ident;
				}

		}

		public void SwipeComplete ()
		{

		}
}
