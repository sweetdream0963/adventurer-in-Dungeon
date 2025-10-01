using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject play;
    public GameObject quit;
    public GameObject howToPlay;
	public GameObject Back;
    public GameObject group0;
    public GameObject group1;
    public void PlayGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    	SceneManager.LoadSceneAsync(1);
    }
	public void HowToPlay()
	{
		group0.SetActive(false);
        group1.SetActive(true);
	}
    public void HowToPlayBack()
    {
        group0.SetActive(true);
        group1.SetActive(false);
    }
	public void back()
	{
		SceneManager.LoadSceneAsync(0);
	}
    public void QuitApp()
    {
    	Application.Quit();
		Debug.Log("Application has quit.");
    }
}
