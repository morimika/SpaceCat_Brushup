using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeStartManager : MonoBehaviour
{
    [SerializeField]
    private float fadeSpeed = 1f;

    private async void Start()
    {
        await FadeManager.Inctance.FadeIn(fadeSpeed);
    }
}
