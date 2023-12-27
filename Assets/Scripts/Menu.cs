using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    [SerializeField] private PixelStylizerCamera pixelStylizerCamera;
    // public static bool FullScreenMode = true;
    public GameObject optionsObject;
    public GameObject optionsButton;
    public GameObject quitButton;
    public GameObject pauseMenuImage;
    string currentSceneName;
    private PlayerInput pi;

    void Start() {
        Scene currentScene = SceneManager.GetActiveScene();
        currentSceneName = currentScene.name;
        Cursor.lockState = CursorLockMode.None;
        pixelStylizerCamera.SetPreset(ApplicationData.savedPresetColor);
        if (currentSceneName == "L1") {
            pi = GameObject.Find("PlayerArmature").GetComponent<PlayerInput>();
        }
    }

    public void StartGame() {
        SceneManager.LoadScene("Intro");
    }

    public void Options() {
        if (optionsObject.activeSelf == true) {
            optionsObject.SetActive(false);
        } else if (optionsObject.activeSelf == false) {
            optionsObject.SetActive(true);
        }
    }

    public void Quit() {
        Application.Quit();
    }

    public void ToggleFullScreen() {
        if (Screen.fullScreen) {
            ApplicationData.FullScreenMode = false;
            Screen.fullScreen = false;
        } else if (!Screen.fullScreen) {
            ApplicationData.FullScreenMode = true;
            Screen.fullScreen = true;
        }   
    }

    public void ToggleCameraColor() {
        System.Random random = new System.Random();
        ApplicationData.savedPresetColor = random.Next(1, 9);
        pixelStylizerCamera.SetPreset(ApplicationData.savedPresetColor);
    }

    void Update() {
        if (currentSceneName != "Menu") {
            if (!ApplicationData.gamePaused) {
                Cursor.lockState = CursorLockMode.Locked;
                // turn on pause menu things
                pauseMenuImage.SetActive(false);
                optionsButton.SetActive(false);
                optionsObject.SetActive(false);
                quitButton.SetActive(false);
                // pi.actions.FindAction("Jump").Enable();
                // pi.actions.FindAction("Move").Enable();
            } else if (ApplicationData.gamePaused) {
                Cursor.lockState = CursorLockMode.None;
                pauseMenuImage.SetActive(true);
                optionsButton.SetActive(true);
                quitButton.SetActive(true);
                // pi.actions.FindAction("Jump").Disable();
                // pi.actions.FindAction("Move").Disable();
            }
        }
    }

}
