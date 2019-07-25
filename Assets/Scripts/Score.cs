using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText;
	
	// var i = int.Parse("1");
	// Use this for initialization
	void Start () {
		scoreText.text=0.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
