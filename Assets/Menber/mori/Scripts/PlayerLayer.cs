using DG.Tweening;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLayer : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _playerSpriteRend;

    public static bool _doFollow;

    [SerializeField]
    private GameObject _player;
    private Rigidbody2D _playerRig;

    [SerializeField]
    private GameObject _startC;
    [SerializeField]
    private GameObject _endC;

    public static bool IsGameTime = false;

    public static bool DoFuwa;
    void Start()
    {
        _playerSpriteRend =this.GetComponent<SpriteRenderer>();
        _playerRig=_player.GetComponent<Rigidbody2D>();
        IsGameTime = false;
    }

    private void Update()
    {
        if(_doFollow)
        {
            this.transform.position=_player.transform.position;
        }
        if(!IsGameTime)
        {
            _playerRig.bodyType = RigidbodyType2D.Kinematic;
        }
        else
        {
            _playerRig.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    /*
    [SerializeField, Button]
    public async void ToGame()
    {
        await this.gameObject.transform.DOMoveY(-125, 3f).SetEase(Ease.InOutQuad);
        IsGameTime = true;
        ChangeParent();
    }
    */
    [SerializeField, Button]
    public void ToResult()
    {
        _endC.SetActive(true);
        IsGameTime = false;
        this.gameObject.transform.DOMoveY(0, 3f).SetEase(Ease.InOutQuad);
        this.gameObject.transform.DOMoveX(0, 3f).SetEase(Ease.InOutQuad);
    }
    public void ChangeParent()
    {
        _doFollow = true;
        _startC.SetActive(false);
    }
}
