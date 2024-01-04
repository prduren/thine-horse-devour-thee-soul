using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    [SerializeField] private PixelStylizerCamera pixelStylizerCamera;
    public Image IntroImg;
    public Image InstructionsImg;
    private bool continueFlag = false;

    void Start() {
        pixelStylizerCamera.SetPreset(ApplicationData.savedPresetColor);
    }

    void Update()
    {
        if (continueFlag) {
            if (Input.GetKeyDown(KeyCode.Return) | Input.GetMouseButtonDown(0)) {
                SceneManager.LoadScene("L1");
            }
        }
        if (Input.GetKeyDown(KeyCode.Return) | Input.GetMouseButtonDown(0)) {
            continueFlag = true;
            IntroImg.enabled = false;
            InstructionsImg.enabled = true;
        }
    }
}
