using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Xml;

public class CameraController : MonoBehaviour
{
		enum Powers
		{
				Shake,
				Shrink,
				Bombs
		}
		public Sprite[] icons;
		public int playerNumber = 0;
		public int currentPower = 0;
		public int numberOfDotsInSequence;
		public int tappedDots = 0;
		public float shakeX = 1;
		public float shakeY = 1;
		public float shakeTime = 1;
		public float shakeEndTime = 5;
		public float rotatePowerTimer;
		public AudioClip Shake;
		public AudioClip Shrink;
		public AudioClip Expand;
		public bool spawnBombs;
		public bool shrinking = false;
		public float shrinkPos = 0.12f;
		public float normalPos = 0.5f;
		public float startX = 0;
		public float timeBetweenDots;
		public GameObject dotTemplate;
		public GameObject bombTemplate;
		public GameObject background;
		public Slider slider;
		public Image activePower;
		public Image powerBorder;
		public Sprite normalPowerFrame;
		public Sprite activePowerFrame;
		public GameController cont;
		XmlNode currentSequence;
		// Use this for initialization
		void Start ()
		{
				StartCoroutine ("PowerSlotMachine");
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.S)) {
						ShakeCamera ();
				}

				if (Input.GetKeyDown (KeyCode.D)) {
						shrinking = !shrinking;
				}

				if (shrinking) {
						ReduceSize ();
				} else {
						IncreaseSize ();
				}
		}

		public void StartSequence (XmlNode _node)
		{
				currentSequence = _node;
				StartCoroutine ("SpawnDots");
				tappedDots = 0;
				if (spawnBombs) {
						spawnBombs = false;
						StartCoroutine ("SpawnBombs");
				}
		}


		IEnumerator SpawnDots ()
		{
				XmlNodeList dots = currentSequence.SelectNodes (@"dot");
				numberOfDotsInSequence = dots.Count;
				for (int i = 0; i< dots.Count; i++) {
			
						yield return new WaitForSeconds (timeBetweenDots);
			
						GameObject newDot = (GameObject)Instantiate (dotTemplate);
						newDot.transform.parent = background.transform;
			
						Vector2 newPos = new Vector2 ();
						newPos.x = float.Parse (dots [i].Attributes ["x"].Value.ToString ());
						newPos.y = float.Parse (dots [i].Attributes ["y"].Value.ToString ());
			
						newDot.transform.localPosition = newPos;
						newDot.GetComponent<TapObject> ().cont = this;
						newDot.name = "Dot" + (i + 1);
				}
		}

		IEnumerator SpawnBombs ()
		{
				XmlNodeList dots = currentSequence.SelectNodes (@"bomb");
				for (int i = 0; i< dots.Count; i++) {
			
						yield return new WaitForSeconds (timeBetweenDots);
			
						GameObject newDot = (GameObject)Instantiate (bombTemplate);
						newDot.transform.parent = background.transform;
			
						Vector2 newPos = new Vector2 ();
						newPos.x = float.Parse (dots [i].Attributes ["x"].Value.ToString ());
						newPos.y = float.Parse (dots [i].Attributes ["y"].Value.ToString ());
			
						newDot.transform.localPosition = newPos;
						newDot.GetComponent<TapBomb> ().cont = this;
						newDot.name = "Bomb" + (i + 1);
				}
		}


		public void UsePower ()
		{
				slider.value = 0;
				powerBorder.sprite = normalPowerFrame;
				switch ((Powers)currentPower) {
				case Powers.Shake:
						this.gameObject.transform.localPosition = new Vector3 (startX, 0, -10);
						ShakeCamera ();
						this.gameObject.audio.PlayOneShot (Shake);
						break;
				case Powers.Shrink:
						shrinking = true;
						StopCoroutine ("StopShrink");
						StartCoroutine ("StopShrink");
						this.gameObject.audio.PlayOneShot (Shrink);
						break;
				case Powers.Bombs:
						//sequencer.bombs = true;
						break;
				}
		}

		public void AddPower (float _amount)
		{
				slider.value += _amount;
				slider.value = Mathf.Clamp (slider.value, 0.0f, 1.0f);
				if (slider.value == 1.0f) {
						powerBorder.sprite = activePowerFrame;
				}
		}

		public void HitDot ()
		{
				AddPower (0.2f);
				tappedDots++;
				if (tappedDots == numberOfDotsInSequence) {
						cont.FinishedSequence (playerNumber);
				}
		}

		public void HitBomb ()
		{
				if (playerNumber == 1)
						cont.FinishedSequence (2);
				else
						cont.FinishedSequence (1);
		}

		public void ShakeCamera ()
		{
				iTween.ShakePosition (this.gameObject, iTween.Hash ("x", shakeX, "y", shakeY, "time", shakeTime, "looptype", "loop"));
				Invoke ("StopTween", shakeEndTime);
		}

		void ReduceSize ()
		{
				this.gameObject.camera.rect = iTween.RectUpdate (this.gameObject.camera.rect, new Rect (shrinkPos, 0.25f, 0.25f, 0.5f), 3.0f);
		}

		void IncreaseSize ()
		{
				this.gameObject.camera.rect = iTween.RectUpdate (this.gameObject.camera.rect, new Rect (normalPos, 0, 0.5f, 1), 3.0f);
		}

		void StopTween ()
		{
				iTween.Stop (this.gameObject);
				this.gameObject.transform.localPosition = new Vector3 (startX, 0, -10);
		}

		public void KillChildren ()
		{
				if (background.transform.childCount > 0) {
						Debug.Log (background.transform.childCount);
						for (int i = 0; i < background.transform.childCount; i++) {
								Destroy (background.transform.GetChild (i).gameObject);
						}
				}
		}

		IEnumerator StopShrink ()
		{
				yield return new WaitForSeconds (5.0f);
				shrinking = false;
				this.gameObject.audio.PlayOneShot (Expand);
		}

		IEnumerator PowerSlotMachine ()
		{
				yield return new WaitForSeconds (rotatePowerTimer);
				currentPower++;
				if (currentPower == icons.Length) {
						currentPower = 0;
				}
				activePower.sprite = icons [currentPower];
				StartCoroutine ("PowerSlotMachine");
		}
}
