using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stop : MonoBehaviour
{
    public GameObject backToGame;
    public GameObject backHome;
    public GameObject canvas;
    public void backtogame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        canvas.SetActive(false);
        Time.timeScale = 1f;
    }
    public void backhome()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
