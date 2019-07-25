using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
	float currentTime=0;
	public float startingTime=60;
	

	[SerializeField] Text countDownText;
	// Use this for initialization
	void Start () {
		currentTime=startingTime;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime -=1*Time.deltaTime;
		countDownText.text = currentTime.ToString("0");

		if(currentTime<0){
			currentTime=0;
			// UIManager.Instance.questionViewPannel.HideView();
			UIManager.Instance.questionViewPannel.normalPannel.HideView();
        	UIManager.Instance.questionViewPannel.calendarPannel.HideView();
        	UIManager.Instance.questionPannel.HideView();   
			UIManager.Instance.gameEndView.ShowView();
		}
	}

	
}
