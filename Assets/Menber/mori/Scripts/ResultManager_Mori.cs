using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Xml;
using UnityEngine.SceneManagement;

public class ResultManager_Mori : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _titleTxt;
    [SerializeField]
    private TextMeshProUGUI _veloTxt;
    [SerializeField] 
    private TextMeshProUGUI _timeTxt;
    [SerializeField]
    private TextMeshProUGUI _fishTxt;
    [SerializeField]
    private TextMeshProUGUI _uriTxt;
    [SerializeField]
    private TextMeshProUGUI _crashTxt;

    [SerializeField]
    private GameObject _startC;
    [SerializeField]
    private GameObject _endC;

    [SerializeField]
    private GameObject _player;
    private Rigidbody2D _playerRig;

    /// <summary>
    /// Script:Accelerationで算出
    /// 最高速度
    /// </summary>
    public static float VelocityValue = 0;
    /// <summary>
    /// Script:Accelerationで算出
    /// かかった時間
    /// </summary>
    public static int TimeValue = 0;
    /// <summary>
    /// Script:
    /// 魚を食べた回数
    /// </summary>
    public static int FishValue = 0;
    /// <summary>
    /// Script:
    /// きゅうりに驚いた回数
    /// </summary>
    public static int UriValue = 0;
    /// <summary>
    /// Script:
    /// 障害物に当たった回数
    /// </summary>
    public static int CrashValue = 0;

    [SerializeField]
    private bool fuwafuwaMode = false;

    // Start is called before the first frame update
    void Start()
    {
        _endC.SetActive(false);
        _playerRig=_player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    [SerializeField, Button]
    public void Resulu()
    {
        _endC.SetActive (true);
        StartCoroutine(TextEnabled());
    }

    [SerializeField, Button]
    public void ResetTxt()
    {
        _titleTxt.text = "";
        _veloTxt.text = "";
        _timeTxt.text = "";
        _fishTxt.text = "";
        _uriTxt.text = "";
        _crashTxt.text = "";
        VelocityValue = 0;
        TimeValue = 0;
        FishValue = 0;
        UriValue = 0;
        CrashValue = 0;
        _startC.SetActive (true);
        _endC.SetActive(false);
        PlayerLayer.IsGameTime = false;
        Acceleration.doOnceTimeReload = false;
        _player.transform.position=new Vector3(0,-97.6f,0);
        _playerRig.velocity=Vector2.zero;
    }

    public IEnumerator TextEnabled()
    {
        _titleTxt.text = "飛行結果";
        TxtAnim(_titleTxt);
        yield return new WaitForSeconds(1);
        _veloTxt.text = "最高速度：" + VelocityValue.ToString("F2") + "m/s";
        TxtAnim(_veloTxt);
        yield return new WaitForSeconds(1);
        _timeTxt.text = "経過時間：" + TimeValue + "s";
        TxtAnim(_timeTxt);
        yield return new WaitForSeconds(1);
        _fishTxt.text = "魚を食べた回数：" + FishValue + "回";
        TxtAnim(_fishTxt);
        yield return new WaitForSeconds(1);
        _uriTxt.text = "キュウリに驚いた回数："+ UriValue + "回";
        TxtAnim(_uriTxt);
        yield return new WaitForSeconds(1);
        _crashTxt.text= "ぶつかった回数："+ CrashValue + "回";
        TxtAnim(_crashTxt);
    }

    [SerializeField, Button]
    public void TxtAnim(TextMeshProUGUI tmPro)
    {
        StartCoroutine(Simple(tmPro));
    }

    private IEnumerator Simple(TextMeshProUGUI tmpText)
    {
        // 文字の表示数を0に(テキストが表示されなくなる)
        tmpText.maxVisibleCharacters = 0;

        // テキストの文字数分ループ
        for (var i = 0; i < tmpText.text.Length; i++)
        {
            // 一文字ごとに0.2秒待機
            yield return new WaitForSeconds(0.2f);

            // 文字の表示数を増やしていく
            tmpText.maxVisibleCharacters = i + 1;
        }
    }
}
