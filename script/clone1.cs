using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clone1 : MonoBehaviour
{
    private Rigidbody m_rb;
    public Rigidbody projectile;
    public float time = 2f;
    bool fire;
    void Start()
    {
        fire = true;
        m_rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(fire)
        {
            fire = false;
            StartCoroutine(spawnAfterTime());
        }
    }
    IEnumerator spawnAfterTime()
    {
        yield return new WaitForSeconds(time);
        Rigidbody clone;
        clone = Instantiate(projectile, transform.position, transform.rotation);
        clone.velocity = transform.TransformDirection(Vector3.up * 10);
        fire = true;
    }
}
