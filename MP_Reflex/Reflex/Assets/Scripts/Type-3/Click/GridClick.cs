using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GridClick : MonoBehaviour
{

    private GridStat gridPrefab;
    private int currentNumber = 0;

    private float timer;
    private Text finTimeText;
    private Text TimeText;

    public GameObject FinishedUI;
    private Button retryButton;

    private HealthManager healthMan;

    // Start is called before the first frame update
    void Start()
    {

        TimeText = GameObject.Find ("TimeText").GetComponent<Text> ();
        gridPrefab = GameObject.Find ("GridPrefab").GetComponent<GridStat> ();
        healthMan = GameObject.Find ("HealthManager").GetComponent <HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timer = Mathf.Round (timer * 100f) / 100f;
        TimeText.text = "Time: " + timer;

        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown (0)) {
            if (Physics.Raycast (ray, out hit)) {
                if (hit.transform.CompareTag ("Item")) {
                    if(hit.transform.name == gridPrefab.prefabList[currentNumber].name) {
                        Destroy (hit.transform.gameObject);
                        if (currentNumber == 15) {
                            Time.timeScale = 0;
                            Instantiate (FinishedUI);
                            retryButton = GameObject.Find ("FinRetryButton").GetComponent<Button> ();
                            retryButton.onClick.AddListener (Retry);

                            finTimeText = GameObject.Find ("FinTimeText").GetComponent<Text> ();
                            timer = Mathf.Round (timer * 100f) / 100f;
                            finTimeText.text = "Time: " + timer;
                        } else {
                            currentNumber++;
                        }
                    } else {
                        healthMan.MinusHealth(1);
                    }
                }
            }
        }
    }

    private void Retry () {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().name);
    }
}
