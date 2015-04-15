using UnityEngine;
using System.Collections;

public class DualPauseMenu : MonoBehaviour
{
    public GameObject pauseMenu1, pauseMenu2;
    bool quit1 = false,
        quit2 = false,
        play1 = false, 
        play2 = false;
	
    GameController controller;

    void Start()
    {
        controller = GetComponent<GameController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (play1 && play2)
        {
            PauseButton(false);
        }

        if (quit1 && quit2)
        {
            Application.LoadLevel("Menu");
        }
    }

    public void Quit1(bool state)
    {
        quit1 = state;
    }

    public void Quit2(bool state)
    {
        quit2 = state;
    }

    public void Play1(bool state)
    {
        play1 = state;
    }

    public void Play2(bool state)
    {
        play2 = state;
    }

    public void PauseButton(bool state)
    {
        if (!state)
        {
            quit1 = false;
            quit2 = false;
            play1 = false;
            play2 = false;

            pauseMenu1.SetActive(false);
            pauseMenu2.SetActive(false);

            controller.currentState = GameController.GameState.BETWEEN_ROUND;
        }
        else
        {
            pauseMenu1.SetActive(true);
            pauseMenu2.SetActive(true);

            controller.currentState = GameController.GameState.PAUSED;
        }
    }
}
