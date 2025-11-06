using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyAttributes;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameoverManager : MonoBehaviour
{
    [SerializeField, Label("ゲームオーバーテキスト")]
    private TextMeshProUGUI gameoverText;
    [SerializeField, Label("フレーバーテキスト")]
    private TextMeshProUGUI flavorText;
    [SerializeField, Label("やりなおすボタン")]
    private GameObject returnGameButton;
    [SerializeField, Label("やりなおすボタンテキスト")]
    private TextMeshProUGUI returnGameText;

    [SerializeField, Label("フェードシーンのパネルを入れる")]
    private GameObject fadeScenePanel;
    [SerializeField, Scene,Label("遷移先シーンの名前")]
    private string fadeSceneName;

    [SerializeField, Label("ボタンを押した時のSE")]
    private AudioClip buttonSE;
    private AudioSource audioSource;

    private bool isFade = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameoverText.gameObject.SetActive(false);
        flavorText.gameObject.SetActive(false);
        returnGameButton.gameObject.SetActive(false);

        //ボタン点滅
        returnGameText.GetComponent<CanvasGroup>().DOFade(0f, 1).SetLoops(-1, LoopType.Yoyo);
    }

    async UniTask Update()
    {
        //フェードが終わったら順次に表示する
        if (fadeScenePanel.activeSelf == false && isFade == false)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            gameoverText.gameObject.SetActive(true);
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            flavorText.gameObject.SetActive(true);
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            returnGameButton.SetActive(true);
            isFade = true;
        }
    }

    public async void ReturnGameButton()
    {
        //パネルを表示
        fadeScenePanel.SetActive(true);
        //ボタンのSEを鳴らす
        audioSource.PlayOneShot(buttonSE);
        //フェードアウトしてシーン遷移
        await FadeManager.Inctance.FadeOut();
        SceneManager.LoadScene(fadeSceneName);
    }
}
