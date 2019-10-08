using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public GameObject optionsMenuPanel;
    public Button backButton;

    private bool optionsActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown (KeyCode.Escape) && pauseMenuPanel.activeInHierarchy == false) {
            pauseMenuPanel.SetActive (true);
            Time.timeScale = 0;
        } else if (Input.GetKeyDown (KeyCode.Escape) && pauseMenuPanel != null) {
            pauseMenuPanel.SetActive (false);
            optionsMenuPanel.SetActive (false);
            Time.timeScale = 1;
        }
    }

    public void ActivateOptions () {
        //Activate options panel.

        backButton.onClick.AddListener (DeactivateOptions);
        optionsMenuPanel.SetActive (true);
        pauseMenuPanel.SetActive (false);
    }

    public void DeactivateOptions () {
        //Deactivate options panel.
        
        pauseMenuPanel.SetActive (true);
        optionsMenuPanel.SetActive (false);
    }

    public void Retry () {
        //When the retry is clicked reset scene.
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().name);
    }

    public void Quit () {
        //Load main menu scene.
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync ("Main_Menu");
    }

    public void ShowPanel () {
        if (pauseMenuPanel.activeInHierarchy == false) {
            pauseMenuPanel.SetActive (true);
            Time.timeScale = 0;
        } else if (pauseMenuPanel != null) {
            pauseMenuPanel.SetActive (false);
            optionsMenuPanel.SetActive (false);
            Time.timeScale = 1;
        }
    }
}
