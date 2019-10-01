using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    //Variables for how big the grid must be and wich prefabs need to be used
    public int rows = 4;
    public int columns = 4;
    public int scale = 1;
    public GameObject gridPrefab;
    public Vector3 leftBottomLocation = new Vector3 (0, 0, 0);

    //Variables for the random number to give to the item.
    private int instantiateRandom = 17;
    public List<int> lastInstantiate;
    List<int> numbersToChooseFrom = new List<int> (new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15});

    // Start is called before the first frame update
    void Awake()
    {
        //if the prefab fot the grid isn't null make the grid otherwise tell the developer it isn't there.
        if (gridPrefab) 
            GeneratorGrid ();
        else Debug.Log ("missing gridPrefab, please assign");
    } 

    void GeneratorGrid () {

        //Make the grid.
        for(int i = 0; i < columns; i++) {

            for (int j = 0; j < rows; j++) {

                instantiateRandom = numbersToChooseFrom[Random.Range (0, numbersToChooseFrom.Count)];
                numbersToChooseFrom.Remove (instantiateRandom);
                
                lastInstantiate.Add (instantiateRandom);
                GameObject obj = Instantiate (gridPrefab, new Vector3 (leftBottomLocation.x + scale * i, leftBottomLocation.y, leftBottomLocation.z + scale * j), Quaternion.identity);
                obj.GetComponent<GridStat> ().getInstantiateInt (instantiateRandom);
                obj.transform.SetParent (gameObject.transform);
                obj.GetComponent<GridStat> ().x = i;
                obj.GetComponent<GridStat> ().y = j;
            }
        }
    }
}
