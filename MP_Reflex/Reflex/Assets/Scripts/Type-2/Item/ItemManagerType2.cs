using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManagerType2 : MonoBehaviour {

    public GameObject item;
    private GameObject clone;
    private Vector3 randPos;
    private bool itemSpawned;

    private float timer;
    private float oldTime = 0.0f;
    private float addTime = 0.2f;

    private HealthManager healthMan;

    private ItemScaler itemScaler;

    void Start () {
        healthMan = GameObject.Find ("HealthManager").GetComponent<HealthManager> ();
    }

    private void Update () {

        timer += Time.deltaTime;

        if (timer > 6) {

            StartCoroutine (ItemDrop ());
            if (oldTime < 5.6f) {
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
            if (oldTime > 3.0f) {
                clone = Instantiate (item, randPos, Quaternion.identity);
                clone.GetComponent<Rigidbody> ().useGravity = false;
            }

            randPos = Camera.main.ViewportToWorldPoint (
            new Vector3 (Random.Range (0.1f, 0.9f), Random.Range (0.1f, 0.9f), 10f));

            clone = Instantiate (item, randPos, Quaternion.identity);
            clone.GetComponent<Rigidbody> ().useGravity = false;

            yield return new WaitForSeconds (0.5f);

        }
    }
}
