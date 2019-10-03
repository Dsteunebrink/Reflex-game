using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    private HealthManager healthMan;

    // Start is called before the first frame update
    void Start()
    {
        healthMan = GameObject.Find ("HealthManager").GetComponent<HealthManager> ();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;

        if(Time.timeScale == 0) {
            if (Input.GetMouseButtonDown (0)) {
                if (Physics.Raycast (ray, out hit)) {
                    if (hit.transform.CompareTag ("Item")) {
                        Destroy (hit.transform.gameObject);
                    }
                } else {
                    healthMan.MinusHealth (1);
                }
            }
        }
    }
}
