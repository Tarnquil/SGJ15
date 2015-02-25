using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Raycaster : MonoBehaviour
{

		public Text debugText;
		struct DragPair
		{
				public int fingerId;
				public GameObject dragObject;
		}
		void Start ()
		{

		}
	
		void Update ()
		{
				if (Input.GetMouseButtonDown (0)) {
						GameObject touched = TouchCheck (Input.mousePosition);
						if (touched != null) {
								if (touched.GetComponent<Obj> ()) {
										Obj touchedObj = touched.GetComponent<Obj> ();
										touchedObj.OnTouch ();
//					if(touchedObj.draggable == true)
//					{
//						DragPair drag = new DragPair();
//						drag.fingerId = -1;
//						drag.dragObject = touchedObj.gameObject;
//						draggingObjects.Add(drag);
//					}
								}

						}
				}

				/*if (Input.GetMouseButtonUp (0)) {
						int index = -1;
						for (int i = 0; i < draggingObjects.Count; i++) {
								if (draggingObjects [i].fingerId == -1) {
										index = i;
								}
						}

						if (index != -1) {
								draggingObjects.RemoveAt (index);
						}
>>>>>>> FETCH_HEAD
				}
			}
		}

<<<<<<< HEAD
		foreach (DragPair pair in draggingObjects) 
		{
			if (pair.fingerId != -1) 
			{

			} 
			else 
			{

			}
=======
				foreach (DragPair pair in draggingObjects) {
						if (pair.fingerId != -1) {

						} else {
								Vector3 newPos = Input.mousePosition;
								Vector3 hitThing = newPos;
								hitThing.x -= 100;
								//hitThing.z = 10;
								pair.dragObject.transform.position = hitThing;
						}
				}*/

				if (Input.touchCount > 0) {
						
						foreach (Touch touch in Input.touches) {
								if (touch.phase == TouchPhase.Began) {
										//	debugText.text = "Tapped";
										GameObject touched = TouchCheck (touch.position);
										if (touched != null) {
												Debug.Log (touched.name);
												if (touched.GetComponent<Obj> ()) {
														touched.GetComponent<Obj> ().OnTouch ();
												}
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
				Collider2D hit = Physics2D.OverlapCircle (touchPos, 0.5f);
				if (hit != null) {
						return hit.gameObject;
				} else {
						return null;
				}

		}
}
