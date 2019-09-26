using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    private int health = 3;
    public GameObject endPrefab;
    private Button retryButton;

    private bool instantiateDone;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && instantiateDone == false) {
            Instantiate (endPrefab);
            retryButton = GameObject.Find ("RetryButton").GetComponent<Button> ();
            retryButton.onClick.AddListener (retry);
            Time.timeScale = 0;
            instantiateDone = true;
        }
    }

    public void MinusHealth () {
        health--;
    }

    public void PlusHealth () {
        health++;
    }

    private void retry () {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().name);
    }
}
