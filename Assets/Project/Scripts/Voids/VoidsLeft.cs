using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VoidsLeft : MonoBehaviour
{
    public int totalVoids;
    public TMP_Text voidsCounter;
    public int voidsKilled;

    public GameObject controlPoint;
    public GameObject killThePriestMessage;
    
    void Update()
    {
        voidsCounter.SetText(totalVoids.ToString());

        if(totalVoids == 0)
        {
            killThePriestMessage.SetActive(true);
        }
    }

   public void studentKill()
   {
        totalVoids--;
        voidsKilled++;
   }

}
