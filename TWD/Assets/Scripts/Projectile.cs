using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed;
    void Start()
    {

    }

    void FixedUpdate()
    {
        body.transform.position += -body.transform.right *  speed;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Debug.Log("destroyed");

        }
        if (collision.gameObject.tag == "border")
        {
            Destroy(gameObject);

        }

    }
}
