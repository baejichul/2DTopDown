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
        // TalkData
        _talkData.Add(1000, new string[] { "�ȳ�? �� Ludo��:0", "�̰��� ó�� �Ա���?:1" });
        _talkData.Add(2000, new string[] { "����? �� Luna��:0", "�� ��� �Դ�?:1", "�� �������� �Ծ�:2" });
        _talkData.Add(3000, new string[] {"����� �������ڴ�." });
        _talkData.Add(4000, new string[] {"������ ����ߴ� ������ �ִ� å���̴�." });


        //Quest Talk
        _talkData.Add(10 + 1000, new string[] { "���:0", "�̸����� ���� ������ �ִٴµ�:1", "Luna�� �˷��ٲ���:2" });
        _talkData.Add(11 + 2000, new string[] { "����:1", "�� ������ ������ ������ �°ž�?:0", "�׷� �� �� �ϳ� ���ָ� �����ٵ�:2", "������ �� ������ �ְԳ�:3" });

        _talkData.Add(20 + 1000, new string[] { "�絵�ǵ���?:1", "���� �긮�� �ٴϸ� ������:3", "���߿� �絵���� �Ѹ��� �ؾ߰ھ�:3" });
        _talkData.Add(20 + 2000, new string[] { "ã���� �� �� ������ ��:1", });
        _talkData.Add(20 + 5000, new string[] { "��ó���� ������ ã�Ҵ�." });
        _talkData.Add(21 + 2000, new string[] { "��, ã���༭ ����.:2", });

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
        // Debug.Log($"id = {id}, talkIndex = {talkIndex} ");
        if (!_talkData.ContainsKey(id))
        {
            if(!_talkData.ContainsKey(id - id %10))
                return GetTalk(id - id % 100, talkIndex);
            else
                return GetTalk(id - id % 10, talkIndex);
        }
        
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
