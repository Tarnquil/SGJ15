using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

		public void StartButton ()
		{
				Application.LoadLevel ("BestOf");
		}

		public void HowToMenu ()
		{
				Application.LoadLevel ("HowTo");
		}
}
