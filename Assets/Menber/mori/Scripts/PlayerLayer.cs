using DG.Tweening;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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

    [SerializeField]
    private GameObject timeCanvas;

    public static bool DoFuwa;

    [SerializeField]
    private AudioClip _audioClip;
    [SerializeField]
    private AudioSource _audioSource;

    void Start()
    {
        _playerSpriteRend =this.GetComponent<SpriteRenderer>();
        _playerRig=_player.GetComponent<Rigidbody2D>();
        IsGameTime = false;
        timeCanvas.SetActive(false);
        _doFollow = false;
        _startC.SetActive(true);
        this.gameObject.transform.position = new Vector2(0, 0.5f);
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
    
    [SerializeField, Button]
    public void ToGame()
    {
        _audioSource.PlayOneShot(_audioClip);
        this.gameObject.transform.DOMoveY(_player.transform.position.y, 3f).SetEase(Ease.InOutQuad);
        Invoke(nameof(ChangeParent), 3f);
    }
    
    [SerializeField, Button]
    public void ToResult()
    {
        _endC.SetActive(true);
        timeCanvas.SetActive(false);
        IsGameTime = false;
        this.gameObject.transform.DOMoveY(0, 3f).SetEase(Ease.InOutQuad);
        this.gameObject.transform.DOMoveX(0, 3f).SetEase(Ease.InOutQuad);
    }
    public void ChangeParent()
    {
        IsGameTime = true;
        _doFollow = true;
        _startC.SetActive(false);
        timeCanvas.SetActive(true);
    }
}
