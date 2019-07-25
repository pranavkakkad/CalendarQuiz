using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
	public float RestartDelay =1.0f;
	private bool isGameEnded=false;
	public void EndGame(){
		
		if(isGameEnded==false){
			isGameEnded=true;
			Debug.Log("End Game");
			// Restart();
			Invoke("Restart",RestartDelay);
		}
		
	}

	public void Restart(){
		// UIManager.Instance.questionPannel.HideView();
		// UIManager.Instance.questionViewPannel.normalPannel.HideView();
		// UIManager.Instance.questionViewPannel.calendarPannel.HideView();
		// UIManager.Instance.homeView.ShowView();
		// SceneManager.LoadScene("main");
		// SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		DDOL.instance.StartLoading();
	}
}
