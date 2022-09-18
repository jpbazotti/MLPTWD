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
    IEnumerable<float>[] xpath3Partial;
    IEnumerable<float>[] ypath3Partial;
    IEnumerable<float> xpath3;
    IEnumerable<float> ypath3;
    // Start is called before the first frame update
    void Awake()
    {
        Ballon script =ballon.GetComponent<Ballon>();
        var f = script.movementList();
        xpath1 = f(0,1000,spawnpointers[0].transform.position.x, script.move_x_linear);
        ypath1 = f(0, 1000,spawnpointers[0].transform.position.y, script.move_y_linear);
        xpath2 = f(0, 1000,spawnpointers[1].transform.position.x, script.move_x_linear);
        ypath2 = xpath2.Select(script.move_y_sin);
        xpath3Partial = new IEnumerable<float>[7];
        ypath3Partial = new IEnumerable<float>[7];
        xpath3= new List<float> { };
        ypath3= new List<float> { };
        float offsetX = 0;
        float offsetY = 0;
        int stepsizeX = 95;
        int stepsizeY = 40;
        for (int i =0; i<7; i+=2)
        {
            if (i == 2 || i==6)
            {
                offsetY = -stepsizeY * 0.05f;
            }
            else
            {
                offsetY = 0;
            }
            xpath3Partial[i] = f(0, stepsizeX, spawnpointers[2].transform.position.x+offsetX, script.move_x_linear);
            ypath3Partial[i] = f(0, stepsizeX, spawnpointers[2].transform.position.y+ offsetY, script.move_y_linear);
            offsetX += stepsizeX * 0.05f;
            stepsizeX = 90;

        }
        stepsizeX = 95;
        offsetX = stepsizeX * 0.05f;
        for (int i = 1; i < 7; i += 2)
        {
            if (i == 3)
            {
                offsetY = -stepsizeY * 0.05f;
            }
            else
            {
                offsetY = 0;
            }
            ypath3Partial[i] = f(0, stepsizeY, spawnpointers[2].transform.position.y+offsetY, i==3? script.move_x_linear: script.move_x_linear_neg);
            xpath3Partial[i] = f(0, stepsizeY, spawnpointers[2].transform.position.x+offsetX, script.move_y_linear);
            stepsizeX = 90;
            offsetX += stepsizeX * 0.05f;
           
        }

        for (int i = 0; i < 7; i ++)
        {
            xpath3 = xpath3.Concat(xpath3Partial[i]);
            ypath3 = ypath3.Concat(ypath3Partial[i]);

        }
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
