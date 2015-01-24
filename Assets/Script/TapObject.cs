using UnityEngine;
using System.Collections;

public class TapObject : Obj
{
	public TapSequence sequence;

	public override void OnTouch()
	{
			base.OnTouch ();
			sequence = this.gameObject.transform.parent.gameObject.GetComponent<TapSequence> ();
			sequence.tappedObject++;
			this.gameObject.collider2D.enabled = false;
			ScaleOut ();
	}
}
