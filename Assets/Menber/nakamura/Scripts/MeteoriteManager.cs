using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class MeteoriteManager : MonoBehaviour
{
    [SerializeField, Label("隕石")]
    private List<GameObject> meteoriteList = new List<GameObject>();
    [SerializeField, Label("隕石が降る速度")]
    private List<int> speedList = new List<int>();

    [SerializeField,Label("隕石が降る時のSE")]
    private AudioClip meteoriteSE;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //カウントダウンが0秒になったら
        if (CountDown.Inctance.IsLimitTime == true)
        {
            //隕石を降らす
            audioSource.PlayOneShot(meteoriteSE);
            int count = 0;
            foreach (GameObject obj in meteoriteList)
            {
                obj.transform.Translate(0f, -speedList[count] * Time.deltaTime, 0f);
                obj.transform.Translate(-speedList[count] * Time.deltaTime, 0f, 0f);
                count++;
            }

            DestroyMeteorite();
        }
    }

    /// <summary>
    /// 画面外に出たら消す
    /// </summary>
    private void DestroyMeteorite()
    {
        for (int i = meteoriteList.Count - 1; i >= 0; i--)
        {
            GameObject obj = meteoriteList[i];
            if (obj.transform.position.x < -680)
            {
                meteoriteList.RemoveAt(i);
                Destroy(obj);
            }
        }
    }
}
