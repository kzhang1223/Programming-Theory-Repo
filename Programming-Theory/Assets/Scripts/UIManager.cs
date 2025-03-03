using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject doorInstructions;
    [SerializeField] GameObject eggInstructions;

    private void Start()
    {

    }

    public void TurnOnDoorInstructions()
    {
        doorInstructions.SetActive(true);
    }
    
    public void TurnOffDoorInstructions()
    {
        doorInstructions.SetActive(false);
    }

    public void TurnOnEggInstructions()
    {
        eggInstructions.SetActive(true);
    }

    public void TurnOffEggInstructions()
    {
        eggInstructions.SetActive(false);
    }
}
