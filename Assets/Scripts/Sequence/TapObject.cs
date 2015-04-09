using UnityEngine;
using System.Collections;

public class TapObject : Obj
{
		public CameraController cont;
		public AudioClip tap;
		public AudioClip unFreeze;
		public bool isFrozen = false;
		public Sprite normalDot;
		public Sprite frozenDot;
		public GameObject particleExplosion;
		public void Freeze ()
		{
				isFrozen = true;
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = frozenDot;
		}

		public override void OnTouch ()
		{
				if (isFrozen) {
						Debug.Log ("******* unfreeze " + this.gameObject.name);
						isFrozen = false;
						this.gameObject.GetComponent<SpriteRenderer> ().sprite = normalDot;
						this.gameObject.GetComponent<AudioSource> ().PlayOneShot (unFreeze);
				} else {
						base.OnTouch ();
						Debug.Log ("******* touched " + this.gameObject.name);
						cont.HitDot ();
						this.gameObject.collider2D.enabled = false;
						this.gameObject.GetComponent<AudioSource> ().PlayOneShot (tap);
						iTween.Stop (this.gameObject);
						ScaleOut ();
						Instantiate (particleExplosion, this.transform.position, this.transform.rotation);
				}
		}
}
