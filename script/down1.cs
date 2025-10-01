using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class down1 : MonoBehaviour
{
    public float movespeed = 1f;
    public int time = 10;
    public float downspeed = 0.0047f;
    public float sleep = 1f;
    int move;
    bool top;
    bool bsleep;
    void Start()
    {
        bsleep = true;
        move = 0;
        top = true;
        StartCoroutine(sleepTime());
    }

    // Update is called once per frame
    void Update()
    {
        if(!bsleep){
            if(move < time && top)
            {
                move++;
                this.transform.position = new Vector3(this.transform.position.x , this.transform.position.y + movespeed * downspeed , this.transform.position.z);
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
    IEnumerator sleepTime()
    {
        yield return new WaitForSeconds(sleep);
        bsleep = false;
    }
}
