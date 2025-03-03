using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;

    private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.Find("Main Camera").GetComponent<PlayerController>();
    }

    public void BackToGame()
    {
        GameManager.instance.buttonSound.Play();
        menu.SetActive(false);
        playerController.speed = 5.0f;
        playerController.sensitivity = 3.0f;
    }

    public void QuitGame()
    {
        GameManager.instance.buttonSound.Play();
        SceneManager.LoadScene(0);
    }
}
