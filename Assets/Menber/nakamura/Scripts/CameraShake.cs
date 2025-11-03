using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

public class CameraShake : MonoBehaviour
{
    [SerializeField,Label("カメラ")]
    private Transform cam;
    [SerializeField,Label("カメラの位置を揺らす強度")]
    private Vector2 posStrength;

    private float shakeDuration = 0.3f;

    void Update()
    {
        //カウントダウンが0秒になったら
        if (CountDown.Inctance.IsCamera == true) CameraShaker();
    }

    /// <summary>
    /// カメラを揺らす
    /// </summary>
    private void CameraShaker()
    {
        cam.DOComplete();
        cam.DOShakePosition(shakeDuration, posStrength);
    }
}
