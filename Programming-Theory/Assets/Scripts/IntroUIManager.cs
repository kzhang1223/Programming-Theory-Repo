using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntroUIManager : MonoBehaviour
{
    [SerializeField] GameObject Hello;
    [SerializeField] GameObject Welcome;
    [SerializeField] GameObject Explore;
    [SerializeField] GameObject Door;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("TurnOnHello", 1);
        Invoke("TurnOnWelcome", 4);
        Invoke("TurnOnExplore", 10);
        Invoke("TurnOnDoor", 16);
        Invoke("TurnOffDoor", 20);
    }

    private void TurnOnHello()
    {
        Hello.SetActive(true);
    }

    private void TurnOnWelcome()
    {
        Hello.SetActive(false);
        Welcome.SetActive(true);
    }

    private void TurnOnExplore()
    {
        Welcome.SetActive(false);
        Explore.SetActive(true);
    }

    private void TurnOnDoor()
    {
        Explore.SetActive(false);
        Door.SetActive(true);
    }

    private void TurnOffDoor()
    {
        Door.SetActive(false);
    }
}
