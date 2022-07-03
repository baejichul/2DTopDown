using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{

    public int charPerSeconds;
    public GameObject endCursor;

    string targetMsg;
    Text msgText;
    int index;
    float interval;
    AudioSource audSRc;
    public bool is_Animation;
    

    private void Start()
    {
        charPerSeconds = 15;
        msgText   = GetComponent<Text>();
        endCursor = transform.parent.Find("ImgEndCursor").gameObject;
        audSRc    = GetComponent<AudioSource>();
    }

    public void SetMsg(string msg)
    {   
        if (is_Animation)
        {
            msgText.text = targetMsg;
            CancelInvoke();
            EffectEnd();
        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }
    }

    void EffectStart()
    {
        msgText.text = "";
        index = 0;
        endCursor.SetActive(false);

        interval = 1.0f / charPerSeconds;

        is_Animation = true;
        Invoke("EffectIng", interval);
    }

    void EffectIng()
    {
        if (msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }

        if (targetMsg[index] != ' ' && targetMsg[index] != '.')
            audSRc.Play();

        msgText.text += targetMsg[index];
        index++;
        

        Invoke("EffectIng", interval);
    }

    void EffectEnd()
    {
        is_Animation = false;
        endCursor.SetActive(true);
    }
}
