using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour 
{
	public Text text;
	Slider slider;
	public float addedPower = 0.1f;
	// Use this for initialization
	void Start () 
	{
		slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update() 
	{
		text.text = Mathf.Floor(Time.time).ToString();

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
}
