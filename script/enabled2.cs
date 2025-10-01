using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enabled2 : MonoBehaviour
{
    public GameObject block;
    public float removetime = 1f;
    bool b;
    public float sleep = 1f;
    bool bsleep;
    void Start()
    {
        b = true;
        bsleep = true;
        StartCoroutine(sleepTime());
    }
    void Update()
    {
        if(!bsleep)
        {
            if(b)
            {
                b = false;
                StartCoroutine(e1());
            }
        }
    }
    IEnumerator e1()
    {
        yield return new WaitForSeconds(removetime);
        block.SetActive(false);
        StartCoroutine(e2());
    }
    IEnumerator e2()
    {
        yield return new WaitForSeconds(removetime);
        block.SetActive(true);
        b = true;
    }
    IEnumerator sleepTime()
    {
        yield return new WaitForSeconds(sleep);
        bsleep = false;
    }
}
