using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    [SerializeField] private float speed  = 2.0f;
    [SerializeField] private float radius = 5.0f;
    public GameObject target;
    private float x;
    private float y;
    private float z;

    private void Update()
    {
        x = target.transform.position.x + radius * Mathf.Sin(Time.time * speed);
        y = radius * Mathf.Cos(Time.time * speed);
        y = y + target.transform.position.y;
        z = target.transform.position.z;

        transform.position = new Vector3(x, y, z);
    }
}