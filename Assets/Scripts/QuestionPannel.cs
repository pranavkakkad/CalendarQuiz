using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionPannel : BaseView {
	public QuestionView questionView;

	void OnEnable(){
		// UIManager.Instance.questionViewPannel.calendarPannel.ShowView();
		questionView.initialize();

	}

}
