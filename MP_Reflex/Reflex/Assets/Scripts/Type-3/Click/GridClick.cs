using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GridClick : MonoBehaviour
{
    //Variables for the gridprefabs and an int to check wich number in the grid your on.
    private GridStat gridPrefab;
    private int currentNumber = 0;

    //Varibales fot timer and the text where the time must be shown.
    private float timer;
    private Text finTimeText;
    private Text TimeText;

    //Variables for the UI and the button in the UI.
    public GameObject FinishedUI;
    private Button retryButton;

    //Variable for health manager to change health manager.
    private HealthManager healthMan;

    // Start is called before the first frame update
    void Start()
    {
        //Find object in scen to connect to variables.
        TimeText = GameObject.Find ("TimeText").GetComponent<Text> ();
        gridPrefab = GameObject.Find ("GridPrefab").GetComponent<GridStat> ();
        healthMan = GameObject.Find ("HealthManager").GetComponent <HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Start timer and show it in the UI and round it up to 2 decimals.
        timer += Time.deltaTime;
        timer = Mathf.Round (timer * 100f) / 100f;
        TimeText.text = "Time: " + timer;

        // Make raycast to check if mouse is hitting something.
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;

        if (Time.timeScale == 1) {
            //Check when the mouse is hitting the good grid number otherwis take away a bit health.
            if (Input.GetMouseButtonDown (0)) {
                if (Physics.Raycast (ray, out hit)) {
                    if (hit.transform.CompareTag ("Item")) {
                        if (hit.transform.name == gridPrefab.prefabList[currentNumber].name) {
                            Destroy (hit.transform.gameObject);
                            //Check if player clicked the last number in the grid. otherwise count the number up.
                            if (currentNumber == 15) {
                                //Last number is clicked spawn the UI and give the retry button use.
                                Time.timeScale = 0;
                                Instantiate (FinishedUI);
                                retryButton = GameObject.Find ("FinRetryButton").GetComponent<Button> ();
                                retryButton.onClick.AddListener (Retry);

                                //Add the time the player has done over this type to the UI.
                                finTimeText = GameObject.Find ("FinTimeText").GetComponent<Text> ();
                                timer = Mathf.Round (timer * 100f) / 100f;
                                finTimeText.text = "Time: " + timer;
                            } else {
                                currentNumber++;
                            }
                        } else {
                            healthMan.MinusHealth (1);
                        }
                    }
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
