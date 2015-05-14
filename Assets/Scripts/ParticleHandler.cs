using UnityEngine;
using System.Collections;

public class ParticleHandler : MonoBehaviour 
{
	public string sortLayer = "";
	// Use this for initialization
	void Start () 
	{
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = sortLayer;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!GetComponent<ParticleSystem>().IsAlive())
		{
			Destroy(this.gameObject);
		}
	}
}
