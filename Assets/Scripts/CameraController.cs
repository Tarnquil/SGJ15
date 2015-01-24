﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	enum Powers
	{
		Shake,
		Shrink
	}
	public float shakeX = 1;
	public float shakeY = 1;
	public float shakeTime = 1;
	public float shakeEndTime = 5;

	bool shrinking = false;
	public float shrinkPos = 0.12f;
	public float normalPos = 0.5f;

	// Use this for initialization
	void Start()
	{
		//	ReduceSize();
	}
	
	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.S))
		{
			ShakeCamera();
		}

		if(Input.GetKeyDown(KeyCode.D))
		{
			shrinking = !shrinking;
		}

		if(shrinking)
		{
			ReduceSize();
		} else
		{
			IncreaseSize();
		}
	}

	public void UsePower(int _power)
	{
		switch((Powers)_power)
		{
			case Powers.Shake:
				ShakeCamera();
				break;
			case Powers.Shrink:
				shrinking = true;
				StopCoroutine("StopShrink");
				StartCoroutine("StopShrink");
		
				;
				break;
		}
	}

	public void ShakeCamera()
	{
		iTween.ShakePosition(this.gameObject, iTween.Hash("x", shakeX, "y", shakeY, "time", shakeTime, "looptype", "loop"));
		Invoke("StopTween", shakeEndTime);
	}

	void ReduceSize()
	{
		this.gameObject.camera.rect = iTween.RectUpdate(this.gameObject.camera.rect, new Rect(shrinkPos, 0.25f, 0.25f, 0.5f), 3.0f);
	}
	void IncreaseSize()
	{
		this.gameObject.camera.rect = iTween.RectUpdate(this.gameObject.camera.rect, new Rect(normalPos, 0, 0.5f, 1), 3.0f);
	}
	void StopTween()
	{
		iTween.Stop(this.gameObject);
	}
	IEnumerator StopShrink()
	{
		yield return new WaitForSeconds(5.0f);
		shrinking = false;
	}
}
