using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class tower : MonoBehaviour
{
    private float fireRate;
    private Color color;
    public SpriteRenderer sprite;
    private float angle;
    private Rigidbody2D body;
    private bool placed;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        setfireRate(1);
        setangle(0);
        setColor(Color.white);
    }

    // Update is called once per frame
    void Update()
    {
        track();
        shoot();
        sprite.color = color;
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

    public Color getColor()
    {
        return color;
    }
    public void setColor(Color color)
    {
        this.color = color;
    }

    public void setPlaced(bool placed)
    {
        this.placed = placed;
    }
    public abstract void track();
    public abstract void shoot();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!placed)
        {
            Destroy(this);
        }
    }
}
