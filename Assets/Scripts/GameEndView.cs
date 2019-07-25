using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndView : BaseView {
public Text Score;
public Text setScore;
public Text HighScore;


    void Update()
    {
        string sco=Score.text;
        setScore.text="Score "+sco;

        DataManager.instance.setHighScore(int.Parse(sco));
        HighScore.text = "HighScore "+DataManager.instance.getHighScore().ToString();
    }
    public void OnReplay(){
        UIManager.Instance.gameEndView.HideView();
        UIManager.Instance.questionViewPannel.normalPannel.HideView();
        UIManager.Instance.questionViewPannel.calendarPannel.HideView();
        UIManager.Instance.questionPannel.HideView();   
        UIManager.Instance.homeView.ShowView();
        FindObjectOfType<GameManager>().EndGame();
    }


}
