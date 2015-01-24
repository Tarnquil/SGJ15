using UnityEngine;
using System.Collections;

public class SwipeObject : Obj
{
		SwipeSequce sequence;
		void OnTriggerEnter (Collider other)
		{
				Debug.Log (other.gameObject.name);
				if (other.gameObject.name == "SwipeGoal" + this.gameObject.name.Substring ("SwipeObject".Length - 1)) {
						sequence = this.gameObject.transform.parent.gameObject.GetComponent<SwipeSequce> ();
						Destroy (other.gameObject);
						Destroy (this.gameObject);
				}
		}
}
