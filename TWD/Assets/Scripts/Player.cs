using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private bool hasTower;
    private GameObject currentTower;
    private tower currentTowerScript;
    private TextMeshProUGUI lifeTextContent;
    private TextMeshProUGUI moneyTextContent;
    private TextMeshProUGUI gameOverTextContent;
    private SpriteRenderer radius;

    public GameObject tower1;
    public GameObject tower2;
    public int life;
    public int price1;
    public int price2;
    public int startMoney;
    public float range1;
    public float range2;
    public float fireRate1;
    public float fireRate2;
    public GameObject lifeText;
    public GameObject moneyText;
    public GameObject gameOverText;



    int money;
    // Start is called before the first frame update
    void Start()
    {
        life = 100;
        hasTower = false;
        money = startMoney;
        lifeTextContent = lifeText.GetComponent<TextMeshProUGUI>();
        moneyTextContent = moneyText.GetComponent<TextMeshProUGUI>();
        gameOverTextContent = gameOverText.GetComponent<TextMeshProUGUI>();
        lifeTextContent.SetText("{0}", life);
        moneyTextContent.SetText("{0}", money);
        radius = GetComponent<SpriteRenderer>();
        radius.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (life > 0)
        {
            Vector3 worldpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = new Vector3(worldpos.x, worldpos.y, 0);
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                radius.enabled = true;
                if (hasTower)
                {
                    Destroy(currentTower);
                }
                hasTower = true;
                currentTower = Instantiate(tower1);
                currentTowerScript = currentTower.GetComponent<Multishooter>();
                currentTowerScript.setColor(Color.blue);
                currentTowerScript.setRange(range1);
                currentTowerScript.setfireRate(fireRate1);
                currentTowerScript.setPrice(price1);
                gameObject.transform.localScale = new Vector3(range1*2, range1 * 2, 1);

            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                radius.enabled = true;
                if (hasTower)
                {
                    Destroy(currentTower);
                }
                hasTower = true;
                currentTower = Instantiate(tower2);
                currentTowerScript = currentTower.GetComponent<FastShooter>();
                currentTowerScript.setColor(Color.red);
                currentTowerScript.setRange(range2);
                currentTowerScript.setfireRate(fireRate2);
                currentTowerScript.setPrice(price2);
                gameObject.transform.localScale = new Vector3(range2 * 2, range2 * 2, 1);
            }
            if (hasTower)
            {
                if (currentTower)
                {
                    currentTower.transform.position = new Vector3(worldpos.x, worldpos.y, 0);
                }
                else
                {
                    currentTowerScript = null;
                    currentTower = null;
                    hasTower = false;
                }

            }
            if (hasTower && Input.GetKeyDown(KeyCode.Mouse0) && money >= currentTowerScript.getPrice())
            {
                money -= currentTowerScript.getPrice();
                moneyTextContent.SetText("{0}", money);
                currentTowerScript.setPlaced(true);
                currentTowerScript = null;
                currentTower = null;
                hasTower = false;
                radius.enabled = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            }
        }
    }
    private void gameOver()
    {
        gameOverTextContent.SetText("Game Over\n press space to restart");

    }
    public void getMoney(int price)
    {
        money += price;
        moneyTextContent.SetText("{0}", money);
    }

    public void receiveDamage(int damage)
    {
        life -= damage;
        lifeTextContent.SetText("{0}", life);
        if(life <= 0)
        {
            gameOver();
        }
    }
}
