﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateGrid : MonoBehaviour {
    public GameObject prefab;
    public int noToCreate;

	// Use this for initialization
	void Start () {
        Populate();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Populate() {
        GameObject newObj;

        for(int i = 0; i < noToCreate; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<Image>().color = Random.ColorHSV(); 
        }
    }
}