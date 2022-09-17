using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multishooter : tower
{
    
    override public void track()
    {
        if (placed)
        {
            float maxDistance = 0;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
            target = null;
            if (enemies.Length > 0)
            {
                foreach (GameObject enemy in enemies)
                {
                    float distance = Vector3.Distance(body.transform.position, enemy.transform.position);
                    if (distance < range && distance > maxDistance)
                    {
                        maxDistance = distance;
                        target = enemy;
                    }
                }
                if (target)
                {
                    Vector3 dir = body.transform.position - target.transform.position;
                    dir.Normalize();
                    float rotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    body.transform.rotation = Quaternion.Euler(0f, 0f, rotation);
                }
            }
        }
        
    }
    override public void shoot()
    {
        if (placed)
        {
            if (target && shootTimer >= getfireRate()){
                Instantiate(ammo,shootPoint.position,body.transform.rotation);
                shootTimer = 0;
                Debug.Log("shoot");
            }
        }
    }


}
