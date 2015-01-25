using UnityEngine;
using System.Collections;

public class InstructionScreen : MonoBehaviour
{
		public GameObject page1;
		public GameObject page2;

		public void OpenPage1 ()
		{
				page2.SetActive (false);
				page1.SetActive (true);
		}

		public void OpenPage2 ()
		{
				page2.SetActive (true);
				page1.SetActive (false);
		}

		public void LoadMainMenu ()
		{
				Application.LoadLevel ("Menu");
		}
}
