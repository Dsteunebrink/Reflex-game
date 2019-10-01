using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManagerType1 : MonoBehaviour
{
    //Variables used in script: item prefab used for spawn, clone gameobject used to change things with instantiated objects and Vector3 randPos to get a random position for the clone.
    public GameObject item;
    private GameObject clone;
    private Vector3 randPos;
    
    //Boolean to set for when the itemSpawned
    private bool itemSpawned;

    //Timer to check when to spawn the next clone. oldtime to check how long it took to spawn the last clone. Addtime to add to the timer so the clone spawns faster everytime.
    private float timer;
    public float oldTime = 0.0f;
    private float addTime = 0.2f;

    //Healthmanager to change the health of the player.
    private HealthManager healthMan;

    void Start () {
        //Find healthmanager in scene and reset gravity.
        healthMan = GameObject.Find ("HealthManager").GetComponent<HealthManager> ();
        Physics.gravity = new Vector3 (0f, -9.8f, 0f);
    }

    private void Update () {

        //Start timer.
        timer += Time.deltaTime;

        //Check timer to spawn clone.
        if (timer > 6) {

            StartCoroutine (ItemDrop ());
            if(oldTime < 5.6f) {
                oldTime += addTime;
                timer = oldTime;
            } else {
                timer = oldTime;
            }
        }
    }

    IEnumerator ItemDrop () {
        //Check if there are too many items in the scene.
        if (GameObject.FindGameObjectsWithTag ("Item").Length < 10) {

            //make addtime lesser if the last one is already spawning fast.
            if (oldTime == 4.4f) {
                addTime = 0.1f;
            }

            //make a random pos.
            randPos = Camera.main.ViewportToWorldPoint (new Vector3 (Random.Range (0.1f, 0.9f), Random.Range (0.1f, 0.9f), 10f));
            
            //Spawn item  on random pos
            clone = Instantiate (item, randPos, Quaternion.identity);
            clone.transform.position = new Vector3 (clone.transform.position.x, -6f, 10f);
             
            yield return new WaitForSeconds (0.5f);
        }
    }

    private void OnTriggerEnter (Collider other) {
        //destroy item if it fell out of camera view and do minushelath because player missed it.
        if (other.CompareTag ("Item")) {
            healthMan.MinusHealth (1);
            Destroy (other.gameObject);
        }
    }
}
