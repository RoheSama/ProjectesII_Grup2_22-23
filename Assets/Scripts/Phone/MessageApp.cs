using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageApp : MonoBehaviour
{
    public Image[] textGap;

    public Image lastText;

void Start()
{
    for(int i = 0; i < textGap.Length; i++)
    {
        textGap[i].GetComponent<Image>();
            textGap[i] = null;
    }

    for (int i = 0; i < textGap.Length; i++)
    {
       // textGap[i].color = new Color(1f, 1f, 1f, 0f);
    }
    
     for(int i = 0; i < textGap.Length; i++)
     {
            if (textGap[i] == null)
            {
                textGap[i] = lastText;
            }
     }

}


}
