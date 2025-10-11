using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using TMPro;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    [SerializeField, Label("時間テキスト")]
    private TextMeshProUGUI timeText;
    [SerializeField,Label("制限時間")]
    private float limitTime = 60;
    [SerializeField, Scene, Label("遷移先のシーン")]
    private string fadeScene;

    private bool isGemeover = false;

    void Start()
    {
        
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

            //0秒になったら止まる→隕石降らして画面揺らす

            //フェードアウト→画面遷移
            await FadeManager.Inctance.FadeOut();
            SceneManager.LoadScene(fadeScene);
        }
    }
}
