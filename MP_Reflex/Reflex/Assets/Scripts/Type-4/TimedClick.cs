using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimedClick : MonoBehaviour
{
    //Variables to check if the green light is lit a timer and the item prefab.
    public bool greenLightDone;
    private float timer;
    private GameObject Item;

    //Variables for the texts and UI.
    public Text timeText;
    private Text finTimeText;
    public GameObject lateUI;
    public GameObject finishedUI;
    private Button retryButton;

    //Boolean to check if item is active.
    private bool ItemActive;

    private void Start () { 
        //Find the item in the scene.
        Item = GameObject.Find ("Item");
        Item.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
        //If the green light is lit start the timer and show it on the text. and activate the item.
        if (greenLightDone == true) {
            timer += Time.deltaTime;
            timer = Mathf.Round (timer * 1000f) / 1000f;
            timeText.text = "Time:" + timer;
            if (ItemActive == false) {
                Item.SetActive (true);
                ItemActive = true;
            }
            Click ();
        }
        //If the player took to long show UI and give button use.
        if (timer >= 3) {
            greenLightDone = false;
            Instantiate (lateUI);
            retryButton = GameObject.Find ("RetryButton").GetComponent<Button> ();
            retryButton.onClick.AddListener (Retry);
            timer = 0;
        }
    }

    private void Click () {
        //Check when the mouse is hitting.
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown (0)) {
            if (Physics.Raycast (ray, out hit)) {
                if (hit.transform.CompareTag ("Item")) {
                    //Spawn the UI and give the retry button use.
                    Time.timeScale = 0;
                    Instantiate (finishedUI);
                    retryButton = GameObject.Find ("FinRetryButton").GetComponent<Button> ();
                    retryButton.onClick.AddListener (Retry);

                    //Add the time the player has done over this type to the UI.
                    finTimeText = GameObject.Find ("FinTimeText").GetComponent<Text> ();
                    timer = Mathf.Round (timer * 1000f) / 1000f;
                    finTimeText.text = "Time: " + timer;
                    
                    greenLightDone = false;
                    Destroy (hit.transform.gameObject);
                }
            }
        }
    }

    private void Retry () {
        //When the retry is clicked reset scene.
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().name);
    }
}
