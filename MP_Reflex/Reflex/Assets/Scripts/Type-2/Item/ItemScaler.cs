using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemScaler : MonoBehaviour
{

    private float timer;

    private HealthManager healthMan;

    // Start is called before the first frame update
    void Start()
    {
        healthMan = GameObject.Find ("HealthManager").GetComponent<HealthManager> ();
        if (SceneManager.GetActiveScene().name != "Type-2") {
            Destroy (this.GetComponent<ItemScaler>());
        } else{
            this.transform.localScale = new Vector3 (0, 0, 0);
            StartCoroutine (UpScalingOverTime (1));
            this.GetComponent<Rigidbody> ().useGravity = false;
        }
    }

    IEnumerator UpScalingOverTime (float time) {
        Vector3 originalScale = this.transform.localScale;
        Vector3 destinationScale = new Vector3 (1.5f, 1.5f, 1.5f);

        float currentTime = 0.0f;

        do {
            this.transform.localScale = Vector3.Lerp (originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);

        StartCoroutine (DownScalingOverTime (1));
    }

    IEnumerator DownScalingOverTime (float time) {
        Vector3 originalScale = this.transform.localScale;
        Vector3 destinationScale = new Vector3 (0, 0, 0);

        float currentTime = 0.0f;

        do {
            this.transform.localScale = Vector3.Lerp (originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
        
        healthMan.MinusHealth (1);
        Destroy (gameObject);
    }
}
