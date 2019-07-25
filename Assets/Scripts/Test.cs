using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [System.Serializable]
// public class QuestionStructure{
// 		public string question;
// 		public string option1;
// 		public string option2;
// 		public string option3;
// 		public string option4;
// 		public string answer;
// 		public bool isCalendarView; 
// }
// [System.Serializable]
public class Test: MonoBehaviour
{

	public int number=50;//No of questins;
	private string[] WeekDays = new string[] {"Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday"};
	private string [] Month = new string[] {"January","February","March","April","May","June","July","August","September","October","November","December"};
	private int [] day = new int[]{31,28,31,30,31,30,31,31,30,31,30,31};
	
	public DaysDisplay daysDisplay;

	public List <QuestionStructure> questionList =new List<QuestionStructure>();

	//1
	// How many X are there in September?
	public void DayCount(){
		// Debug.Log("Day Count");
		QuestionStructure addQuestion = new QuestionStructure();
		string ques = "How many yyy are there in month displayed?";
		if(ques.Contains("yyy")){
			// Debug.Log("Day count Logic");
			int a = Random.Range(0,7);
			ques = ques.Replace("yyy",WeekDays[a]);
			int n = daysDisplay.getQuestionDay();
			int z = daysDisplay.GetQuestionWeekDay();
			int ans = occurrenceDays(n,WeekDays[z],a);
			addQuestion.question =ques;
			addQuestion.answer=ans.ToString();
			addQuestion.option1=(Mathf.Abs(ans-1)).ToString();
			addQuestion.option2=(ans+1).ToString();
			addQuestion.option3=(ans+2).ToString();
			addQuestion.option4=ans.ToString();
			addQuestion.isCalendarView=true;
			questionList.Add(addQuestion);
			
		}	
		else{
			Debug.Log("No question possible->Day Count");
		}
		
	}
	//2
	//What is date of the first X in September?
	public void DateDisplay(){
		// Debug.Log("Date Display");
		QuestionStructure addQuestion = new QuestionStructure();
		string ques = "What is the date of the zzz yyy in month displayed?";
		if(ques.Contains("yyy")){
			int a = Random.Range(0,7);
			int b = Random.Range(1,3);
			ques =ques.Replace("yyy",WeekDays[a]);
			ques = ques.Replace("zzz",b.ToString());
			int n = daysDisplay.getQuestionDay();
			int z = daysDisplay.GetQuestionWeekDay();
			int date = DateFinder(n,z,a,b);
			addQuestion.question =ques;
			addQuestion.answer=date.ToString();
			addQuestion.option1=((date+1)%30).ToString();
			addQuestion.option2=(date+3).ToString();
			addQuestion.option3=(date).ToString();
			addQuestion.option4=(date+2).ToString();
			addQuestion.isCalendarView=true;
			questionList.Add(addQuestion);
		}
		else{
			Debug.Log("No question possible->Date Display");
		}
	}

	//3
	//What is the date 4 days after 7th September?
	public void DayAfterCount(){
		// Debug.Log("DayCount");
		QuestionStructure addQuestion = new QuestionStructure();
		string ques = "What is the date zz days after zzzth in month displayed?";
		int a = Random.Range(1,12);
		int b = Random.Range(3,18);
		if(ques.Contains("zzz")){
			ques = ques.Replace("zzz",b.ToString());
			ques=ques.Replace("zz",a.ToString());
			addQuestion.question =ques;
			addQuestion.answer=((a+b)%30).ToString();
			addQuestion.option1=((a+b+1)%30).ToString();
			addQuestion.option2=((a+b)%30).ToString();
			addQuestion.option3=((a+b+1)%30).ToString();
			addQuestion.option4=((a+b-2)%30).ToString();
			addQuestion.isCalendarView=true;
			questionList.Add(addQuestion);
			
		}
		else{
			Debug.Log("No question possible->DayCount");
		}
	}

	//4
	//What is the date of the first Sunday after 14thJuly?
	public void DateCount(){
		// Debug.Log("DateCount");
		QuestionStructure addQuestion = new QuestionStructure();
		string ques = "What is the date of the xxx yyy after zzz?";
		int a = Random.Range(1,2);
		int b = Random.Range(0,7);
		int c =Random.Range(1,12);
		int n = daysDisplay.getQuestionDay();
		int z = daysDisplay.GetQuestionWeekDay();
		int m =daysDisplay.GetMonth();
		
		if(ques.Contains("xxx")){
			ques = ques.Replace("xxx",a.ToString());
			ques=ques.Replace("yyy",WeekDays[b]);
			ques = ques.Replace("zzz",c.ToString());
			// string ans = DateAfter(n,z,a,b,c,m,0);
			int ans = DateAfter1(n,z,b,a,c,m);
			addQuestion.question =ques;
			addQuestion.answer=ans.ToString();
			addQuestion.option1=(ans+1).ToString();
			addQuestion.option2=(ans+2).ToString();
			addQuestion.option3=ans.ToString();
			addQuestion.option4=((ans-1)%day[m]).ToString();
			addQuestion.isCalendarView=true;
			questionList.Add(addQuestion);
		}
		else{
			Debug.Log("No question possible->DayCount");
		}
	}

	public int DateAfter1(int days,int firstday,int desiredDay,int a,int afterDate,int month){
		int date= afterDate;
		int counter=0;
		// int dayLeft = days-date;
		for(int i=date+1;i<=days;i++){
			if(WeekDays[i%7]==WeekDays[desiredDay]){
				counter+=1;
			}
			if(counter==a){
				return i%day[month];
			}
		}
		return date;
	}
//days,firstday,first,weekday,after
	public string DateAfter(int n,int firstday,int j,int desiredDay, int afterDate,int month,int flag){
		int counter=1;
		int i=1;
		while(counter<j){
			if(WeekDays[(i+firstday)%7]==WeekDays[desiredDay]){
				if(i>afterDate){
					counter++;
				}
			}
			i++;
			// (i)%day[month];
			if((i++)%day[month]==0){
				month++;
				i=0;
			}
			if(counter ==j){
				if(flag==0){
				return i.ToString()+Month[month];
				}
				if(flag==1){
					i=i-7;
					if(i<0)
						i=i+7;
					return i.ToString()+Month[month];
				}
			}
		}
		return (i+firstday).ToString()+Month[month];
	}



	//5
	//How many days are there in April?
	public void NumDays(){
		string [] Month = new string[] {"January","February","March","April","May","June","July","August","September","October","November","December"};
		int [] day = new int[]{31,28,31,30,31,30,31,31,30,31,30,31};
		// Debug.Log("NumDays");
		QuestionStructure addQuestion = new QuestionStructure();
		string ques = "How many days are there in xxx,yyy?";
		int a = Random.Range(0,12);
		int b=  Random.Range(1996,2100);
		int m = daysDisplay.GetMonth();
		Debug.Log(m);
		Debug.Log(Month[m]);
		
		if(ques.Contains("xxx")){
			ques = ques.Replace("xxx",Month[m]);
			ques = ques.Replace("yyy",b.ToString());
			addQuestion.question =ques;
			addQuestion.answer=day[m].ToString();
			addQuestion.option1=(day[m]+1).ToString();
			addQuestion.option2=(day[m]-1).ToString();
			addQuestion.option3=(day[m]).ToString();
			addQuestion.option4=(day[m]-2).ToString();
			addQuestion.isCalendarView=false;
			questionList.Add(addQuestion);
		}
		else{
			Debug.Log("No question possible->DayCount");
		}
	}

	//6
	//Which days are considered as weekends?
	public void Weekends(){
		// Debug.Log("Weekends");
		QuestionStructure addQuestion = new QuestionStructure();
		string ques = "Which days are considered as weekends?";
		addQuestion.question =ques;
		int m = Random.Range(5,7);
		int n=Random.Range(0,5);
		addQuestion.answer=WeekDays[m];
		addQuestion.option1=WeekDays[(n+1)%5];
		addQuestion.option2=WeekDays[(n+3)%5];
		addQuestion.option3=WeekDays[(n+2)%5];
		addQuestion.option4=WeekDays[m];
		addQuestion.isCalendarView=false;
		questionList.Add(addQuestion);
	}

	//7
	//First day of the year?
	public void FirstDay(){
		// Debug.Log("FirstDay");
		QuestionStructure addQuestion = new QuestionStructure();
		string ques = "First day of the year yyy?";
		int a =Random.Range(1996,2100);
		if(ques.Contains("yyy")){
			ques =ques.Replace("yyy",a.ToString());
			addQuestion.question =ques;
			addQuestion.answer="1st January";
			addQuestion.option1="31st December";
			addQuestion.option2="1st February";
			addQuestion.option3="1st November";
			addQuestion.option4="1st January";
			addQuestion.isCalendarView=false;
			questionList.Add(addQuestion);
		}
		else{
			Debug.Log("No question formation possible");
		}
	}

	//8
	//Last day of the year?
	public void LastDay(){
		// Debug.Log("LastDay");
		QuestionStructure addQuestion = new QuestionStructure();
		string ques  ="Last day of the year yyy?";
		int a =Random.Range(1996,2100);
		if(ques.Contains("yyy")){
			ques =ques.Replace("yyy",a.ToString());
			ques =ques.Replace("yyy",a.ToString());
			addQuestion.question =ques;
			addQuestion.answer="31st December";
			addQuestion.option1="31st December";
			addQuestion.option2="1st February";
			addQuestion.option3="1st November";
			addQuestion.option4="1st January";
			addQuestion.isCalendarView=false;
			questionList.Add(addQuestion);
		}
		else{
			Debug.Log("No question formation possible");
		}
	}

	//9
	//No of weekdays in given image
	public void numWeekDay(){
		string ques = "No of weekdays in given month";
		int a = daysDisplay.getQuestionDay();
		QuestionStructure addQuestion = new QuestionStructure();
		int z = daysDisplay.GetQuestionWeekDay();
		int n =NumberOfWeekDays(a,WeekDays[z]);
		addQuestion.question =ques;
		addQuestion.answer=n.ToString();
		addQuestion.option1=(n-1).ToString();
		addQuestion.option2=(n-2).ToString();
		addQuestion.option3=(n+1).ToString();
		addQuestion.option4=(n).ToString();
		addQuestion.isCalendarView=true;
		questionList.Add(addQuestion);
	}

	//10
	//If your birthday is on the 2nd Tuesday of august which date it would be?
	public void birthdayQuestion(){
		QuestionStructure addQuestion = new QuestionStructure();
		// Debug.Log("birthdayQuestion");
		string ques = "If your birthday is on the xxx yyy of month displayed which date it would be?";
		int a = Random.Range(1,3);
		int b =Random.Range(0,7);
		if(ques.Contains("yyy")){
			ques = ques.Replace("yyy",WeekDays[b]);
			ques = ques.Replace("xxx",a.ToString());

			int n = daysDisplay.getQuestionDay();
			int z = daysDisplay.GetQuestionWeekDay();
			int date = DateFinder(n,z,b,a);
			addQuestion.question =ques;
			addQuestion.answer=date.ToString();
			addQuestion.option1=((date+1)%30).ToString();
			addQuestion.option2=((date-1)%30).ToString();
			addQuestion.option3=(date).ToString();
			addQuestion.option4=(date+2).ToString();
			addQuestion.isCalendarView=true;
			questionList.Add(addQuestion);
		}
		else{
			Debug.Log("No question formation possible");
		}
	}

	//11
	//If your parents anniversary is 1 week before your birthday what is your parents anniversary date?
	public void AnniversaryQuestion(){
		// Debug.Log("AnniversaryQuestions");
		QuestionStructure addQuestion = new QuestionStructure();
		string ques = "If your parents anniversary is 1 week before your birthday which is on 2nd Wednesday,what is your parents anniversary date?";
		int a = Random.Range(1,4);
		int b = Random.Range(0,7);
		int c =Random.Range(1,28);
		int n = daysDisplay.getQuestionDay();
		int z = daysDisplay.GetQuestionWeekDay();
		int m =daysDisplay.GetMonth();
		int ans = FirstWedneday(n,z);
		addQuestion.question =ques;
		addQuestion.answer=ans.ToString();
		addQuestion.option1=((ans+1)).ToString();
		addQuestion.option2=((ans+3)%day[m]).ToString();
		addQuestion.option3=ans.ToString();
		addQuestion.option4=((a+2)%day[m]).ToString();
		addQuestion.isCalendarView=true;
		questionList.Add(addQuestion);

	}
	public int FirstWedneday(int days,int firstday){
		int date=1;
		for(int i=0;i<days;i++){
			if(WeekDays[(firstday+i)%7]=="Wednesday")
			{
				return date;
			}
			date +=1;
		}
		return 0;
	}

	//12
	//Abbreviation Questions!!
	public void Abbre(){
		string [] weekDayAbbre = new string []{"Mon","Tue","Wed","Thur","Fri","Sat","Sun"};
		int a = Random.Range(0,7);
		QuestionStructure addQuestion = new QuestionStructure();
		string ques = "Abbreviation for ";
		ques = ques + WeekDays[a];
		addQuestion.question =ques;
		addQuestion.answer=weekDayAbbre[(a)%6];
		addQuestion.option1=weekDayAbbre[(a+1)%6];
		addQuestion.option2=weekDayAbbre[(a+2)%6];
		addQuestion.option3=weekDayAbbre[(a+4)%6];
		addQuestion.option4=weekDayAbbre[(a)%6];
		questionList.Add(addQuestion);
	}

	//13
	//Number of months with 31 days > number of months with 30 days (True or False)
	public void TruFalse(){
		QuestionStructure addQuestion = new QuestionStructure();
		string ques = "Let A = Number of months with 30 days and B = Number of months with 31 days. Which is correct option?";
		addQuestion.question =ques;
		addQuestion.answer="A>B";
		addQuestion.option1="A<B";
		addQuestion.option2="A=B";
		addQuestion.option3="A>B";
		addQuestion.option4="A>=B";
		questionList.Add(addQuestion);

	}


	public void QuestionCreator(int number){
		
		// QuestionStructure hi = new QuestionStructure();
		// hi.question ="123";
		// hi.option1 ="10";
		// hi.option2 ="20";
		// question.Add(hi);
		// Debug.Log(hi.question);
		
		// hi.question ="1234";
		// hi.option1 ="100";
		// hi.option2 ="20";
		// question.Add(hi);
		// Debug.Log(hi.question);
		
		List<int> functionNumber =new List<int>();
		for(int i=0;i<number;i++){
			int j = Random.Range(1,14);
			if(j==1){
				DayCount();
			}
			else if(j==2){
				DateDisplay();	
			}
			else if(j==3){
				DayAfterCount();
			}
			else if(j==4){
				DateCount();
			}
			else if(j==5){
				NumDays();
			}
			else if(j==6){
				Weekends();
			}
			else if(j==7){
				FirstDay();
			}
			else if(j==8){
				LastDay();
			}
			else if(j==9){
				numWeekDay();
			}
			else if(j==10){
				birthdayQuestion();
			}
			else if(j==11){
				AnniversaryQuestion();
			}
			else if(j==12){
				Abbre();
			}
			else if(j==13){
				TruFalse();
			}
			functionNumber.Add(j);
		}
		Debug.Log("QuestionDay:"+ UIManager.Instance.questionViewPannel.daysDisplay.getQuestionDay());
		Debug.Log("GetQuestionWeekDay "+daysDisplay.GetQuestionWeekDay());
		Debug.Log("GetMonth "+daysDisplay.GetMonth() );
	}


	public int occurrenceDays(int n,string firstday,int desiredDay) 
    { 
        int[] count = new int[7]; 
          
        for (int i = 0; i < 7; i++) 
            count[i] = 4; 

        int pos = 0; 
        for (int i = 0; i < 7; i++) 
        { 
            if (firstday == WeekDays[i])  
            { 
                pos = i; 
                break; 
            } 
        } 
        int inc = n - 28; 
		for (int i = pos; i < pos + inc; i++) 
        { 
            if (i > 6) 
                count[i % 7] = 5; 
            else
                count[i] = 5; 
        }
		return count[desiredDay];
       
    } 

	//days,firstday,desired day,dayAfter
	public int DateFinder(int n,int firstday,int desiredDay, int j){
		int counter=1;
		int i=1;
		
		int month = daysDisplay.GetMonth();
		while(counter<j){
			if(WeekDays[(i+firstday)%7]==WeekDays[desiredDay]){
				counter++;
			}
			i++;
			if((i++)%day[month]==0){
				month++;
				i=0;
			}
			
			if(counter ==j){
				i=i-1;
				if(i<0)
					i=i+7;
				return i;
			}
		}
		return 0;
	}

	

	public int NumberOfWeekDays(int n,string firstday) 
    { 
        int[] count = new int[7]; 
          
        for (int i = 0; i < 7; i++) 
            count[i] = 4; 

        int pos = 0; 
        for (int i = 0; i < 7; i++) 
        { 
            if (firstday == WeekDays[i])  
            { 
                pos = i; 
                break; 
            } 
        } 
        int inc = n - 28; 
		for (int i = pos; i < pos + inc; i++) 
        { 
            if (i > 6) 
                count[i % 7] = 5; 
            else
                count[i] = 5; 
        }
		int finalCount=0;
		for(int i =0;i<5;i++){
			finalCount += count[i];
		}
       return finalCount;
    } 
	public int WeekDayFormula(int days,int afterDate,int desiredDay,int round){
		int []dayNumber =new int[]{2,3,4,5,6,7,1};
		int a = afterDate+7-(afterDate+7-dayNumber[desiredDay]);
		a = a%days;
		return a;
	}
	void Start()
	{
		// QuestionCreator(number);
		
		// for(int i=0;i<50;i++){
		// 	// Debug.Log(questionList[i].question);
		// 	if(questionList[i].isCalendarView)
		// }

		// public int DateAfter1(int days,int firstday,int desiredDay,int a,int afterDate,int month){
		// int a = DateAfter1(31,2,3,,10,8);
		
		
		// Debug.Log(a);
		// NumDays
		Debug.Log("Hi");
		int a =WeekDayFormula(31,10,2,1);
		Debug.Log(a);

		
	}
	
}
