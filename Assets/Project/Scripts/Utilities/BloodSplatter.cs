using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplatter : MonoBehaviour
{
    public GameObject IAFather;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = IAFather.transform.position; 
        
        if (IAFather.GetComponent<EnemyHitNew>().died)
        {
            this.gameObject.SetActive(true);
        }
    }
}
