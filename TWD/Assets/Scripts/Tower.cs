using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class tower : MonoBehaviour
{
    private float fireRate;
    private Color color;
    public SpriteRenderer sprite;
    private float angle;
    protected Rigidbody2D body;
    protected bool placed;
    protected Transform shootPoint;
    private bool intersect;
    protected float range;
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        shootPoint = GetComponentInChildren<Transform>();
        setfireRate(1);
        setangle(0);
        setPlaced(false);
        setColor(Color.white);
        intersect = false;

    }

    // Update is called once per frame
    void Update()
    {
        track();
        shoot();
        sprite.color = color;
        if (intersect && placed)
        {
            Destroy(gameObject);
        }
    }
    public void setfireRate(float fireRate)
    {
        this.fireRate = fireRate;
    }
    public float getfireRate()
    {
        return fireRate;
    }
    public void setangle(float angle)
    {
        this.angle=angle;
    }
    public float getangle()
    {
        return angle;
    }

    public void setColor(Color color)
    {
        this.color = color;
    }

    public void setPlaced(bool placed)
    {
        this.placed = placed;
    }

    public void setRange(float range)
    {
       this.range=range;
    }
    public float getRange()
    {
        return range;
    }

    public bool getPlaced()
    {
        return placed;
    }
    public abstract void track();
    public abstract void shoot();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "tower")
        {
            if (collision.gameObject.GetComponent<tower>().getPlaced())
            {
                intersect = true;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "tower")
        {
            if (collision.gameObject.GetComponent<tower>().getPlaced())
                intersect = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "tower")
        {
            if (collision.gameObject.GetComponent<tower>().getPlaced())
                intersect = false;
        }

    }
}
