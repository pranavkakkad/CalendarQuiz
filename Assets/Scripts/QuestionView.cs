using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestionView : MonoBehaviour {

	public Questions quest;	
	public DaysDisplay daysDisplay;
	public Text textCalendar;
	public Text textNormal;
	public Text COption1;
	public Text COption2;
	public Text COption3;
	public Text COption4;

	public Text NOption1;
	public Text NOption2;
	public Text NOption3;
	public Text NOption4;
	private int questionNumber;
	public int number=50;
	
	bool GameIsPaused=false;
	private int initScore=0;
	public Text score;
[	Header("QuestionTypeReference")]
	public NormalView normalPannel;
    public CalendarView  calendarPannel;
	
	[	Header("Button Color")]
	public GameObject button1;
	public GameObject button2;
	public GameObject button3;
	public GameObject button4;
	public GameObject button5;
	public GameObject button6;
	public GameObject button7;
	public GameObject button8;
	public void initialize(){
		// Debug.Log("1");
		// calendarPannel.ShowView();
		// Debug.Log("2");
		// calendarPannel.HideView();
		// Debug.Log("3");
		Debug.Log("1");
		calendarPannel.gameObject.SetActive(true);
		calendarPannel.daysDisplay.InitDaysDisplay();
		InitQuestion();
		// UIManager.Instance.questionViewPannel.calendarPannel.ShowView();
		
	}
	void InitQuestion()
	{

		Debug.Log("Question View Start");
		quest.QuestionCreator(number);
		display();
		
		// for(int i=0;i<50;i++){
		// 	Debug.Log(quest.questionList[i].question);
		// }
	}

	public void display(){
		
		questionNumber = Random.Range(0,quest.questionList.Count);
		Debug.Log(questionNumber);
		ChangeColor();
		Debug.LogError(quest.questionList[questionNumber].isCalendarView);
		if(quest.questionList[questionNumber].isCalendarView){
			normalPannel.HideView();
			calendarPannel.ShowView();

			textCalendar.text =quest.questionList[questionNumber].question;
			COption1.text = quest.questionList[questionNumber].option1;
			COption2.text = quest.questionList[questionNumber].option2;
			COption3.text = quest.questionList[questionNumber].option3;
			COption4.text = quest.questionList[questionNumber].option4;
			
		}
		else{
			calendarPannel.HideView();
			normalPannel.ShowView();
			Debug.Log(quest.questionList[questionNumber].question);
			textNormal.text =quest.questionList[questionNumber].question;
			NOption1.text = quest.questionList[questionNumber].option1;
			NOption2.text = quest.questionList[questionNumber].option2;
			NOption3.text = quest.questionList[questionNumber].option3;
			NOption4.text = quest.questionList[questionNumber].option4;
			
		}
	}

	public void Compare(Text buttontext){
		
		if(buttontext.text==quest.questionList[questionNumber].answer){
			Debug.Log("Yes");
			quest.questionList.RemoveAt(questionNumber);
			Debug.Log(quest.questionList.Count);
			buttontext.transform.parent.gameObject.GetComponent<Image>().color=Color.green;
			// buttontext.transform.parent.gameObject.GetComponent<Image>().color=Color.white;
			// calendarPannel.daysDisplay.InitDaysDisplay();
			
			initScore=initScore+1;
			score.text = initScore.ToString();
			DataManager.instance.setCurrentScore(initScore);
			Invoke("display",0.1f);
		}
		else {
			Debug.Log("No");
			buttontext.transform.parent.gameObject.GetComponent<Image>().color=Color.red;
			
			Invoke("display",0.1f);
		}
		
	}
	public void ChangeColor(){
		button1.GetComponent<Image>().color=Color.white;
		button2.GetComponent<Image>().color=Color.white;
		button3.GetComponent<Image>().color=Color.white;
		button4.GetComponent<Image>().color=Color.white;
		button5.GetComponent<Image>().color=Color.white;
		button6.GetComponent<Image>().color=Color.white;
		button7.GetComponent<Image>().color=Color.white;
		button8.GetComponent<Image>().color=Color.white;
	}

	public void onPause(){
		Debug.Log("PAuse button Pressed");
		UIManager.Instance.pauseView.ShowView();
		Time.timeScale=0f;
		GameIsPaused=true;

	}

}
