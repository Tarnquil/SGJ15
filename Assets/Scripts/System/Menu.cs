using UnityEngine;
using System.Collections;


public class Menu : MonoBehaviour
{

    public GameObject transitionGroup;
    public Transform testSequence;
    public CameraController camController;

    void Update()
    {
        if (camController.tappedDots == testSequence.childCount)
        {
            for (int i = 0; i < testSequence.childCount; ++i)
            {
                iTween.ScaleTo(testSequence.GetChild(i).gameObject, iTween.Hash("scale", new Vector3(1, 1, 1), "delay", 2.0f, "time", 1.0f));
                testSequence.GetChild(i).gameObject.GetComponent<CircleCollider2D>().enabled = true;
            }

            camController.tappedDots = 0;
        }
    }
    public void Start()
    {
        //LeanTween.move(GameObject go, Vector3 to, float speed );
    }
    public void StartButton3()
    {
        PlayerPrefs.SetInt("Rounds", 3);
        transitionGroup.SetActive(true);
        //Application.LoadLevel ("BestOf");
    }

    public void StartButton5()
    {
        PlayerPrefs.SetInt("Rounds", 5);
        transitionGroup.SetActive(true);
        //Application.LoadLevel ("BestOf");
    }

    public void StartButton7()
    {
        PlayerPrefs.SetInt("Rounds", 7);
        transitionGroup.SetActive(true);
        //Application.LoadLevel ("BestOf");
    }

    public void HowToMenu()
    {
        Application.LoadLevel("HowTo");
    }

    void LoadMain()
    {
        Application.LoadLevel("BestOf");
    }
}
