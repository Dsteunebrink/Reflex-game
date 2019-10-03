using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Escape) && pauseMenuPanel.activeInHierarchy == false) {
            pauseMenuPanel.SetActive (true);
        } else if (Input.GetKeyDown (KeyCode.Escape) && pauseMenuPanel != null) {
            pauseMenuPanel.SetActive (false);
        }
    }

    public void Options () {
        //Get options panel.
    }

    public void Retry () {
        //When the retry is clicked reset scene.
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().name);
    }

    public void Quit () {
        //Load main menu scene.
        SceneManager.LoadSceneAsync ("Main_Menu");
    }
}
