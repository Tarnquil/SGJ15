using UnityEngine;
using System.Collections;

public class Raycaster : MonoBehaviour
{
		void Update ()
		{
				if (Input.GetMouseButtonDown (0)) {
						GameObject touched = TouchCheck (Input.mousePosition);
						if (touched != null) {
								Debug.Log (touched);
								touched.GetComponent<Obj> ().OnTouch ();
						}
				}

				if (Input.touchCount > 0) {
						foreach (Touch touch in Input.touches) {
								if (touch.phase == TouchPhase.Began) {
										GameObject touched = TouchCheck (Input.mousePosition);
										if (touched != null) {
												Debug.Log (touched.name);
										}
								}
						}
				}
		}

		GameObject TouchCheck (Vector3 _point)
		{
				Vector3 hitThing = _point;
				hitThing.z = 10;
				Vector3 wp = this.gameObject.camera.ScreenToWorldPoint (hitThing);
				Vector2 touchPos = new Vector2 (wp.x, wp.y);
				Collider2D hit = Physics2D.OverlapPoint (touchPos);
				if (hit != null) {
						return hit.gameObject;
				} else {
						return null;
				}

		}
}
