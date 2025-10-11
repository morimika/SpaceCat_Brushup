using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
    [SerializeField]
    private float speed = 80;

    private Rigidbody2D _rigidbody;
    private float time;
    public static bool doOnceTimeReload = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody=GetComponent<Rigidbody2D>();
        time = 0;
        doOnceTimeReload = false;
    }
    // Update is called once per frame
    void Update()
    {
        var dire = Vector2.zero;
        //accelerationで回転を取得、Unityで言うz軸回転
        //-1かけると順になる
        //等倍で0~0.035、0~0.035
        dire.x = Input.acceleration.x;
        dire *= Time.deltaTime;
        //速度変更
        //_rigidbody.velocity = new Vector2(dire.x * speed * -1, _rigidbody.velocity.y);
        //加速度変更
        _rigidbody.AddForce(new Vector2(dire.x * speed, _rigidbody.gravityScale)
            , ForceMode2D.Force);

        //スタート中
        if(PlayerLayer.IsGameTime)
        {
            //最高速度更新
            if (ResultManager_Mori.VelocityValue < _rigidbody.velocity.y)
            {
                ResultManager_Mori.VelocityValue = _rigidbody.velocity.y;
            }
            //タイム測定
            time += Time.deltaTime;
        }
        //タイムの更新が入っている　かつ　まだ更新していないとき
        else if (time != 0 && doOnceTimeReload == false)
        {
            ResultManager_Mori.TimeValue = (int)time;
            ResultManager_Mori.VelocityValue *= 9.8f;
            doOnceTimeReload = true;
        }
    }
}

