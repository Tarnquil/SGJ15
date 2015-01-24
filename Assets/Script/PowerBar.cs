using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour 
{
	Slider slider;
	public GameObject[] Powers;
	GameObject currentPower;

	public float addedPower = 0.1f;

	// Use this for initialization
	void Start () 
	{
		slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update() 
	{
		if(slider.value == 1)
		{
			SelectPower();
		}
		//DEBUG CODE
		if(Input.GetKey(KeyCode.D))
		{
			AddPower();
		}
		if(Input.GetKey(KeyCode.A))
		{
			ResetPower();
		}
	}

	public void AddPower()
	{
		slider.value += addedPower;
	}

	public void ResetPower()
	{
		slider.value = 0;
	}

	void SelectPower()
	{
		int random = Random.Range(0,Powers.Length);
		currentPower = Powers[random];
		currentPower.SendMessage("Activate", SendMessageOptions.DontRequireReceiver);
	}

}
