using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallonSpawner : MonoBehaviour
{
    public GameObject ballon;
    private float timer;
    public float spawnrate;
    public GameObject[] spawnpointers;
    IEnumerable<float> xpath1;
    IEnumerable<float> ypath1;
    IEnumerable<float> xpath2;
    IEnumerable<float> ypath2;
    IEnumerable<float> xpath3;
    IEnumerable<float> ypath3;
    // Start is called before the first frame update
    void Awake()
    {
        Ballon script =ballon.GetComponent<Ballon>();
        var f = script.movementList();
        xpath1 = f(0, spawnpointers[0].transform.position.x, script.move_x_linear);
        xpath2 = f(0, spawnpointers[1].transform.position.x, script.move_x_linear);
        xpath3 = f(0, spawnpointers[2].transform.position.x, script.move_x_linear);

        ypath1 = f(0, spawnpointers[0].transform.position.y, script.move_y_linear);
        ypath2 = xpath2.Select(script.move_y_sin);
        ypath3 = f(0, spawnpointers[2].transform.position.y, script.move_y_linear);
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;

        if (timer >= spawnrate)
        {
            timer = 0;
            GameObject b1 =Instantiate(ballon, spawnpointers[0].transform.position,Quaternion.identity);
            b1.GetComponent<Ballon>().allPosX = xpath1;
            b1.GetComponent<Ballon>().allPosY = ypath1;

            GameObject b2 = Instantiate(ballon, spawnpointers[1].transform.position, Quaternion.identity);
            b2.GetComponent<Ballon>().allPosX = xpath2;
            b2.GetComponent<Ballon>().allPosY = ypath2;

            GameObject b3 = Instantiate(ballon, spawnpointers[2].transform.position, Quaternion.identity);
            b3.GetComponent<Ballon>().allPosX = xpath3;
            b3.GetComponent<Ballon>().allPosY = ypath3;
        }
    }
}
