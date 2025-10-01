using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clone : MonoBehaviour
{
    AudioSource fireAudio;
    private Rigidbody m_rb;
    public Rigidbody projectile;
    public float time = 2f;
    public float sleep = 1f;
    bool fire;
    bool bsleep;
    void Start()
    {
        fire = true;
        bsleep = true;
        m_rb = GetComponent<Rigidbody>();
        fireAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(bsleep)
        {
            StartCoroutine(sleepTime());
        }
        if(fire && !bsleep)
        {
            fire = false;
            fireAudio.Play();
            StartCoroutine(spawnAfterTime());
        }

    }
    IEnumerator sleepTime()
    {
        yield return new WaitForSeconds(sleep);
        bsleep = false;
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
