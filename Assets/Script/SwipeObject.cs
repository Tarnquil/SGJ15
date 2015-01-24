using UnityEngine;
using System.Collections;

public class SwipeObject : MonoBehaviour
{
		SwipeSequce sequence;
		void OnTriggerEnter2D (Collider2D other)
		{
				if (other.gameObject.name == "SwipeGoal") {
						sequence = this.gameObject.transform.parent.gameObject.GetComponent<SwipeSequce> ();
				}
		}
}
