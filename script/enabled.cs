using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enabled : MonoBehaviour
{
    public GameObject block;
    public float removetime = 1f;
    bool b;
    void Start()
    {
        b = true;
    }
    void Update()
    {
        if(b)
        {
            b = false;
            StartCoroutine(e1());
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
}
