using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemScaler : MonoBehaviour
{
    //Variable for health manager to change health manager
    private HealthManager healthMan;

    // Start is called before the first frame update
    void Start()
    {
        //Find healthmanager in scene
        healthMan = GameObject.Find ("HealthManager").GetComponent<HealthManager> ();

        //Check to see if this is the right scene for this script otherwise destroy it.
        if (SceneManager.GetActiveScene().name != "Type-2") {
            Destroy (this.GetComponent<ItemScaler>());
        } else{
            //First make the items scale 0 then start scaling up. set the gravity false so the items stay still in the scene.
            this.transform.localScale = new Vector3 (0, 0, 0);
            StartCoroutine (UpScalingOverTime (1));
            this.GetComponent<Rigidbody> ().useGravity = false;
        }
    }

    IEnumerator UpScalingOverTime (float time) {
        //Save the scale before we start scaling and set a scale where we want to stop scaling,
        Vector3 originalScale = this.transform.localScale;
        Vector3 destinationScale = new Vector3 (1.5f, 1.5f, 1.5f);

        //Currenttime to check when to stop scaling
        float currentTime = 0.0f;

        //Scale the item till its on the max scale we set at the beginning.
        do {
            this.transform.localScale = Vector3.Lerp (originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);

        //Start down scaling if up scaling is done.
        StartCoroutine (DownScalingOverTime (1));
    }

    IEnumerator DownScalingOverTime (float time) {
        //Save the scale before we start scaling and set a scale where we want to stop scaling,
        Vector3 originalScale = this.transform.localScale;
        Vector3 destinationScale = new Vector3 (0, 0, 0);

        //Currenttime to check when to stop scaling
        float currentTime = 0.0f;

        //Scale the item till its on the max scale we set at the beginning.
        do {
            this.transform.localScale = Vector3.Lerp (originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
        
        //Remove health if the item is back to scale 0 because player is too late the destroy item so it doesn't stay in the scene forever.
        healthMan.MinusHealth (1);
        Destroy (gameObject);
    }
}
