using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Menu : MonoBehaviour
{
    [SerializeField] private PixelStylizerCamera pixelStylizerCamera;
    public static bool FullScreenMode = true;

    public void StartGame() {
        SceneManager.LoadScene("Intro");
    }

    public void Options() {
        // enable options buttons
        // also disable options buttons
    }

    public void Quit () {
        Application.Quit();
    }

    public void ToggleFullScreen() {
        if (Screen.fullScreen) {
            FullScreenMode = false;
            Screen.fullScreen = false;
        } else if (!Screen.fullScreen) {
            FullScreenMode = true;
            Screen.fullScreen = true;
        }   
    }

    public void ToggleCameraColor() {
        System.Random random = new System.Random();
        pixelStylizerCamera.SetPreset(random.Next(1, 9));
    }

}
