using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{

		public enum GameState
		{
				INTRO,
				BETWEEN_ROUND,
				IN_ROUND,
				END,
				NULL
		}

		public GameState currentState;
		public GameState prevState;
		public Sequencer playerOneSequencer;
		public Sequencer playerTwoSequencer;
		public Button playerOneActionButton;
		public Button playerTwoActionButton;
		public int numberOfSequences = 0;
		public int currentSequence = 0;
		public int betweenRounds = 2;
		public Text playerOneCountDown;
		public Text playerTwoCountDown;

		public int playerOneScore = 0;
		public int playerTwoScore = 0;
		// Use this for initialization
		void Start ()
		{
				currentState = GameState.BETWEEN_ROUND;
				prevState = GameState.NULL;

				
		}
	
		// Update is called once per frame
		void Update ()
		{
				switch (currentState) {
				case GameState.BETWEEN_ROUND: 
						if (prevState != currentState) {
								playerOneActionButton.enabled = true;
								playerTwoActionButton.enabled = true;
								StartCoroutine ("Countdown");
						} else {

						}
						;
						break;

				case GameState.IN_ROUND: 
						if (prevState != currentState) {
								playerOneActionButton.enabled = false;
								playerTwoActionButton.enabled = false;
								playerOneSequencer.SpawnSequence ();
								playerTwoSequencer.SpawnSequence ();
						}
						;
						break;
				case GameState.END:
						if (prevState != currentState) {
								playerOneActionButton.enabled = false;
								playerTwoActionButton.enabled = false;

								playerOneCountDown.enabled = true;
								playerTwoCountDown.enabled = true;

								if (playerOneScore > playerTwoScore) {
										playerOneCountDown.text = "WIN";
										playerTwoCountDown.text = "LOSE";
								} else {
										playerOneCountDown.text = "LOSE";
										playerTwoCountDown.text = "WIN";
								}
			
						}
						;
						break;

				}
				prevState = currentState;
		}
	
		public void FinishedSequence (int _player)
		{
				Destroy (playerOneSequencer.transform.GetChild (0).gameObject);
				Destroy (playerTwoSequencer.transform.GetChild (0).gameObject);

				if (_player == 1) {
						playerOneScore++;
				} else {
						playerTwoScore++;
				}
				currentSequence++;
				if (currentSequence == numberOfSequences) {
						currentState = GameState.END;
				} else {
						currentState = GameState.BETWEEN_ROUND;
				}
		}

		IEnumerator Countdown ()
		{

				playerOneCountDown.enabled = true;
				playerTwoCountDown.enabled = true;

				for (int i = 0; i < betweenRounds; i++) {

						playerOneCountDown.text = (betweenRounds - i).ToString ();
						playerTwoCountDown.text = (betweenRounds - i).ToString ();
						yield return new WaitForSeconds (1.0f);
				}

				playerOneCountDown.enabled = false;
				playerTwoCountDown.enabled = false;
				currentState = GameState.IN_ROUND;
		}



}
