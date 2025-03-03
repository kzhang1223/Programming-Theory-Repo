using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] List<GameObject> inventory;
    [SerializeField] GameObject leftArrow;
    [SerializeField] GameObject rightArrow;

    private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.Find("Main Camera").GetComponent<PlayerController>();
    }

    private void Update()
    {
        foreach (int penguinIndex in GameManager.instance.collectedPenguins)
        {
            inventory[penguinIndex].GetComponent<Image>().color = Color.white;
        }
    }

    public void CloseInventory()
    {
        GameManager.instance.buttonSound.Play();
        gameObject.SetActive(false);
        playerController.speed = 5.0f;
        playerController.sensitivity = 3.0f;
    }

    public void SecondPage()
    {
        GameManager.instance.buttonSound.Play();
        for (int i = 0; i < 6; i++)
        {
            GameObject penguin = inventory[i];
            penguin.SetActive(false);
        }

        for (int j = 6; j < inventory.Count; j++)
        {
            GameObject penguin = inventory[j];
            penguin.SetActive(true);
        }

        rightArrow.SetActive(false);
        leftArrow.SetActive(true);
    }

    public void FirstPage()
    {
        GameManager.instance.buttonSound.Play();
        for (int i = 0; i < 6; i++)
        {
            GameObject penguin = inventory[i];
            penguin.SetActive(true);
        }

        for (int j = 6; j < inventory.Count; j++)
        {
            GameObject penguin = inventory[j];
            penguin.SetActive(false);
        }

        rightArrow.SetActive(true);
        leftArrow.SetActive(false);
    }
}
