using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

		public void StartButton3 ()
		{
				PlayerPrefs.SetInt ("Rounds", 3);
				Application.LoadLevel ("BestOf");
		}

		public void StartButton5 ()
		{
				PlayerPrefs.SetInt ("Rounds", 5);
				Application.LoadLevel ("BestOf");
		}

		public void StartButton7 ()
		{
				PlayerPrefs.SetInt ("Rounds", 7);
				Application.LoadLevel ("BestOf");
		}

		public void HowToMenu ()
		{
				Application.LoadLevel ("HowTo");
		}
}
