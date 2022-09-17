using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastShooter : tower
{

    override public void track()
    {
        if (placed)
        {
            if (placed)
            {
                GameObject target = null;
                float minDistance = 100000;
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
                foreach (GameObject enemy in enemies)
                {
                    float distance = Vector3.Distance(body.transform.position, enemy.transform.position);
                    if (distance < range && distance < minDistance)
                    {
                        minDistance = distance;
                        target = enemy;
                    }
                }
                Vector3 dir = body.transform.position - target.transform.position;
                body.transform.rotation = Quaternion.LookRotation(dir);
            }
        }
    }
    override public void shoot()
    {
        if (placed)
        {
        }
    }

}
