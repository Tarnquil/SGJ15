using UnityEngine;
using System.Collections;

public class ITweenUIMove : MonoBehaviour 
{
	public bool onStart = false;

	RectTransform rectTrans;

	public float x, y;
	public float timeToComplete = 5.0f;
	public float delay = 0;
	public GameObject onCompleteTarget;
	public string onCompleteMethod = "";
	// Use this for initialization
	void Start () 
	{
		rectTrans = GetComponent<RectTransform>();

		if(onStart)
		{
			MoveTween();
		}
	}

	void UpdatePosition(Vector2 newPos)
	{
		rectTrans.anchoredPosition = newPos;
	}

	public void MoveTween()
	{
		if(onCompleteTarget != null)
		{
			iTween.ValueTo(this.gameObject, iTween.Hash("from",rectTrans.anchoredPosition, "to", new Vector2(x,y), "time", timeToComplete, "delay", delay, "onupdate","UpdatePosition","oncomplete",onCompleteMethod,"oncompletetarget",onCompleteTarget));
		}
		else
		{
			iTween.ValueTo(this.gameObject, iTween.Hash("from",rectTrans.anchoredPosition, "to", new Vector2(x,y), "time", timeToComplete, "delay", delay, "onupdate","UpdatePosition"));
		}
	}
}
