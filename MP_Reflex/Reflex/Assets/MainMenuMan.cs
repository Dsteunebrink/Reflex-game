using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMan : MonoBehaviour
{

    private GameObject mainMenuPanel;
    private GameObject optionsPanel;
    private GameObject levelSelectorPanel;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuPanel = GameObject.Find ("MainMenu");
        optionsPanel = GameObject.Find ("Options");
        levelSelectorPanel = GameObject.Find ("LevelSelector");
        optionsPanel.SetActive (false);
        levelSelectorPanel.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void GoToLevelSelector () {
        if (mainMenuPanel.activeInHierarchy == true) {

            mainMenuPanel.SetActive (false);
            levelSelectorPanel.SetActive (true);
        } else {

            mainMenuPanel.SetActive (true);
            levelSelectorPanel.SetActive (false);
        }
    }

    public void GoToOptions () {
        if (mainMenuPanel.activeInHierarchy == true) {

            mainMenuPanel.SetActive (false);
            optionsPanel.SetActive (true);
        } else {

            mainMenuPanel.SetActive (true);
            optionsPanel.SetActive (false);
        }
    }

    public void Quit () {
        Application.Quit();
    }
}
