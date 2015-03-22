using UnityEngine;
using System.Collections;

public class SpriteScaler : MonoBehaviour
{

		[SerializeField]
		float
				cameraScale = 1.35f;
		[SerializeField]
		float
				scaleOffset = 0;
		// Use this for initialization
		void Start ()
		{
				SpriteRenderer sr = GetComponent<SpriteRenderer> ();
				if (sr == null)
						return;
		
				transform.localScale = new Vector3 (1, 1, 1);
		
				var width = sr.sprite.bounds.size.x;
				var height = sr.sprite.bounds.size.y;
		
				var worldScreenHeight = Camera.main.orthographicSize * cameraScale;
				var worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
		
				transform.localScale = new Vector3 (worldScreenHeight / height, worldScreenWidth / width, 1);

				Vector3 newPos = this.gameObject.transform.position;
				newPos.x += scaleOffset * (worldScreenWidth / width);
				this.gameObject.transform.position = newPos;
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
