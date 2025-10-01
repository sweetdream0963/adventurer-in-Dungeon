using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    private Rigidbody m_rb;
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        m_rb.AddForce(Vector3.forward);
    }
}
