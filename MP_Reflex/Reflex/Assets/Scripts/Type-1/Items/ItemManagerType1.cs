using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManagerType1 : MonoBehaviour
{
    public GameObject item;
    private GameObject clone;
    private int xPos;
    private int zPos;
    
    private int itemCount;
    private bool itemSpawned;

    private float timer;
    public float oldTime = 0.0f;
    private float addTime = 0.2f;

    private HealthManager healthMan;

    void Start () {
        healthMan = GameObject.Find ("HealthManager").GetComponent<HealthManager> ();
    }

    private void Update () {

        timer += Time.deltaTime;

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
        if (GameObject.FindGameObjectsWithTag ("Item").Length < 10) {

            if (oldTime == 4.4f) {
                addTime = 0.1f;
            }

            xPos = Random.Range (-4, 4);
            zPos = Random.Range (5, 8);
            
            if (oldTime <= 3.0f) {
                clone = Instantiate (item, new Vector3 (xPos, -5, zPos), Quaternion.identity);
            } else if (oldTime<= 4.0f){
                clone = Instantiate (item, new Vector3 (xPos, -5, zPos), Quaternion.identity);
            } else {
                clone = Instantiate (item, new Vector3 (xPos, -5, zPos), Quaternion.identity);
            }

            yield return new WaitForSeconds (0.5f);
            itemCount += 1;

        }
    }

    private void OnTriggerEnter (Collider other) {
        if (other.CompareTag ("Item")) {
            itemCount -= 1;
            healthMan.MinusHealth ();
            Destroy (other.gameObject);
        }
    }
}
