using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ballon : MonoBehaviour
{
    private bool pop;
    public Func<float, float> move_x_linear = x => x + 0.05f;
    public Func<float, float> move_x_linear_neg = x => x - 0.05f;
    public Func<float, float> move_y_sin = x => MathF.Sin(x - 0.4f);
    public Func<float, float> move_y_linear = x =>x;

    int curPosition;
    public IEnumerable<float> allPosX;
    public IEnumerable<float> allPosY;
    public Func<int,int, float, Func<float, float>, IEnumerable<float>> movementList()
    {
        Func<int, int,float, Func<float, float>, IEnumerable<float>> move = null;
        move = (it,size,pos,function)=> it == 0 ? new List<float> {pos}.Concat(move(it + 1, size,function(pos), function)):
                    it < size ? new List<float> {pos}.Concat(move(it + 1, size,function(pos), function)) :
                    new List<float> {};
        return move;
    }
    // Start is called before the first frame update
    void Awake()
    {
        pop = false;
        curPosition = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (allPosX!=null && allPosY!=null)
        {
            gameObject.transform.position = new Vector3(allPosX.ElementAt(curPosition), allPosY.ElementAt(curPosition), gameObject.transform.position.z);
            curPosition++;
        }
    }
   
   


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "border")
        {
            FindObjectOfType<Player>().receiveDamage(1);
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "dart")
        {
            if (!pop)
            {
                pop = true;
                FindObjectOfType<Player>().getMoney(5);
                Destroy(gameObject);
            }
        }
    }



}
