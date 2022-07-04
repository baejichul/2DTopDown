using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager _talkManager;
    public QuestManager _questManager;
    public GameObject _canvas;
    public GameObject _menuSet;
    public GameObject _player;
    public Animator _dialog;
    public TypeEffect _talkText;
    public GameObject _scanObject;
    public Text _questText;
    public bool _isAction;
    public int _talkIndex;
    public Image _portraitImg;


    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _canvas = GameObject.FindGameObjectWithTag("Canvas");
        _menuSet = _canvas.transform.Find("MenuSet").gameObject;
        _dialog = _canvas.transform.Find("Dialog").gameObject.GetComponent<Animator>();
        _questText = _menuSet.transform.Find("QuestPanel").Find("TxtQuest").GetComponent<Text>();
        // _talkText = _canvas.transform.Find("Dialog").Find("Image").Find("Text").GetComponent<Text>();
        _talkText = _canvas.transform.Find("Dialog").Find("Image").Find("Text").GetComponent<TypeEffect>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameLoad();
        // Debug.Log ( _questManager.CheckQuest() );
        _questText.text = _questManager.CheckQuest();
    }

    // Update is called once per frame
    void Update()
    {
        // Sub Menu
        if (Input.GetButtonDown("Cancel"))
        {
            if (_menuSet.activeSelf)
                _menuSet.SetActive(false);
            else
                _menuSet.SetActive(true);
        }   
    }

    public void Action(GameObject scanObj)
    {    
        _isAction = true;
        _scanObject = scanObj;
        // _talkText.text = "이것의 이름은 " + scanObj.name + " 입니다.";
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
            // Debug.Log( _questManager.CheckQuest(id) );
            _questText.text = _questManager.CheckQuest(id);
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

    public void GameSave()
    {
        // _player.x
        // _player.y
        // _questId
        // _questActionIndex
        PlayerPrefs.SetFloat("PlayerX", _player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", _player.transform.position.y);
        PlayerPrefs.SetInt("QuestId", _questManager._questId);
        PlayerPrefs.SetInt("QuestActionIndex", _questManager._questActionIndex);
        PlayerPrefs.Save();

        _menuSet.SetActive(false);
    }

    public void GameLoad()
    {
        if ( !PlayerPrefs.HasKey("PlayerX") )
            return;

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int questId = PlayerPrefs.GetInt("QuestId");
        int questActionIndex = PlayerPrefs.GetInt("QuestActionIndex");

        _player.transform.position = new Vector3(x, y);
        _questManager._questId = questId;
        _questManager._questActionIndex = questActionIndex;
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
