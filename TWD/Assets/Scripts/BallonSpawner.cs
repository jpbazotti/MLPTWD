using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonSpawner : MonoBehaviour
{
    public GameObject Ballon;
    private float timer;
    public float spawnrate;
    public GameObject[] spawnpointers; 
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;

        if (timer >= spawnrate)
        {
            timer = 0;
            Instantiate(Ballon, spawnpointers[0].transform);
            Instantiate(Ballon, spawnpointers[1].transform);
            Instantiate(Ballon, spawnpointers[2].transform);
        }
    }
}
