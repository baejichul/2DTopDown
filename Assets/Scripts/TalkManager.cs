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
        _talkData.Add(1000, new string[] {"안녕? 난 Ludo야:0", "이곳에 처음 왔구나?:1" });
        _talkData.Add(2000, new string[] {"여어? 난 Luna야:0", "넌 어디서 왔니?:1", "난 강남에서 왔어:2" });
        _talkData.Add(100, new string[] {"평범한 나무상자다." });
        _talkData.Add(200, new string[] {"누군가 사용했던 흔적이 있는 책상이다." });

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
