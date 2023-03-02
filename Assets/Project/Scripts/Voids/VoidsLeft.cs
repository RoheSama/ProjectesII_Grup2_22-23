using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VoidsLeft : MonoBehaviour
{
    public int totalVoids;
    public TMP_Text voidsCounter;
    
    void Update()
    {
        voidsCounter.SetText(totalVoids.ToString());
    }

   public void studentKill()
    {
        totalVoids--;
    }
}
