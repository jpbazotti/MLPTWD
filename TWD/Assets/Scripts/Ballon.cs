using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour
{
    
    public Func<float, float> move_x = x => x + 0.05f;
    public Func<float, float> move_y = x => 0.35f * MathF.Cos(x - 8);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        gameObject.transform.position = new Vector3(move_x(transform.position.x), (move_y(transform.position.x)), 0);
    }



}
