using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
	Slider slider;
	public Sprite[] icons;
	public CameraController opCamera;
	public Image activePower;
	public float rotatePowerTimer;
	public float addedPower = 0.1f;
	public int powerNumber = 0;
	public int numberOfPowers = 2;

	// Use this for initialization
	void Start()
	{
		slider = GetComponent<Slider>();
		StartCoroutine("PowerSlotMachine");
	}
	
	// Update is called once per frame
	void Update()
	{
		//DEBUG CODE
		if(Input.GetKey(KeyCode.P))
		{
			AddPower();
		}
		if(Input.GetKey(KeyCode.A))
		{
			ResetPower();
		}
	}

	public void UsePower()
	{
		opCamera.UsePower(powerNumber);
		ResetPower();
	}

	public void AddPower()
	{
		slider.value += addedPower;
		slider.value = Mathf.Clamp(slider.value, 0.0f, 1.0f);
	}

	public void ResetPower()
	{
		slider.value = 0;
	}
	
	IEnumerator PowerSlotMachine()
	{
		yield return new WaitForSeconds(rotatePowerTimer);
		powerNumber++;
		if(powerNumber == numberOfPowers)
		{
			powerNumber = 0;
		}
		activePower.sprite = icons[powerNumber];
		StartCoroutine("PowerSlotMachine");
	}


}
