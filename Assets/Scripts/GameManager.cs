using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager _talkManager;
    public GameObject _canvas;
    public GameObject _dialog;
    public Text _talkText;
    public GameObject _scanObject;
    public bool _isAction;
    public int _talkIndex;
    public Image _portraitImg;

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
        { 
            _isAction = true;
            _scanObject = scanObj;
            // _talkText.text = "�̰��� �̸��� " + scanObj.name + " �Դϴ�.";
            ObjectData objData = _scanObject.GetComponent<ObjectData>();
            Talk(objData._id, objData._isNpc);
        }

        _dialog.SetActive(_isAction);
    }

    void Talk(int id, bool isNpc)
    {
        string talkData = _talkManager.GetTalk(id, _talkIndex);

        if (talkData == null)
        {
            _isAction = false;
            _talkIndex = 0;
            return;
        }
            

        if (isNpc)
        {
            _talkText.text = talkData.Split(':')[0];
            _portraitImg.sprite = _talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            _portraitImg.color = new Color(1,1,1,1);
        }
        else
        {
            _talkText.text = talkData;
            _portraitImg.color = new Color(1, 1, 1, 0);
        }

        _isAction = true;
        _talkIndex++;
    }
}
