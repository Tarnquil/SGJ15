using UnityEngine;
using System.Collections;

public class TapObject : Obj
{
		public CameraController cont;
		public AudioClip tap;
		public override void OnTouch ()
		{
				base.OnTouch ();
				cont.HitDot ();
				this.gameObject.collider2D.enabled = false;
				this.gameObject.GetComponent<AudioSource> ().PlayOneShot (tap);
				iTween.Stop (this.gameObject);
				ScaleOut ();
		}
}
