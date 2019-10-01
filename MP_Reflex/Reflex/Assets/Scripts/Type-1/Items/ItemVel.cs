using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemVel : MonoBehaviour
{
    //Variable for velocity and the timer of the manager script.
    private int vel;
    private ItemManagerType1 manTime;

    //Boolean to set wich side the item has to move. and when the choosing is done
    private bool right = false;
    private bool left = false;
    private bool caseDone = false;

    // Start is called before the first frame update
    void Start()
    {
        //Check to see if this is the right scene for this script otherwise destroy it.
        if (SceneManager.GetActiveScene ().name != "Type-1") {
            Destroy (this.GetComponent<ItemVel> ());
        } else {
            //Find manager in scene.
            manTime = GameObject.Find ("ItemManager").GetComponent<ItemManagerType1> ();
            
            //Give more velocity and stronger gravity when the player is surviving long.
            if (manTime.oldTime <= 3.0f) {
                //Give random velocity to item.
                vel = Random.Range (10, 12);
                this.GetComponent<Rigidbody> ().velocity = vel * transform.localScale.y * this.transform.up;
            } else if (manTime.oldTime <= 4.0f) {
                vel = Random.Range (14, 18);
                //Make the gravity stronger.
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
        //Choose based on the starting position wich way the item should move right or left.
        if(this.transform.position.x <= 5.61 && caseDone == false) {
            right = true;
        } else if (this.transform.position.x >= 5.61 && caseDone == false) {
            left = true;
        }

        //Make the item move either right or left based on the booleans.
        if (right == true) {
            transform.position += transform.right * Time.deltaTime;
            caseDone = true;
        } else if (left == true) {
            transform.position -= transform.right * Time.deltaTime;
            caseDone = true;
        }
    }
}
