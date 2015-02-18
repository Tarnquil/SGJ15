﻿using UnityEngine;
using System.Collections;

public class Sequencer : MonoBehaviour
{
		
		public int sequenceNumber = 0;
		public bool bombs;
		public GameController cont;
		public int playerNumber = 0;
		// Use this for initialization

		void Start ()
		{
				//SpawnSequence ();
		}

		public void LostSequence ()
		{
				if (playerNumber == 1) {
						cont.FinishedSequence (2);
				} else {
						cont.FinishedSequence (1);
				}
		}
		
		public void FinishedSequence ()
		{
				cont.FinishedSequence (playerNumber);
		}

		public void SpawnSequence (GameObject sequence)
		{
				GameObject obj = Instantiate (sequence,
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