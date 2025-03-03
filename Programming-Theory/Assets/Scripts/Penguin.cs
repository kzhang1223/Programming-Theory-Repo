using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Penguin : MonoBehaviour
{
    public ParticleSystem effect;
    public GameObject effectGameObject;

    public virtual void PlayEffects()
    {
        effectGameObject.SetActive(true);
        effect.Play();
    }
}
