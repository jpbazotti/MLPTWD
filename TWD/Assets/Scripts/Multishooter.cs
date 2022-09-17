using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multishooter : tower
{
    
    override public void track()
    {
        Debug.Log("track");
    }
    override public void shoot()
    {
        Debug.Log("shoot");
    }


}
