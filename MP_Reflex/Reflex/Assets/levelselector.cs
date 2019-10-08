using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelselector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeToType1 () {
        SceneManager.LoadSceneAsync ("Type-1");
    }
    public void changeToType2 () {
        SceneManager.LoadSceneAsync ("Type-2");
    }
    public void changeToType3 () {
        SceneManager.LoadSceneAsync ("Type-3");
    }
    public void changeToType4 () {
        SceneManager.LoadSceneAsync ("Type-4");
    }
}
