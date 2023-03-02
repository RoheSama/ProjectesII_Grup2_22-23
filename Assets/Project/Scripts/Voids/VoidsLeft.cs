using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VoidsLeft : MonoBehaviour
{
    public int moneyValue = 5;
    public TMP_Text moneyCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyCounter.SetText(moneyValue.ToString());
    }

   public void studentKill()
    {
        moneyValue--;
    }
}
