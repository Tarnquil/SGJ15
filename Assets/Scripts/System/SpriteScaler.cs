using UnityEngine;
using System.Collections;

public class SpriteScaler : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		if (sr == null) return;
		
		transform.localScale = new Vector3(1,1,1);
		
		var width = sr.sprite.bounds.size.x;
		var height = sr.sprite.bounds.size.y;
		
		var worldScreenHeight = Camera.main.orthographicSize * 1.37f;
		var worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
		
		transform.localScale = new Vector3(worldScreenHeight / height,worldScreenWidth / width,1);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
