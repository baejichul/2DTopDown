using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float _h;
    float _v;
    float _speed;
    Rigidbody2D _rigid;
    Animator _ani;

    bool _hDown;
    bool _vDown;
    bool _hUp;
    bool _vUp;
    bool _isHorizontalMove;
    Vector3 _vecDir;
    GameObject _scanObject;

    // Start is called before the first frame update
    void Start()
    {
        _speed = 250.0f;
        _rigid = GetComponent<Rigidbody2D>();
        _ani   = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        UpdatePlayerAnimation();
        CheckHorizontalMove();

        if (_vDown && _v == 1)
            _vecDir = Vector3.up;
        if (_vDown && _v == -1)
            _vecDir = Vector3.down;
        if (_hDown && _h == 1)
            _vecDir = Vector3.right;
        if (_hDown && _h == -1)
            _vecDir = Vector3.left;

        if (Input.GetButtonDown("Jump") && _scanObject != null )        // SPACE BAR
            Debug.Log($"This is {_scanObject.name}");
    }

    void FixedUpdate()
    {
        // Move(_h, _v);
        MoveDirect(_isHorizontalMove, _h, _v);
        ScanLayer();
    }

    void CheckHorizontalMove()
    {   
        _hDown = Input.GetButtonDown("Horizontal");
        _vDown = Input.GetButtonDown("Vertical");
        _hUp = Input.GetButtonUp("Horizontal");
        _vUp = Input.GetButtonUp("Vertical");

        if (_hDown)
            _isHorizontalMove = true;
        else if (_vDown)
            _isHorizontalMove = false;
        else if (_vUp || _hUp)
            _isHorizontalMove = (_h != 0);
    }

    void Move(float h, float v)
    {
        _rigid.velocity = new Vector2(h, v) * _speed * Time.fixedDeltaTime;
    }

    void MoveDirect(bool isHorizontalMove, float h, float v)
    {
        Vector2 vec = isHorizontalMove ? new Vector2(h, 0 ) : new Vector2(0, v);
        _rigid.velocity = vec * _speed * Time.fixedDeltaTime;
    }

    void UpdatePlayerAnimation()
    {
        /*
        if (Input.GetKey(KeyCode.LeftArrow))
            _ani.SetTrigger("PlayerLeft");
        else if (Input.GetKey(KeyCode.RightArrow))
            _ani.SetTrigger("PlayerRight");
        else if (Input.GetKey(KeyCode.UpArrow))
            _ani.SetTrigger("PlayerUp");
        else if (Input.GetKey(KeyCode.DownArrow))
            _ani.SetTrigger("PlayerDown");
        */

        if (_h < 0)
            _ani.SetTrigger("PlayerLeft");
        else if (_h > 0)
            _ani.SetTrigger("PlayerRight");
        else if (_v > 0)
            _ani.SetTrigger("PlayerUp");
        else if (_v < 0)
            _ani.SetTrigger("PlayerDown");
    }

    void ScanLayer()
    {
        Debug.DrawRay(_rigid.position, _vecDir * 1.5f, new Color(1, 0, 0));  // Color.green
        RaycastHit2D rayHit = Physics2D.Raycast( _rigid.position + new Vector2(_vecDir.x, _vecDir.y) , _vecDir, 2.5f, LayerMask.GetMask("object") );

        if (rayHit.collider != null)
            _scanObject = rayHit.collider.gameObject;
        else
            _scanObject = null;
    }


}
