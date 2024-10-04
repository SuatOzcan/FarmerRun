using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private PlayerController playerControllerScript;
    private Vector3 spawnPosition = new Vector3(25,0,0);
    public float repeatRate =2f;
    private float startDelay = 2f;
    // Start is called before the first frame update
    public void Start()
    {
        //Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate); // This never detects collisions.
        //Instantiate(original: obstaclePrefab);
        // This detects collision,
        // somehow the one below does not detect collision.
        // Instantiate(original: obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Time.time % 2 < 0.05f)
        //{
        //    Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        //}
    }

    public void SpawnObstacle()
    {
        if(!playerControllerScript.isGameOver)
        Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        //Instantiate(obstaclePrefab); // 
                                     
    }
}
