using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEditor.ShaderGraph.Legacy;

public class Gimmick : MonoBehaviour
{
    
    [SerializeField, Label("猫：現在の速度")]      private float catCurentSpeed;
    [SerializeField, Label("猫：通常の速度")]      private float speed         　   = 5.0f;
    [SerializeField, Label("猫：加速の持続時間")]  private float accelerateDuration = 0.5f; 
    [SerializeField, Label("猫：加速値")]          private float acceleration       = 4.0f;
    [SerializeField, Label("猫：加速中かどうか")]  private bool _isSpeedAccelerated = false;
    
    // Start is called before the first frame update
    void Start()
    {
        // 猫の速度を取得
        // speed = Kansuu.Hensu;

        // 現在の速度をに猫の移動速度を設定
        catCurentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    // 猫を動かす（後で消す
    void PlayerMove()
    {
        // プレイヤーの移動
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ);
        transform.Translate(movement * catCurentSpeed * Time.deltaTime);
    }   

    // 猫の加速
    void AcceleratedCat()
    {
        if (_isSpeedAccelerated == false)
        {
            _isSpeedAccelerated = true;
            catCurentSpeed = speed * acceleration;
            Invoke("ResetSpeed", accelerateDuration);
        }
    }

    void ResetSpeed()
    {
        // 速度を通常に戻す
        catCurentSpeed = speed;
        // 加速を解除
        _isSpeedAccelerated = false;
    }

    // ギミックにぶつかった際に加速
    private void OnCollisionEnter2D (Collision2D coll)
    {
        Debug.Log("加速ギミックに当たった=3");

        // 衝突したタグが"SpeedBoost"なら加速する
        if (coll.gameObject.CompareTag("AccelerateGimmick"))
        {
            AcceleratedCat();
        }

        // 10/25
        // エフェクトを出して消える
        // 加速の音

    }
}
