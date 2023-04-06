using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplatter : MonoBehaviour
{
    public GameObject IAFather;
    public bool activated;

    [SerializeField] SpriteRenderer sp;

    // Update is called once per frame
    void Update()
    {
        activated = IAFather.GetComponent<EnemyHitNew>().died;
        this.transform.position = IAFather.transform.position; 
        
        if (activated)
        {
            StartCoroutine(SpawnBlood());
        }
    }

    IEnumerator SpawnBlood()
    {
        yield return 0.3f;
        sp.enabled = true;
    }
}
