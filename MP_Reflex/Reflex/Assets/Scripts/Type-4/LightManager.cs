using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{

    public List<GameObject> lights;

    private float timeBetweenLights = 0;
    private int redOrGreen;
    private int LightCount;
    private TimedClick clickItem;

    private bool greenLightLit;

    public Material redMaterial;
    public Material greenMaterial;

    private void Start () {
        clickItem = GameObject.Find ("Manager").GetComponent<TimedClick> ();
    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenLights += Time.deltaTime;

        if (greenLightLit == false) {
            ChooseLights ();
        }
    }

    private void ChooseLights () {
        if (timeBetweenLights >= 3) {
            redOrGreen = Random.Range (0, 5);
            
            if (LightCount == 4) {

                lights[LightCount].GetComponent<Renderer> ().material = greenMaterial;
                greenLightLit = true;
                clickItem.greenLightDone = true;
                timeBetweenLights = 0;
                LightCount++;
            }

            if (redOrGreen <= 3) {

                lights[LightCount].GetComponent<Renderer> ().material = redMaterial;
                timeBetweenLights = 0;
                LightCount++;
            } else {

                lights[LightCount].GetComponent<Renderer> ().material = greenMaterial;
                greenLightLit = true;
                clickItem.greenLightDone = true;
                timeBetweenLights = 0;
                LightCount++;
            }
        }
    }
}
