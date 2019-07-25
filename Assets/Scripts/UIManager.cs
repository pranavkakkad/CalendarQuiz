using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager Instance;

    public QuestionView questionViewPannel;
    public HomeView homeView;
    public PauseView pauseView;
    public QuestionPannel questionPannel;
    public GameEndView gameEndView;
    public GameObject loadingPanel;
    // public CalendarPannel calendarPannel

    void Awake()
    {
        Instance =this;    
        // questionViewPannel.calendarPannel.ShowView();
    }
    void Start()
    {
        // questionViewPannel.calendarPannel.HideView();
        homeView.ShowView();
    }
}
