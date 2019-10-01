using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimedClick : MonoBehaviour
{
    public bool greenLightDone;
    private float timer;
    private GameObject Item;

    public Text timeText;
    private Text finTimeText;
    public GameObject lateUI;
    public GameObject finishedUI;
    private Button retryButton;

    private bool ItemActive;

    private void Start () { 
        Item = GameObject.Find ("Item");
        Item.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
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
        if (timer >= 3) {
            greenLightDone = false;
            Instantiate (lateUI);
            retryButton = GameObject.Find ("RetryButton").GetComponent<Button> ();
            retryButton.onClick.AddListener (Retry);
            timer = 0;
        }
    }

    private void Click () {
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown (0)) {
            if (Physics.Raycast (ray, out hit)) {
                if (hit.transform.CompareTag ("Item")) {
                    Time.timeScale = 0;
                    Instantiate (finishedUI);
                    retryButton = GameObject.Find ("FinRetryButton").GetComponent<Button> ();
                    retryButton.onClick.AddListener (Retry);

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
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().name);
    }
}
