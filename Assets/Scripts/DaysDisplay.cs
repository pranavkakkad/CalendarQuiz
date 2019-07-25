using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DaysDisplay : MonoBehaviour {

	private string [] Month = new string[] {"January","February","March","April","May","June","July","August","September","October","November","December"};
	private string [] Days = new string[]{"Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday"};
	private int [] day = new int[]{31,28,31,30,31,30,31,31,30,31,30,31};
	private bool isLeap;
	private Button button;
	private Text number;
	public int finalCount;
	public int getDay;
	public int month;


	// public QuestionView questionView;

	// Use this for initialization
	public void InitDaysDisplay () {
		isLeap=false;
		for(int i=1;i<=42;i++){
			Debug.Log("I : " + i);
			button = GameObject.Find(i.ToString()).GetComponent<Button>();
			// Debug.Log("Button name=>"+button.name);
			button.GetComponentInChildren<Text>().text = "";
		}
		// int a =  getWeekDay(1,2064);
		Debug.Log("QuestionDay:Start 1"+ getQuestionDay());
		Debug.Log("GetQuestionWeekDay Start 1"+ GetQuestionWeekDay());
		Debug.Log("GetMonth Start 1"+  GetMonth() );
		DisplayCalendar();

		Debug.Log("QuestionDay:Start"+ getQuestionDay());
		Debug.Log("GetQuestionWeekDay Start"+ GetQuestionWeekDay());
		Debug.Log("GetMonth Start"+  GetMonth() );
		
	}

	 void DisplayCalendar(){
		int year = Random.Range(2015,2020);
		if(year%4==0){
			isLeap=true;
		}
		month =Random.Range(0,12);
		// Debug.Log(month);
		getDay=getWeekDay(month+1,year);
		getDay=getDay%7;
		// Debug.Log("getDay"+getDay);
		// int getDay = Random.Range(0,7);//start from which day
		GameObject LastLine = GameObject.Find("LastLine");
		// Debug.Log("LastLine"+LastLine);
		LastLine.SetActive(false);
		int count=0;
		button =GameObject.Find("Month_year").GetComponent<Button>();
		string a = Month[month] +"," +year;
		// Debug.Log(a);
		button.GetComponentInChildren<Text>().text = a;
		if(month==1){
			if(isLeap){
				count=29;
			}
			else{
				count=28;
			}
		}
		else
		{
			count =day[month];
		}
		if(getDay==5 || getDay==6){
			// Day5.SetActive(true);
			// Debug.Log("Get Day"+getDay);
			if(getDay ==5){
				if(day[month]>30){
					LastLine.SetActive(true);
				}
			}
			else{
				LastLine.SetActive(true);
			}
		}
		finalCount =count;
		for(int i=1;i<=count;i++){
			Debug.Log(getDay+i);
			
			button = GameObject.Find((getDay+i).ToString()).GetComponent<Button>();

			// if(button1 == null)
			// {
			// 	Debug.LogError("Button Null : " + (getDay+i).ToString());
			// }
			// Debug.Log("Bitti name=>"+button.name);
			// Debug.Log("Button name"+button.name);
			button.GetComponentInChildren<Text>().text = i.ToString();
		}
	}
	int getWeekDay(int m,int y){
		int k=1;
		int [] zellaRule = new int[]{0,11,12,1,2,3,4,5,6,7,8,9,10};
		int a = zellaRule[m]/10;
		// Debug.Log("a:"+a);
		int D = y%100;
		D -=a;
		// Debug.Log("D:"+D);
		int C =y/100;
		// Debug.Log("C:"+C);
		// Debug.Log(zellaRule[m]);
		// Debug.Log(Mathf.FloorToInt((13*zellaRule[m]-1)/5));
		// Debug.Log(Mathf.FloorToInt(D/4));
		// Debug.Log(Mathf.FloorToInt(C/4));
		int f = k + Mathf.FloorToInt((13*zellaRule[m]-1)/5) + D + Mathf.FloorToInt(D/4) + Mathf.FloorToInt(C/4) - 2*C;
		f = (f-1)%7;
		if(f<0){
			f=f+7;
		}
		return f;
	}
	public int getQuestionDay(){
		int i =finalCount;
		// Debug.Log("getQuestionDay : 1 " + finalCount.ToString());
		return i;
	}
	public int GetQuestionWeekDay(){
		// Debug.Log("GetQuestionWeekDay : 1 " + getDay.ToString());
		return getDay;
	}
	public int GetMonth(){
		// Debug.Log("GetMonth : 1 " + month.ToString());
		return month;
	}
}
