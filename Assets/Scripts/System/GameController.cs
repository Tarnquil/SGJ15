using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Xml;

public class GameController : MonoBehaviour
{
	
		public enum GameState
		{
				INTRO,
				BETWEEN_ROUND,
				IN_ROUND,
				END,
				PAUSED,
				NULL
		}
		public AudioClip countDown;
		public AudioClip GO;
		public GameState currentState;
		public GameState prevState;
		public Button playerOneActionButton;
		public Button playerTwoActionButton;
		public TextAsset sequences;
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
		public CameraController playerOneCamera;
		public CameraController playerTwoCamera;
		public Slider scoreSlider;
		public GameObject pauseButton;
		public GameObject scoreParticles;

		XmlDocument sequencXML;

		// Use this for initialization
		void Start ()
		{
		
				numberOfSequences = PlayerPrefs.GetInt ("Rounds");
				currentState = GameState.BETWEEN_ROUND;
				prevState = GameState.NULL;
				sequencXML = new XmlDocument ();
				sequencXML.LoadXml (sequences.text);
		}
	
		// Update is called once per frame
		void Update ()
		{

				switch (currentState) {
				case GameState.BETWEEN_ROUND: 
						if (prevState != currentState) {
								StartCoroutine ("Countdown");
						}
						;
						break;
			
				case GameState.IN_ROUND: 
						if (prevState != currentState) {
								XmlNodeList sequenceNodes = sequencXML.SelectNodes (@"sequencesroot/sequences/sequence");

								int selectedSequence = Random.Range (0, sequenceNodes.Count);
								playerOneCamera.StartSequence (sequenceNodes [selectedSequence]);
								playerTwoCamera.StartSequence (sequenceNodes [selectedSequence]);
								//	playerOneSequencer.SpawnSequence (sequences [rnd]);
								//	playerTwoSequencer.SpsequenceawnSequence (sequences [rnd]);
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
				case GameState.PAUSED:
						if (prevState != currentState) {
								playerOneCountDown.enabled = false;
								playerTwoCountDown.enabled = false;

								StopCoroutine ("Countdown");
						}
						;
						break;
			
				}
				prevState = currentState;
		}
	
		public void FinishedSequence (int _player)
		{
				if (_player == 1) {
						playerOneScore++;
						//	p1Score.text = playerOneScore.ToString ();
						playerTwoCamera.AddPower (powerBoost);
				} else {
						playerTwoScore++;
						//p2Score.text = playerTwoScore.ToString ();
						playerOneCamera.AddPower (powerBoost);
				}

				float scoreSliderValue = 0.5f - ((playerOneScore - playerTwoScore) * 0.1f);

				scoreSliderValue = Mathf.Clamp (scoreSliderValue, 0.0f, 1.0f);

				scoreSlider.value = scoreSliderValue;

				playerOneCamera.StopSequence ();
				playerTwoCamera.StopSequence ();

				playerOneCamera.KillChildren ();
				playerTwoCamera.KillChildren ();
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
				scoreParticles.SetActive (false);
				pauseButton.SetActive (true);
				for (int i = 0; i < betweenRounds; i++) {
			
						playerOneCountDown.text = (betweenRounds - i).ToString ();
						playerTwoCountDown.text = (betweenRounds - i).ToString ();
						this.gameObject.GetComponent<AudioSource>().PlayOneShot (countDown);
						yield return new WaitForSeconds (1.0f);
				}
		
				playerOneCountDown.enabled = false;
				playerTwoCountDown.enabled = false;
		
				this.gameObject.GetComponent<AudioSource>().PlayOneShot (GO);
		
				pauseButton.SetActive (false);
				scoreParticles.SetActive (true);
				currentState = GameState.IN_ROUND;


		}
	
		IEnumerator EndTimer ()
		{
				yield return new WaitForSeconds (endTimer);
				Application.LoadLevel ("Menu");
		}
}
