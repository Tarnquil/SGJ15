using UnityEngine;
using System.Collections;

public class Obj : MonoBehaviour
{
		public float tweenInTime = 0.0f;
		public iTween.EaseType ease;
		public bool draggable = false;
		// Use this for initialization
		void Start ()
		{
				ScaleIn ();
		}


		public void ScaleIn ()
		{
				Hashtable twnHsh = new Hashtable ();
				twnHsh.Add ("scale", Vector3.zero);
				twnHsh.Add ("time", tweenInTime);
				twnHsh.Add ("easetype", ease);
				twnHsh.Add ("oncomplete", "TurnOnCollider");
				twnHsh.Add ("oncompleteobject", this.gameObject);
				iTween.ScaleFrom (this.gameObject, twnHsh);
		}

		public void ScaleOut ()
		{
				Hashtable twnHsh = new Hashtable ();
				twnHsh.Add ("scale", Vector3.zero);
				twnHsh.Add ("time", tweenInTime / 2);
				twnHsh.Add ("easetype", ease);
				iTween.ScaleTo (this.gameObject, twnHsh);
		}

		// Update is called once per frame
		void Update ()
		{
	
		}

		public virtual void OnTouch ()
		{
				//ScaleOut ();
		}

		public virtual void OnRelease ()
		{

		}

		void TurnOnCollider ()
		{
				this.gameObject.collider2D.enabled = true;
		}

}
