using UnityEngine;
using System.Collections;

public class TapObject : Obj
{
		public override void OnTouch ()
		{
				base.OnTouch ();
				ScaleOut ();
		}
}
