using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float jumpSpeed = 10f;
    public float jumptime = 1f;
    public float gravity = 20f;
    public Transform[] spawnpoint;
    public GameObject door;
    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;
    public GameObject lock4;
    public GameObject canvas;
    public CharacterController controller;
    AudioSource openAudio;
    Animator m_Animator;
    Vector3 m_Movement = Vector3.zero;
    float speed;
    int i , win;
    Vector3 jump;
    bool isPlaying , distory;
    void Start()
    {
        isPlaying = true;
        distory = true;
        i = 0;
        win = 0;
        jump = Vector3.zero;
        openAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 6f;
        }
        else
        {
            speed = 2f;
        }
        
        if(Input.GetKeyDown(KeyCode.P))
        {
            i+=1;
            Debug.Log(i);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            canvas.SetActive(true);
            Time.timeScale = 0f;
        }
        if(controller.isGrounded)
        {
            jump.y = 0f;
            if(Input.GetKey(KeyCode.Space))
            {
                StartCoroutine(spawnAfterTime());
                jump.y = jumpSpeed;
            }
        }
        else
        {
            jump.y -= gravity * Time.deltaTime;
        }
        
        m_Movement = transform.right * horizontal + transform.forward * vertical;
        controller.Move((m_Movement * speed + jump) * Time.deltaTime);
        if(win > 3)
        {
            if(isPlaying)
            {
                isPlaying = false;
                openAudio.Play();
            }
            if(distory)
            {
                distory = false;
                Destroy(door);
            }
        }
    }
    IEnumerator spawnAfterTime()
    {
        yield return new WaitForSeconds(jumptime);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("dead"))
        {
            controller.enabled = false;
            this.transform.position = spawnpoint[i].position;
            controller.enabled = true;
            win = 0;
            lock1.gameObject.SetActive(true);
            lock2.gameObject.SetActive(true);
            lock3.gameObject.SetActive(true);
            lock4.gameObject.SetActive(true);
        }
        if(other.gameObject.CompareTag("checkpoint"))
        {
            i++;
            other.gameObject.SetActive(false);
        }
        if(other.gameObject.CompareTag("lock"))
        {
            other.gameObject.SetActive(false);
            win++;
        }
        if(other.gameObject.CompareTag("end"))
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadSceneAsync(2);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("deaded"))
        {
            controller.enabled = false;
            this.transform.position = spawnpoint[i].position;
            controller.enabled = true;
            win = 0;
            lock1.gameObject.SetActive(true);
            lock2.gameObject.SetActive(true);
            lock3.gameObject.SetActive(true);
            lock4.gameObject.SetActive(true);
        }
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag=="box")
        {
            StartCoroutine(breaktime(hit));
        }
    }
    IEnumerator breaktime(ControllerColliderHit hit)
    {
        yield return new WaitForSeconds(0.5f);
        hit.gameObject.SetActive(false);
        StartCoroutine(waketime(hit));
    }
    IEnumerator waketime(ControllerColliderHit hit)
    {
        yield return new WaitForSeconds(3f);
        hit.gameObject.SetActive(true);
    }
}