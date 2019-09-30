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
    public GameObject lateUI;

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
            lateUI.SetActive (true);
        }
    }

    private void Click () {
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown (0)) {
            if (Physics.Raycast (ray, out hit)) {
                if (hit.transform.CompareTag ("Item")) {
                    greenLightDone = false;
                    Destroy (hit.transform.gameObject);
                }
            }
        }
    }
}
