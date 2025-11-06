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

    private Rigidbody2D rb;
    private GameObject parent;

    //defPositionをVector3で定義する。
    private Vector3 defPosition;
    float x;
    float z;


    float xPos;
    float yPos;

    // Use this for initialization
    void Start()
    {
        //defPositionを自分のいる位置に設定する。
        defPosition = transform.position;
        //parent = this.transform.parent.gameObject;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //マウス移動量取得
        float mouse_x_delta = Input.GetAxis("Mouse X");
        float mouse_y_delta = Input.GetAxis("Mouse Y");


        //回転するやつ
        //speedを変更することで移動
        //X軸
        x = Mathf.Sin(Time.deltaTime * mouse_x_delta);
        //Z軸
        z = Mathf.Cos(Time.deltaTime * mouse_y_delta);

        //
        xPos = x / 10;
        //yPos = z / 40;

        //円状に移動させる
        rb.AddForce(new Vector2(xPos, 0));
        //transform.position = new Vector2(transform.position.x, parent.transform.position.y);

        /*
        //自身と円形に移動制限させたい位置の中心点との距離を測り半径以上になっていれば処理
        if (Vector3.Distance(transform.position, parent.transform.position) > radius)
        {
            //中心点から自身までの方向ベクトルを作る
            Vector3 nor = transform.position - parent.transform.position;
            //作った方向ベクトルを正規化する
            nor.Normalize();
            //方向ベクトル分半径に移動させる
            transform.position = nor * radius;
        }
        */
    }
}
