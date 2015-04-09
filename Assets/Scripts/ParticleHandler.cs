using UnityEngine;
using System.Collections;

public class ParticleHandler : MonoBehaviour 
{
	public string sortLayer = "";
	// Use this for initialization
	void Start () 
	{
		particleSystem.renderer.sortingLayerName = sortLayer;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!particleSystem.IsAlive())
		{
			Destroy(this.gameObject);
		}
	}
}
