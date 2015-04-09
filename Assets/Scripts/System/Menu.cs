using UnityEngine;
using System.Collections;


public class Menu : MonoBehaviour
{

	public GameObject transitionGroup;

		public void Start()
		{
			//LeanTween.move(GameObject go, Vector3 to, float speed );
		}
		public void StartButton3 ()
		{
				PlayerPrefs.SetInt ("Rounds", 3);
				transitionGroup.SetActive(true);
				//Application.LoadLevel ("BestOf");
		}

		public void StartButton5 ()
		{
				PlayerPrefs.SetInt ("Rounds", 5);
		transitionGroup.SetActive(true);
				//Application.LoadLevel ("BestOf");
		}

		public void StartButton7 ()
		{
				PlayerPrefs.SetInt ("Rounds", 7);
		transitionGroup.SetActive(true);
				//Application.LoadLevel ("BestOf");
		}

		public void HowToMenu ()
		{
				Application.LoadLevel ("HowTo");
		}

	void LoadMain()
	{
		Application.LoadLevel ("BestOf");
	}
}
