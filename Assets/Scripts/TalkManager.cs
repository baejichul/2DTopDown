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
        _talkData.Add(1000, new string[] { "안녕? 난 Ludo야:0", "이곳에 처음 왔구나?:1" });
        _talkData.Add(2000, new string[] { "여어? 난 Luna야:0", "넌 어디서 왔니?:1", "난 강남에서 왔어:2" });
        _talkData.Add(3000, new string[] {"평범한 나무상자다." });
        _talkData.Add(4000, new string[] {"누군가 사용했던 흔적이 있는 책상이다." });


        //Quest Talk
        _talkData.Add(10 + 1000, new string[] { "어서와:0", "이마을에 놀라운 전설이 있다는데:1", "Luna가 알려줄꺼야:2" });
        _talkData.Add(11 + 2000, new string[] { "여어:1", "이 마을의 전설을 들으러 온거야?:0", "그럼 일 좀 하나 해주면 좋을텐데:2", "동전을 좀 수집해 주게나:3" });

        _talkData.Add(20 + 1000, new string[] { "루도의동전?:1", "돈을 흘리고 다니면 못쓰지:3", "나중에 루도에게 한마디 해야겠어:3" });
        _talkData.Add(20 + 2000, new string[] { "찾으면 꼭 좀 가져다 줘:1", });
        _talkData.Add(20 + 5000, new string[] { "근처에서 동전을 찾았다." });
        _talkData.Add(21 + 2000, new string[] { "엇, 찾아줘서 고마워.:2", });

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
