using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridStat : MonoBehaviour
{
    //Variables for the getting the number the prefab must have and the randomprefab.
    public GameObject[] prefabList;
    private GameObject rPrefab;

    //Boolean to check if item is spawned.
    private bool itemSpawned = false;

    //Number of wich number this grid prefab is.
    private int instantiateNum;
    
    //Integers so the grid prefabs knows where to spawn.
    public int x = 0;
    public int y = 0;

    // Update is called once per frame
    void Update()
    {
        //check if the item is spawned if not spawn it.
        if (itemSpawned == false) {
            rPrefab = getBuilding ();
            GameObject spawnedPrefab = Instantiate (rPrefab, this.transform.position, rPrefab.transform.rotation) as GameObject;
            spawnedPrefab.name = rPrefab.name;
            Destroy (this.gameObject);
            itemSpawned = true;
        }
    }

    //Get the number wich the grid prefab is.
    private GameObject getBuilding () {
        return prefabList[instantiateNum]; 
    }

    //Get the number wich the grid prefab is.
    public void getInstantiateInt (int rand) {
        instantiateNum = rand;
    }
}
