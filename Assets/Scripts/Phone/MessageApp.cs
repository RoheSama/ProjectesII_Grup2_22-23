using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageApp : MonoBehaviour
{
    public Sprite[] textGap;

    public Sprite lastText;

void Start()
{
    for(int i = 0; i < textGap.Length; i++)
    {
        textGap[i].GetComponent<Image>();
        textGap[i] = null;
    }

     for(int i = 0; i < textGap.Length; i++)
     {
            if (textGap[i] == null)
            {
                Debug.Log("a");
                textGap[i] = lasText;
            }
     }

}


}
