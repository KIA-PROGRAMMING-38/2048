using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : MonoBehaviour
{
    public GameObject[] tile;

    int x, y;
    GameObject[,] Square = new GameObject[4, 4];

    void Start()
    {
        Spawn();
        Spawn();
    }
 
    void Spawn()
    {
        while (true)
        {
            x = Random.Range(0, 4); 
            y = Random.Range(0, 4);
            
            if (Square[x, y] == null)
            {
                break;
            }
        }
        Square[x, y] = Instantiate(Random.Range(0, 8) > 0 ? tile[0] : tile[1], new Vector3(1.2f * x - 1.8f, 1.2f * y - 1.8f, 0), Quaternion.identity);
        Square[x, y].GetComponent<Animator>().SetTrigger("Spawn");
    }
}
