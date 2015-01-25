using UnityEngine;
using System.Collections;

public class InstructionScreen : MonoBehaviour
{
		GameObject page1;
		GameObject page2;

		void OpenPage1 ()
		{
				page2.SetActive (false);
				page1.SetActive (true);
		}

		void OpenPage2 ()
		{
				page2.SetActive (true);
				page1.SetActive (false);
		}

		void LoadMainMenu ()
		{
				Application.LoadLevel ("Menu");
		}
}
