using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multishooter : tower
{
    
    override public void track()
    {
        if (placed)
        {
            float minDistance = 100000;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
            target = null;
            if (enemies.Length > 0)
            {
                foreach (GameObject enemy in enemies)
                {
                    float distance = Vector3.Distance(body.transform.position, enemy.transform.position);
                    if (distance < range && distance < minDistance)
                    {
                        minDistance = distance;
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
                Quaternion rotate = body.transform.rotation;
                Instantiate(ammo, shootPoint.position, rotate * Quaternion.Euler(0, 0, 30));
                Instantiate(ammo, shootPoint.position, rotate * Quaternion.Euler(0, 0, 15));
                Instantiate(ammo, shootPoint.position, rotate);
                Instantiate(ammo, shootPoint.position, rotate * Quaternion.Euler(0, 0, -15));
                Instantiate(ammo, shootPoint.position, rotate * Quaternion.Euler(0, 0, -30));
                shootTimer = 0;
            }
        }
    }


}
