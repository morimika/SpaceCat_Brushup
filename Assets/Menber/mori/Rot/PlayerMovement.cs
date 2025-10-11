using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //オブジェクトのスピード
    [SerializeField]
    private int speed;
    //円を描く半径
    [SerializeField]
    private int radius;
    //defPositionをVector3で定義する。
    private Vector3 defPosition;
    float x;
    float z;

    // Use this for initialization
    void Start()
    {
        defPosition = transform.position;    //defPositionを自分のいる位置に設定する。
    }

    // Update is called once per frame
    void Update()
    {
        //回転するやつ
        //speedを変更することで移動
        x = radius * Mathf.Sin(Time.time * speed);      //X軸の設定
        z = radius * Mathf.Cos(Time.time * speed);      //Z軸の設定

        transform.localPosition = new Vector2(x + defPosition.x, z/4 + defPosition.y);  //自分のいる位置から座標を動かす。

    }
}
