using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject _canvas;
    public GameObject _dialog;
    public Text _talkText;
    public GameObject _scanObject;
    public bool _isAction;

    // Start is called before the first frame update
    void Start()
    {
        _canvas   = GameObject.FindGameObjectWithTag("Canvas");
        _dialog   = _canvas.transform.Find("Dialog").gameObject;
        _talkText = _canvas.transform.Find("Dialog").Find("Image").Find("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Action(GameObject scanObj)
    {
        if (_isAction)
        {
            _isAction = false;
        }
        else
        {
            _isAction = true;
            _scanObject = scanObj;
            _talkText.text = "이것의 이름은 " + scanObj.name + " 입니다.";
        }

        _canvas.transform.Find("Dialog").gameObject.SetActive(_isAction);
    }
}
