using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{

    Dictionary<int, string[]> _talkData;
    Dictionary<int, Sprite> _portraitData;

    public Sprite[] _portraitArr;

    private void Awake()
    {
        _talkData = new Dictionary<int, string[]>();
        _portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        _talkData.Add(1000, new string[] {"�ȳ�? �� Ludo��:0", "�̰��� ó�� �Ա���?:1" });
        _talkData.Add(2000, new string[] {"����? �� Luna��:0", "�� ��� �Դ�?:1", "�� �������� �Ծ�:2" });
        _talkData.Add(100, new string[] {"����� �������ڴ�." });
        _talkData.Add(200, new string[] {"������ ����ߴ� ������ �ִ� å���̴�." });

        _portraitData.Add(1000 + 0, _portraitArr[0]);
        _portraitData.Add(1000 + 1, _portraitArr[1]);
        _portraitData.Add(1000 + 2, _portraitArr[2]);
        _portraitData.Add(1000 + 3, _portraitArr[3]);
        _portraitData.Add(2000 + 0, _portraitArr[4]);
        _portraitData.Add(2000 + 1, _portraitArr[5]);
        _portraitData.Add(2000 + 2, _portraitArr[6]);
        _portraitData.Add(2000 + 3, _portraitArr[7]);
    }

    public string GetTalk(int id, int talkIndex)
    {

        if (talkIndex == _talkData[id].Length)
            return null;
        else
        return _talkData[id][talkIndex];
    }


    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return _portraitData[id + portraitIndex];
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
