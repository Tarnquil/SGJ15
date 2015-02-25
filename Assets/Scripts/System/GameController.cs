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
		public AudioClip countDown;
		public AudioClip GO;
		public GameState currentState;
		public GameState prevState;
		public Sequencer playerOneSequencer;
		public Sequencer playerTwoSequencer;
		public PowerBar playerOnePowerBar;
		public PowerBar playerTwoPowerBar;
		public Button playerOneActionButton;
		public Button playerTwoActionButton;
		public GameObject[] sequences;
		public int numberOfSequences = 0;
		public int currentSequence = 0;
		public int betweenRounds = 2;
		public Text playerOneCountDown;
		public Text playerTwoCountDown;
		public float powerBoost;
		public int playerOneScore = 0;
		public int playerTwoScore = 0;
		public float endTimer = 0;

		public Text p1Score;
		public Text p2Score;
		// Use this for initialization
		void Start ()
		{

				numberOfSequences = PlayerPrefs.GetInt ("Rounds");
				currentState = GameState.BETWEEN_ROUND;
				prevState = GameState.NULL;

				
		}
	
		// Update is called once per frame
		void Update ()
		{
				switch (currentState) {
				case GameState.BETWEEN_ROUND: 
						if (prevState != currentState) {
								StartCoroutine ("Countdown");
						} else {

						}
						;
						break;

				case GameState.IN_ROUND: 
						if (prevState != currentState) {
								int rnd = Random.Range (0, sequences.Length);
								playerOneSequencer.SpawnSequence (sequences [rnd]);
								playerTwoSequencer.SpawnSequence (sequences [rnd]);
						}
						;
						break;
				case GameState.END:
						if (prevState != currentState) {

								playerOneCountDown.enabled = true;
								playerTwoCountDown.enabled = true;

								if (playerOneScore > playerTwoScore) {
										playerOneCountDown.text = "WIN";
										playerTwoCountDown.text = "LOSE";
								} else {
										playerOneCountDown.text = "LOSE";
										playerTwoCountDown.text = "WIN";
								}
								StartCoroutine ("EndTimer");
			
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
						p1Score.text = playerOneScore.ToString ();
						playerTwoPowerBar.AddPower (powerBoost);
				} else {
						playerTwoScore++;
						p2Score.text = playerTwoScore.ToString ();
						playerOnePowerBar.AddPower (powerBoost);
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
						this.gameObject.audio.PlayOneShot (countDown);
						yield return new WaitForSeconds (1.0f);
				}

				playerOneCountDown.enabled = false;
				playerTwoCountDown.enabled = false;
		
				this.gameObject.audio.PlayOneShot (GO);
				
				currentState = GameState.IN_ROUND;
		}

		IEnumerator EndTimer ()
		{
				yield return new WaitForSeconds (endTimer);
				Application.LoadLevel ("Menu");
		}



}
