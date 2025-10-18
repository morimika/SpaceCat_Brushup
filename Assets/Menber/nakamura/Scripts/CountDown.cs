using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using TMPro;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using System;

public class CountDown : MonoBehaviour
{
    private static CountDown instance;
    public static CountDown Inctance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CountDown>();

                if (instance == null)
                {
                    var obj = new GameObject("CountDown");
                    instance = obj.AddComponent<CountDown>();
                }
            }
            return instance;
        }
    }

    [SerializeField, Label("時間テキスト")]
    private TextMeshProUGUI timeText;
    [SerializeField,Label("制限時間")]
    private float limitTime = 60;
    [SerializeField, Scene, Label("遷移先のシーン")]
    private string fadeScene;
    [SerializeField, Label("遷移まで止まる時間")]
    private float waitTime = 1f;

    private bool isGemeover = false;
    public bool IsLimitTime = false;
    public bool IsCamera = false;

    void Start()
    {
        isGemeover = false;
        IsLimitTime = false;
        IsCamera = false;
    }

    private async void Update()
    {
        //カウントダウン
        //残り10秒で文字が赤くなる
        limitTime -= Time.deltaTime;
        if(limitTime < 10)  timeText.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        if(limitTime < 0)   limitTime = 0;
        timeText.text = "残り時間：" + limitTime.ToString("F0") + "秒";

        if (limitTime == 0 && isGemeover == false)
        {
            isGemeover = true;

            //隕石降らして画面揺らす
            IsLimitTime = true;
            IsCamera = true;

            //止まる
            await UniTask.Delay(TimeSpan.FromSeconds(waitTime));

            //フェードアウト→画面遷移
            await FadeOut.Inctance.Fadeout();
            SceneManager.LoadScene(fadeScene);
        }
    }
}
