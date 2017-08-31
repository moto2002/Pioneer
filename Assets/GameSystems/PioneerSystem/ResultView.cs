﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultView : MonoBehaviour {
    public Text resultText;

    public void setText(string text){
        resultText.text = text;
    }

    public void finishPlaying(){
        Debug.Log("called");
        PioneerManager.getInstance().finished();
        SceneManager.LoadScene("Title");
        Destroy(gameObject);
    }
}
