using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class App_Intialize : MonoBehaviour
{
    public GameObject inMenuUI;
    public GameObject inGameUI;
    public GameObject GameOverUI;
    public GameObject player;
    private bool hasGaneStarted = false;
    private void Awake()
    {
        Shader.SetGlobalFloat("_Curvature", 2.0f);
        Shader.SetGlobalFloat("_Trimming", 0.1f);
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        inMenuUI.gameObject.SetActive(true);
        inGameUI.gameObject.SetActive(false);
        GameOverUI.gameObject.SetActive(false);
    }

   IEnumerator StartGame(float waitTime)
    {
        inMenuUI.gameObject.SetActive(false);
        inGameUI.gameObject.SetActive(true);
        GameOverUI.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitTime);
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
    }
    public void GameOver()
    {
        hasGaneStarted = true;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        inMenuUI.gameObject.SetActive(false);
        inGameUI.gameObject.SetActive(false);
        GameOverUI.gameObject.SetActive(true);
    }
    public void PlayButton()
    {
        if (hasGaneStarted)
        {
            StartCoroutine("StartGame", 1.0f);
        }
        else
        {
            StartCoroutine("StartGame", 0.0f);

        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void ShowAd()
    {
        //Figure out ad shit
    }
    public void PauseGame()
    {
        hasGaneStarted = true;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        inMenuUI.gameObject.SetActive(true);
        inGameUI.gameObject.SetActive(false);
        GameOverUI.gameObject.SetActive(false);
    }
}
