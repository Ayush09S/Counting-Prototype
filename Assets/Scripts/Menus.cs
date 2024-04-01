using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public static bool isGameActive;

    // Main Menu
    public GameObject title;
    public GameObject playButtonGameobject;
    public Button playButton;
    public GameObject settingsButtonGameobject;
    public Button settingsButton;

    // Settings Menu
    public TextMeshProUGUI sprintInputButton;
    public GameObject sprintInputButtonGameobject;
    public Button sprintInputButtonButton;
    public TMP_Text sprintInputText;
    public GameObject sprintInputTextGameobject;

    // Active Game GUI Game Objects
    public GameObject counterText;
    public GameObject timeText;

    // Back Arrow
    public Button backArrow;
    public GameObject backArrowGameObject;

    // Paused Game
    public GameObject transparentBlackScreen;

    // End Game
    public GameObject endGameBackground;
    public GameObject endGameTitle;
    public TMP_Text finalScoreText;
    public GameObject finalScoreGameObject;
    public Button restartButtonButton;
    public GameObject restartButtonGameObject;

    private bool isSettingsTrue;
    private bool isGameEnded;

    public float timeLeft;
    public Timer timer;

    public bool countCdrBottomHit;
    public bool countCdrTopHit;

    public GameObject crosshair;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = false;
        isGameEnded = false;
        MainMenu(true);
        ActiveGame(false);
        playButton.onClick.AddListener(ActiveGameTrue);
        sprintInputButtonButton.onClick.AddListener(SettingsMenuTrue);
        sprintInputButton.text = PlayerPrefs.GetString("SprintKey");
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = timer.timeLeft;
        if (sprintInputButton.text == "Awaiting Input") // Creates Keybind for Sprinting
        {
            foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keycode))
                {
                    sprintInputButton.text = keycode.ToString();
                    PlayerPrefs.SetString("SprintKey", keycode.ToString());
                    PlayerPrefs.Save();
                }
            }
        }
        if (isSettingsTrue == true)
        {
            MainMenu(false);
        }

        if (isGameActive)
        {
            PauseGame();
        }

        //CreateKeybind(sprintInputButton, "SprintKey");

        if (timeLeft < 0f)
        {
            EndGameStats();
        }
        Debug.Log(timeLeft);

        if (countCdrTopHit && !countCdrBottomHit)
        {

        }
    }

    public void MainMenu(bool boolean)
    {
        title.SetActive(boolean);
        playButtonGameobject.SetActive(boolean);
        settingsButtonGameobject.SetActive(boolean);
    }

    public void MainMenuTrue()
    {
        title.SetActive(true);
        playButtonGameobject.SetActive(true);
        settingsButtonGameobject.SetActive(true);
    }

    public void ActiveGame(bool boolean)
    {
        isGameActive = boolean;
        counterText.SetActive(boolean);
        timeText.SetActive(boolean);
        crosshair.SetActive(boolean);
    }

    public void ActiveGameTrue()
    {
        isGameActive = true;
        counterText.SetActive(true);
        timeText.SetActive(true);
        crosshair.SetActive(true);
    }

    public void SettingsMenu(bool boolean)
    {
        backArrowGameObject.SetActive(boolean);
        sprintInputButtonGameobject.SetActive(boolean);
        sprintInputTextGameobject.SetActive(boolean);
    }

    public void SettingsMenuTrue()
    {
        sprintInputButtonGameobject.SetActive(true);
        sprintInputTextGameobject.SetActive(true);
    }

    public void ChangeKey()
    {
        sprintInputButton.text = "Awaiting Input";
    }

    public void SetBackButton(bool boolean)
    {
        backArrowGameObject.SetActive(boolean);

    }

    public void SetBackButtonActive()
    {
        backArrowGameObject.SetActive(true);
    }

    public void MainMenuTrueSettingsFalse()
    {
        SettingsMenu(false);
        MainMenu(true);
    }
    public void EndGameStats()
    {
        Debug.Log("Endgamestats started");
        Cursor.lockState = CursorLockMode.None;
        isGameEnded = true;
        isGameActive = false;
        Time.timeScale = 0;
        endGameBackground.SetActive(true);
        endGameTitle.SetActive(true);
        finalScoreGameObject.SetActive(true);
        restartButtonGameObject.SetActive(true);
        ActiveGame(false);
        finalScoreText.text = "Final Score: " + Counter.Count;
        Debug.Log("Ended");
    }

    /*
    public void CreateKeybind(TextMeshProUGUI keybindButton, string keyName, float keyBindNumber)
    {
        if (keybindButton.text == "Awaiting Input") // Creates Keybind for Sprinting
        {
            foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keycode))
                {
                    keybindButton.text = keycode.ToString();
                    PlayerPrefs.SetString(keyName, keycode.ToString());
                    PlayerPrefs.Save();
                    CharacterController.keyBinds[1] = keycode; // Set the sprint key to the selected key
                }
            }
        }
    }*/

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Q) && isGameEnded == false)
        {
            if (transparentBlackScreen.activeInHierarchy == false)
            {
                Time.timeScale = 0;
                transparentBlackScreen.SetActive(true);
            }
            if (transparentBlackScreen.activeInHierarchy == true)
            {
                Time.timeScale = 1;
                transparentBlackScreen.SetActive(false);
            }
        }
    }

    public void ReloadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}