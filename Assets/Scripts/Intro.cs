using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public Image IntroImg;
    public Image InstructionsImg;
    private bool continueFlag = false;

    void Update()
    {
        if (continueFlag) {
            if (Input.GetKeyDown(KeyCode.Return)) {
                SceneManager.LoadScene("L1");
            }
        }
        if (Input.GetKeyDown(KeyCode.Return)) {
            continueFlag = true;
            IntroImg.enabled = false;
            InstructionsImg.enabled = true;
        }
    }
}