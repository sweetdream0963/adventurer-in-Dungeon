using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class y_movefloor : MonoBehaviour
{
    public float movespeed = 1f;
    public int time = 10;
    int move;
    bool left;
    void Start()
    {
        move = 0;
        left = true;
    }

    void Update()
    {
        if(move < time && left)
        {
            move++;
            this.transform.position = new Vector3(this.transform.position.x , this.transform.position.y + movespeed * 0.0047f , this.transform.position.z);
        }
        else if(move > 0)
        {
            left = false;
            move--;
            this.transform.position = new Vector3(this.transform.position.x , this.transform.position.y - movespeed * 0.0047f , this.transform.position.z);
        }
        else
        {
            left = true;
            move = 0;
        }
    }
}
