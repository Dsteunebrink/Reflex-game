using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridStat : MonoBehaviour
{

    public GameObject[] prefabList;
    private GameObject rPrefab;

    private bool itemSpawned = false;

    private int instantiateNum;

    public int visited = -1;
    public int x = 0;
    public int y = 0;

    // Update is called once per frame
    void Update()
    {

        if (itemSpawned == false) {
            rPrefab = getBuilding ();
            GameObject spawnedPrefab = Instantiate (rPrefab, this.transform.position, rPrefab.transform.rotation) as GameObject;
            spawnedPrefab.name = rPrefab.name;
            Destroy (this.gameObject);
            itemSpawned = true;
        }
    }

    private GameObject getBuilding () {
        return prefabList[instantiateNum]; 
    }

    public void getInstantiateInt (int rand) {
        instantiateNum = rand;
    }
}
