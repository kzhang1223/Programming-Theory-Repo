using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PenguinManager : MonoBehaviour
{
    [SerializeField] GameObject backgroundImage;
    [SerializeField] List<Sprite> background;
    [SerializeField] List<GameObject> penguinImages;
    [SerializeField] GameObject penguinInstructions;

    private int backgroundIndex = 0;
    private List<int> rarities;

    private void Start()
    {
        rarities = new List<int>();
        rarities.Add(2);
        rarities.Add(4);
        rarities.Add(8);
        rarities.Add(16);
        rarities.Add(32);
        rarities.Add(64);
        InvokeRepeating("AnimateBackground", 0, 0.09f);
        GetPenguin();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            GameManager.instance.buttonSound.Play();
            SceneManager.LoadScene(3);
        }
    }

    public void AnimateBackground()
    {
        backgroundImage.GetComponent<Image>().sprite = background[backgroundIndex];
        backgroundIndex++;
        if (backgroundIndex >= background.Count)
        {
            backgroundIndex = 0;
        }
    }

    public void ShowPenguin(int index)
    {
        GameManager.instance.penguinSound.Play();
        penguinImages[index].SetActive(true);
        penguinImages[index].GetComponent<Penguin>().PlayEffects();
        CancelInvoke();
    }

    public void ShowInstructions()
    {
        penguinInstructions.SetActive(true);
    }

    private void GetPenguin()
    {
        if (GameManager.instance.numTimesOpened == 15)
        {
            GameManager.instance.penguinIndex = UnityEngine.Random.Range(2, penguinImages.Count);
            StartCoroutine(PenguinTimer(GameManager.instance.penguinIndex));
            Invoke("ShowInstructions", 2);
            GameManager.instance.numTimesOpened = -1;
        }
        else if (GameManager.instance.onIntro)
        {
            StartCoroutine(PenguinTimer(0));
            Invoke("ShowInstructions", 2);
            GameManager.instance.onIntro = false;
            GameManager.instance.numTimesOpened++;
        } else
        {
            int rarityIndex = UnityEngine.Random.Range(2, rarities.Count);
            Debug.Log("Rarity Index:" + rarityIndex);
            RarityCheck(rarityIndex);

            Debug.Log("Index: " + GameManager.instance.penguinIndex);
            Debug.Log("NumTimesOpened: " + GameManager.instance.numTimesOpened);
            StartCoroutine(PenguinTimer(GameManager.instance.penguinIndex));
            Invoke("ShowInstructions", 2);
        }

        GameManager.instance.collectedPenguins.Add(GameManager.instance.penguinIndex);
        GameManager.instance.SavePenguins();
        GameManager.instance.numTimesOpened++;
    }

    private void RarityCheck(int rarityIndex)
    {
        int rarity = rarities[rarityIndex];
        int winningNum = UnityEngine.Random.Range(0, (rarity+1));
        int yourNum = UnityEngine.Random.Range(0, (rarity+1));
        Debug.Log("Rarity: " + rarity);
        Debug.Log("WinningNum: " + winningNum);
        Debug.Log("YourNum: " + yourNum);
        if (winningNum == yourNum)
        {
            GameManager.instance.penguinIndex = rarityIndex;
        }
        else
        {
            GameManager.instance.penguinIndex = UnityEngine.Random.Range(0, 2);
        }
    }

    IEnumerator PenguinTimer(int index)
    {
        yield return new WaitForSeconds(2);
        ShowPenguin(index);
    }
}
