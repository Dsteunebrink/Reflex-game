using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManagerType2 : MonoBehaviour {

    public GameObject item;
    private GameObject clone;
    private int xPos;
    private int zPos;
    private int yPos;
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
                clone = Instantiate (item, new Vector3 (xPos, yPos, zPos), Quaternion.identity);
                clone.GetComponent<Rigidbody> ().useGravity = false;
            }

            xPos = Random.Range (-4, 4);
            zPos = Random.Range (8, 10);
            yPos = Random.Range (-4 , 4);

            clone = Instantiate (item, new Vector3 (xPos, yPos, zPos), Quaternion.identity);
            clone.GetComponent<Rigidbody> ().useGravity = false;

            yield return new WaitForSeconds (0.5f);

        }
    }
}
