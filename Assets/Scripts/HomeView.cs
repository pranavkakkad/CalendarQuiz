using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeView : BaseView {

	public void OnPlay(){
		HideView();
		UIManager.Instance.questionPannel.ShowView();
	}
}
