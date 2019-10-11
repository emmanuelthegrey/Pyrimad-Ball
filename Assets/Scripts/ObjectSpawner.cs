using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject[] trianglePrefabs;
    private Vector3 spawnObstaclePosition;

    // Update is called once per frame
    void Update()
    {
        float distanceToHorizon = Vector3.Distance(player.gameObject.transform.position, spawnObstaclePosition);
       // Debug.Log($" distance to horizon {distanceToHorizon}");
        
        if(distanceToHorizon < 120)
        {
            SpawnTriangles();
        }
    }

    private void SpawnTriangles()
    {
        spawnObstaclePosition = new Vector3(0, 0, spawnObstaclePosition.z + 30);
        Debug.Log($" spawn pos {spawnObstaclePosition}");

        Instantiate(trianglePrefabs[UnityEngine.Random.Range(0, trianglePrefabs.Length)], spawnObstaclePosition, Quaternion.identity);
    }
}
