using UnityEngine;
using System.Collections;

public class InstructionScreen : MonoBehaviour
{
		public GameObject[] pages;
		public int currentPage = 0;
	

		public void Start ()
		{
				ChangePage (currentPage);
		}

		void ChangePage (int _pageToChangeTo)
		{
				foreach (GameObject page in pages) {
						page.SetActive (false);
				}
				pages [currentPage].SetActive (true);
		}

		public void ForwardPage ()
		{
				currentPage++;
				ChangePage (currentPage);
		}

		public void BackPage ()
		{
				currentPage--;
				ChangePage (currentPage);
		}

		public void LoadMainMenu ()
		{
				Application.LoadLevel ("Menu");
		}
}
