using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float _h;
    float _v;
    float _speed;
    Rigidbody2D _rigid;

    // Start is called before the first frame update
    void Start()
    {
        _speed = 250.0f;
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        _rigid.velocity = new Vector2(_h, _v) * _speed * Time.fixedDeltaTime;
    }
}
