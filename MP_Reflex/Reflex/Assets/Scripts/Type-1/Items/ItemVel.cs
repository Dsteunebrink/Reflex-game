using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemVel : MonoBehaviour
{
    private int vel;
    private Vector3 angVel = new Vector3(10, 0, 0);
    private ItemManagerType1 manTime;

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
        //Vector3 dir = this.GetComponent<Rigidbody>().velocity;
        //float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
        transform.position += transform.forward * Time.deltaTime;
    }
}
