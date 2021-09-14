using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseMenu : MonoBehaviour{

    public GameObject Panel_PauseMenu;

    private bool paused = false;


    void Start() {
        Panel_PauseMenu.SetActive(false);
    }

    void Update() {
        if (Input.GetButtonDown("Pause")) {
            paused = !paused;
    }

        if (paused) {
            Panel_PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            paused = true;
    }

        if (!paused) {
            Panel_PauseMenu.SetActive(false);
            Time.timeScale = 1f;
            paused = false;
        }
    }

    public void Resume() {
        paused = false;
    }

    public void Restart() {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void MainMenu() {
        Application.LoadLevel(0);
    }
}
