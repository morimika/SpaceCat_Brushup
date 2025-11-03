using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

[RequireComponent(typeof(CanvasGroup))]
public class FadeOut : MonoBehaviour
{
    [SerializeField]
    private float fadeSpeed = 1f;

    private CanvasGroup canvasGroup;

    private static FadeOut instance;
    public static FadeOut Inctance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<FadeOut>();

                if (instance == null)
                {
                    var obj = new GameObject("FadeOut");
                    instance = obj.AddComponent<FadeOut>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    /// <summary>
    /// フェードアウト
    /// </summary>
    public async UniTask Fadeout()
    {
        canvasGroup.alpha = 0;
        float alpha = 0;
        while (canvasGroup.alpha < 1)
        {
            alpha += Time.deltaTime * fadeSpeed;
            canvasGroup.alpha = Mathf.Min(alpha, 1f);
            await UniTask.Yield();
        }
    }
}
