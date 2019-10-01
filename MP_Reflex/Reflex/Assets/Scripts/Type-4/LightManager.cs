using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    //List with the lights.
    public List<GameObject> lights;

    //Variables for how long it takes for lights to change and if the need to be red or green. a count on wich light you are. and get the item that needs to be clicked.
    private float timeBetweenLights = 0;
    private int redOrGreen;
    private int LightCount;
    private TimedClick clickItem;

    //Boolean fopr when the green light has been lit
    private bool greenLightLit;

    //The red and green material to give to the lights.
    public Material redMaterial;
    public Material greenMaterial;

    private void Start () {
        //Find the click item in the scene
        clickItem = GameObject.Find ("Manager").GetComponent<TimedClick> ();
    }

    // Update is called once per frame
    void Update()
    {
        //Start timer
        timeBetweenLights += Time.deltaTime;

        //If the green light hasn't been lit start choosing lights.
        if (greenLightLit == false) {
            ChooseLights ();
        }
    }

    private void ChooseLights () {
        //If timer is on a certain second begin lighting a light.
        if (timeBetweenLights >= 3) {
            //Choose it het light needs to be green or red
            redOrGreen = Random.Range (0, 5);
            
            //Make light green
            if (LightCount == 4) {

                lights[LightCount].GetComponent<Renderer> ().material = greenMaterial;
                greenLightLit = true;
                clickItem.greenLightDone = true;
                timeBetweenLights = 0;
                LightCount++;
            }

            //Make light red
            if (redOrGreen <= 3) {

                lights[LightCount].GetComponent<Renderer> ().material = redMaterial;
                timeBetweenLights = 0;
                LightCount++;
            } else {
                //If the all the lights are red except the last one make it green by default.
                lights[LightCount].GetComponent<Renderer> ().material = greenMaterial;
                greenLightLit = true;
                clickItem.greenLightDone = true;
                timeBetweenLights = 0;
                LightCount++;
            }
        }
    }
}
