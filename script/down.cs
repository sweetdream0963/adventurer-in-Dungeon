using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class down : MonoBehaviour
{
    public float movespeed = 1f;
    public int time = 10;
    public float downspeed = 0.0047f;
    int move;
    bool top;
    void Start()
    {
        move = 0;
        top = true;
    }

    void Update()
    {
        if(move < time && top)
        {
            move+=20;
            this.transform.position = new Vector3(this.transform.position.x , this.transform.position.y + movespeed * 20 * downspeed , this.transform.position.z);
        }
        else if(move > 0)
        {
            top = false;
            move-=20;
            this.transform.position = new Vector3(this.transform.position.x , this.transform.position.y - movespeed * 20 * downspeed , this.transform.position.z);
        }
        else
        {
            top = true;
            move = 0;
        }
    }
}
