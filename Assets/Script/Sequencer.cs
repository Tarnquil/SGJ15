﻿using UnityEngine;
using System.Collections;

public class Sequencer : MonoBehaviour
{
		public GameObject[] sequences;
		public int sequenceNumber = 0;
		public bool bombs;
		public GameController cont;
		public int playerNumber = 0;
		// Use this for initialization

		void Start ()
		{
				SpawnSequence ();
		}
		
		public void FinishedSequence ()
		{
				cont.FinishedSequence (playerNumber);
		}

		public void SpawnSequence ()
		{
				GameObject obj = Instantiate (sequences [sequenceNumber],
		                              this.gameObject.transform.position, 
		                             this.gameObject.transform.rotation) as GameObject;
				obj.transform.parent = this.gameObject.transform;
				sequenceNumber++;
				if (bombs) {
						bombs = false;
						obj.GetComponent<TapSequence> ().bombs = true;
				}

		}
}
