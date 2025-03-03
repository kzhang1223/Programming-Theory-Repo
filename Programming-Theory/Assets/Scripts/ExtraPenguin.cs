using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class ExtraPenguin : Penguin
{
    [SerializeField] ParticleSystem extraEffect;
    [SerializeField] GameObject extraEffectGameObject;

    // POLYMORPHISM, ABSTRACTION
    public override void PlayEffects()
    {
        effectGameObject.SetActive(true);
        effect.Play();

        extraEffectGameObject.SetActive(true);
        extraEffect.Play();
    }
}
