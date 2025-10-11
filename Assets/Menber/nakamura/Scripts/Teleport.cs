using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Teleport : MonoBehaviour
{
    [SerializeField, Label("テレポートの出口")]
    private GameObject teleportExitPos;
    [SerializeField, Tag, Label("衝突した時テレポートする対象のタグ")]
    private string teleportTag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //対象と衝突したら
        if(collision.gameObject.CompareTag(teleportTag))
        {
            //mori 追記　速度維持
            Rigidbody2D rg = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 vel = rg.velocity;
            //指定場所に強制移動させる
            collision.gameObject.transform.position = teleportExitPos.transform.position;
            //moriワープ前速度反映
            rg.velocity = vel;
        }
    }
}
