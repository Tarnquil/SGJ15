using UnityEngine;
using System.Collections;

public class TapBomb : Obj
{

		public TapSequence sequence;
		public AudioClip Boom;
		public override void OnTouch ()
		{
				base.OnTouch ();
				this.gameObject.GetComponent<AudioSource> ().PlayOneShot (Boom);
				sequence = this.gameObject.transform.parent.gameObject.GetComponent<TapSequence> ();
				sequence.HitBomb ();
				iTween.Stop (this.gameObject);
				ScaleOut ();
		}
}
