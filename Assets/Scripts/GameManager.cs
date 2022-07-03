using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager _talkManager;
    public QuestManager _questManager;
    public GameObject _canvas;
    public Animator _dialog;
    public TypeEffect _talkText;
    public GameObject _scanObject;
    public bool _isAction;
    public int _talkIndex;
    public Image _portraitImg;

    // Start is called before the first frame update
    void Start()
    {
        _canvas   = GameObject.FindGameObjectWithTag("Canvas");
        _dialog   = _canvas.transform.Find("Dialog").gameObject.GetComponent<Animator>();
        // _talkText = _canvas.transform.Find("Dialog").Find("Image").Find("Text").GetComponent<Text>();
        _talkText = _canvas.transform.Find("Dialog").Find("Image").Find("Text").GetComponent<TypeEffect>();

        // Debug.Log ( _questManager.CheckQuest() );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Action(GameObject scanObj)
    {    
        _isAction = true;
        _scanObject = scanObj;
        // _talkText.text = "�̰��� �̸��� " + scanObj.name + " �Դϴ�.";
        ObjectData objData = _scanObject.GetComponent<ObjectData>();
        Talk(objData._id, objData._isNpc);

        _dialog.SetBool("isShow", _isAction);
    }

    void Talk(int id, bool isNpc)
    {
        // Set Talk Data
        int _questTalkIndex = 0;
        string talkData = "";

        if (_talkText.is_Animation)
            _talkText.SetMsg("");
        else
        {
            _questTalkIndex = _questManager.GetQuestTalkIndex(id);
            talkData = _talkManager.GetTalk(id + _questTalkIndex, _talkIndex);
        }

        // End Talk
        if (talkData == null)
        {
            _isAction = false;
            _talkIndex = 0;
            Debug.Log( _questManager.CheckQuest(id) );
            return;
        }
            
        // Continue Talk
        if (isNpc)
        {
            _talkText.SetMsg(talkData.Split(':')[0]);

            // Show Portrait
            _portraitImg.sprite = _talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            _portraitImg.color = new Color(1,1,1,1);
        }
        else
        {
            _talkText.SetMsg(talkData);
            _portraitImg.color = new Color(1, 1, 1, 0);
        }

        _isAction = true;
        _talkIndex++;
    }
}
