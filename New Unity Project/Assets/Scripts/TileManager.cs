using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePreFabs;
    private float spawn_Z = 0.0f; //7.501f
    private float safe_zone= 17.0f; //7.501f
    private float tile_lenght = 15f;
    private int amount_tile_on_screen = 7;

    // X:322.5 , y:-69.5, Z:83.4

    private Transform player_transform;

    private List<GameObject> active_tiles;
   

    void Start()
    {
        active_tiles = new List<GameObject>();
        player_transform = GameObject.FindGameObjectWithTag("Player").transform;

        //SpawnTile(0);
        for (int i = 0; i < amount_tile_on_screen; i++) //amount_tile_on_screen
        {
            
            if (i<3)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(1, 3));
            }


        }
        
    }

    void Update()
    {
        if (player_transform.position.z - safe_zone > (spawn_Z-amount_tile_on_screen * tile_lenght))
        {
            SpawnTile(Random.Range(0, 3));
            DeleteTile();
        }
    }

    private void SpawnTile(int prefabIndex)
    {
        GameObject go;
        go = Instantiate(tilePreFabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawn_Z;
        spawn_Z += tile_lenght;
        active_tiles.Add(go);

    }

    private void DeleteTile()
    {
        Destroy(active_tiles[0]);
        active_tiles.RemoveAt(0);
    }
}
