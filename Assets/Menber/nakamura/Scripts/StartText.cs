using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class StartText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI startButtonText;

    private void Start()
    {
        startButtonText.DOFade(0f, 1f).SetLoops(-1, LoopType.Yoyo);
    }
}
