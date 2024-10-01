using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPosition = new Vector3(25,0,0);
    public float repeatRate =2f;
    private float startDelay = 2f;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        //if(Time.time % 2 < 0.05f)
        //{
        //    Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        //}
    }

    private void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
    }
}
