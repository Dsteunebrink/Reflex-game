using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemVel : MonoBehaviour
{
    private int vel;
    private Vector3 angVel = new Vector3(10, 0, 0);
    private ItemManagerType1 manTime;

    private bool right = false;
    private bool left = false;
    private bool caseDone = false;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene ().name != "Type-1") {
            Destroy (this.GetComponent<ItemVel> ());
        } else {
            manTime = GameObject.Find ("ItemManager").GetComponent<ItemManagerType1> ();

            if (manTime.oldTime <= 3.0f) {
                vel = Random.Range (10, 12);
                this.GetComponent<Rigidbody> ().velocity = vel * transform.localScale.y * this.transform.up;
            } else if (manTime.oldTime <= 4.0f) {
                vel = Random.Range (14, 18);
                Physics.gravity = new Vector3 (0f, -20.0f, 0f);
                this.GetComponent<Rigidbody> ().velocity = vel * transform.localScale.y * this.transform.up;
            } else {
                vel = Random.Range (18, 22);
                Physics.gravity = new Vector3 (0f, -35.0f, 0f);
                this.GetComponent<Rigidbody> ().velocity = vel * transform.localScale.y * this.transform.up;
            }
        }
    }

    private void Update () {
        
        /*if (caseDone == false) {
            switch (Random.Range (0, 2)) {
                case 0: right = true; break;
                case 1: left = true; break;
            }
        }*/

        if(this.transform.position.x <= 5.61 && caseDone == false) {
            right = true;
        } else if (this.transform.position.x >= 5.61 && caseDone == false) {
            left = true;
        }

        if (right == true) {
            transform.position += transform.right * Time.deltaTime;
            caseDone = true;
        } else if (left == true) {
            transform.position -= transform.right * Time.deltaTime;
            caseDone = true;
        }
    }
}
