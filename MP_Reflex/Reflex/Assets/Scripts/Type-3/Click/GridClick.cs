using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridClick : MonoBehaviour
{

    private GridStat gridPrefab;
    private int currentNumber = 0;

    private HealthManager healthMan;

    // Start is called before the first frame update
    void Start()
    {
        gridPrefab = GameObject.Find ("GridPrefab").GetComponent<GridStat> ();
        healthMan = GameObject.Find ("HealthManager").GetComponent <HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown (0)) {
            if (Physics.Raycast (ray, out hit)) {
                if (hit.transform.CompareTag ("Item")) {
                    if(hit.transform.name == gridPrefab.prefabList[currentNumber].name) {
                        Destroy (hit.transform.gameObject);
                        currentNumber++;
                    } else {
                        healthMan.MinusHealth();
                    }
                }
            }
        }
    }
}
