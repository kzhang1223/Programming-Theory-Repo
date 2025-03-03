using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject dataLoadedText;

    public void PlayButtonSound()
    {
        GameManager.instance.buttonSound.Play();
    }

    public void StartGame()
    {
        PlayButtonSound();
        if (GameManager.instance.onIntro)
        {
            SceneManager.LoadScene(2);
        } else
        {
            SceneManager.LoadScene(3);
        }
        
    }

    public void InstructionsPage()
    {
        PlayButtonSound();
        SceneManager.LoadScene(5);
    }

    public void LoadData()
    {
        StartCoroutine(WaitOneSecond());
        GameManager.instance.LoadPenguins();
    }

    IEnumerator WaitOneSecond()
    {
        dataLoadedText.SetActive(true);
        yield return new WaitForSeconds(1);
        dataLoadedText.SetActive(false);
    }

    public void QuitGame()
    {
        PlayButtonSound();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
