using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManagerType1 : MonoBehaviour
{
    public GameObject item;
    private GameObject clone;
    private int xPos;
    private int zPos;
    private Vector3 randPos;
    
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

            randPos = Camera.main.ViewportToWorldPoint (new Vector3 (Random.Range (0.1f, 0.9f), Random.Range (0.1f, 0.9f), 10f));
            
            Debug.Log (randPos);
            clone = Instantiate (item, randPos, Quaternion.identity);
            clone.transform.position = new Vector3 (clone.transform.position.x, -6f, 10f);
             
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
