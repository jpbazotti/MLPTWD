using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastShooter : tower
{

    override public void track()
    {
        Debug.Log("track1");
    }
    override public void shoot()
    {
        Debug.Log("shoot1");
    }

}
