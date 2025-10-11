using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Move : MonoBehaviour
{
    [SerializeField, Foldout("ポイント"), Label("左端")]
    private Vector2 leftEdge;
    [SerializeField, Foldout("ポイント"), Label("右端")]
    private Vector2 rightEdge;
    [SerializeField, Label("スピード")]
    private float moveSpeed = 1.0f;
    //方向
    private int direction = 1;

    void FixedUpdate()
    {
        //方向転換
        if (transform.position.x >= rightEdge.x)
            direction = -1;
        if (transform.position.x <= leftEdge.x)
            direction = 1;
        //移動
        //mori 追記 y座標
        transform.position 
            = new Vector2(this.transform.position.x + moveSpeed * Time.fixedDeltaTime * direction
                        , this.transform.position.y);
    }
}
