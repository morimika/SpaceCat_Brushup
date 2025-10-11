using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]
    private ResultManager_Mori _re;

    [SerializeField]
    private CircleCollider2D _circleCollider;

    [SerializeField]
    private PlayerLayer _playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerLayer.IsGameTime = false;
            _playerLayer.ToResult();
            _re.Resulu();
            PlayerLayer._doFollow = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerLayer.IsGameTime = false;
            _playerLayer.ToResult();
            _re.Resulu();
            PlayerLayer._doFollow = false;
        }
    }
}
