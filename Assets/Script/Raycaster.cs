using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Raycaster : MonoBehaviour
{
	public PowerBar powerBar;

	struct DragPair
	{
		public int fingerId;
		public GameObject dragObject;
	}

	List<DragPair> draggingObjects;

	void Start ()
	{
		draggingObjects = new List<DragPair> ();
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			GameObject touched = TouchCheck (Input.mousePosition);
			if (touched != null) 
			{
				if (touched.GetComponent<Obj> ()) 
				{
					Obj touchedObj = touched.GetComponent<Obj> ();
					touchedObj.OnTouch ();
					if (touchedObj.draggable == true) 
					{
						DragPair drag = new DragPair ();
						drag.fingerId = -1;
						drag.dragObject = touchedObj.gameObject;
						draggingObjects.Add (drag);
					}
				}
			}
		}

		foreach (DragPair pair in draggingObjects) 
		{
			if (pair.fingerId != -1) 
			{

			} 
			else 
			{

			}
		}

		if (Input.touchCount > 0) 
		{
			foreach (Touch touch in Input.touches) 
			{
				if (touch.phase == TouchPhase.Began) 
				{
					GameObject touched = TouchCheck (touch.position);
					if (touched != null) 
					{
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
		if (hit != null) 
		{
			powerBar.AddPower();
			return hit.gameObject;
		} 
		else 
		{
			return null;
		}

	}
}
