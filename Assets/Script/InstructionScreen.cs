using UnityEngine;
using System.Collections;

public class InstructionScreen : MonoBehaviour
{
		public GameObject page1;
		public GameObject page2;
	
		public void OpenPage1 ()
		{
				Debug.Log ("Working");
				page2.SetActive (false);
				page1.SetActive (true);
				Debug.Log ("Working");
		}

		public void OpenPage2 ()
		{
				Debug.Log ("Working");
				page2.SetActive (true);
				page1.SetActive (false);
				Debug.Log ("Working");
		}

		public void LoadMainMenu ()
		{
				Application.LoadLevel ("Menu");
		}
}
