using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour
{
    #region PUBLIC_VARS

    // public static List<string> objs = new List<string>();
    public static DDOL instance;

    #endregion

    #region PRIVATE_VARS

    #endregion

    #region UNITY_CALLBACKS

    void Awake()
    {
        if(DDOL.instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }else
        {
            Destroy(gameObject);
        }

        // if (objs.Contains(name))
        // {
        //     Destroy(gameObject);
        // }
        // else
        // {
        //     objs.Add(name);
        //     DontDestroyOnLoad(gameObject);
        //     for (int i = 0; i < transform.childCount; i++)
        //     {
        //         transform.GetChild(i).gameObject.SetActive(true);
        //     }
        // }
    }

    #endregion

    #region PUBLIC_FUNCTIONS
    public void StartLoading()
    {
        StartCoroutine(LoadingCoroutine());
    }
    #endregion

    #region PRIVATE_FUNCTIONS

    #endregion

    #region CO-ROUTINES
    IEnumerator  LoadingCoroutine()
    {
        Image myImage = this.gameObject.GetComponent<Image>();
        myImage.raycastTarget = true;
        float time = 0.5f;
        float rate = 2 / time;
        

        float t =0;
        Color col = myImage.color;
        col.a = 1;
            myImage.color = col;

        while(t <= 1f)
        {
            t += rate * Time.deltaTime;
            // col = myImage.color;
            // col.a = Mathf.Lerp(0,1,t);
            // myImage.color = col;
            yield return 0;
        }

		SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
        
        t =0 ;
        while(t <= 1f)
        {
            t += rate * Time.deltaTime;
            col = myImage.color;
            col.a = Mathf.Lerp(1,0,t);
            myImage.color = col;
            yield return 0;
        }

        myImage.raycastTarget = false;
    }
    #endregion

    #region EVENT_HANDLERS

    #endregion

    #region UI_CALLBACKS

    #endregion
}