using UnityEngine;
using System.Collections;

public class TapBomb : Obj
{
		public CameraController cont;
		public AudioClip Boom;
		public override void OnTouch ()
		{
				base.OnTouch ();
				audio.PlayOneShot (Boom);
				cont.HitBomb ();
				iTween.Stop (this.gameObject);
				ScaleOut ();
		}
}
