using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool hasTower;
    private int life;
    private GameObject currentTower;
    private tower currentTowerScript;
    public GameObject tower1;
    public GameObject tower2;
    public float range1;
    public float range2;
    public float fireRate1;
    public float fireRate2;

    int money;
    // Start is called before the first frame update
    void Start()
    {
        life = 100;
        hasTower = false;
        money = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (hasTower)
            {
                Destroy(currentTower);
            }
            hasTower = true;
            currentTower= Instantiate(tower1);
            currentTowerScript = currentTower.GetComponent<Multishooter>();
            currentTowerScript.setColor(Color.blue);
            currentTowerScript.setRange(range1);
            currentTowerScript.setfireRate(fireRate1);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (hasTower)
            {
                Destroy(currentTower);
            }
            hasTower = true;
            currentTower = Instantiate(tower2);
            currentTowerScript=currentTower.GetComponent<FastShooter>();
            currentTowerScript.setColor(Color.red);
            currentTowerScript.setRange(range2);
            currentTowerScript.setfireRate(fireRate2);
        }
        if (hasTower)
        {
            if (currentTower)
            {
                Vector3 worldpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentTower.transform.position = new Vector3(worldpos.x, worldpos.y, 0);
            }
            else
            {
                currentTowerScript = null;
                currentTower = null;
                hasTower = false;
            }

        }
        if (hasTower && Input.GetKeyDown(KeyCode.Mouse0))
        {
            currentTowerScript.setPlaced(true);
            currentTowerScript = null;
            currentTower= null;
            hasTower = false;

        }

        if(life < 100)
        {
            gameOver();
        }
    }
    private void gameOver()
    {
        Debug.Log("Game Over");
    }
}
