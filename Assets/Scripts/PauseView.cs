using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseView : BaseView {

    public void OnResumePlay(){
        Time.timeScale=1.0f;
        UIManager.Instance.pauseView.HideView();
    }
    public void GoHome(){
        Time.timeScale=1.0f;
        UIManager.Instance.pauseView.HideView();
        UIManager.Instance.questionPannel.HideView();
        UIManager.Instance.homeView.ShowView();
        FindObjectOfType<GameManager>().EndGame();
    }

}
