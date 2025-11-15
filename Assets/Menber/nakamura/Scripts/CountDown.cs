using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using TMPro;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using System;
using Unity.VisualScripting;

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
    public float limitTime = 60;
    [SerializeField, Scene, Label("遷移先のシーン")]
    private string fadeScene;
    [SerializeField, Label("遷移まで止まる時間")]
    private float waitTime = 1f;

    private bool isGemeover = false;
    public bool IsLimitTime = false;
    public bool IsCamera = false;

    private bool isTimeRed = false;
    [SerializeField]
    private AudioClip _audioClip;
    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private Rigidbody2D player;

    void Start()
    {
        isGemeover = false;
        IsLimitTime = false;
        IsCamera = false;
        player= player.GetComponent<Rigidbody2D>();
    }

    private async void Update()
    {
        //カウントダウン
        //残り10秒で文字が赤くなる
        if (PlayerLayer.IsGameTime == false) return;
        limitTime -= Time.deltaTime;
        if (limitTime < 10)
        {
            if (!isTimeRed)
            {
                _audioSource.PlayOneShot(_audioClip);
                isTimeRed = true;
            }

                timeText.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
            if (limitTime < 0)   limitTime = 0;
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
        if (isGemeover == true)
        {
            //プレイヤー停止
            player.bodyType=RigidbodyType2D.Static;
        }
    }
}
