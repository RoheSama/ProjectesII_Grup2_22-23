using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class BloodSplatter : MonoBehaviour
{
    public GameObject IAFather;
    public bool activated;

    [SerializeField] float spawnTime;
    [SerializeField] float despawnTime;

    [SerializeField] SpriteRenderer sp;

    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        activated = IAFather.GetComponent<EnemyHitNew>().died;
        this.transform.position = IAFather.transform.position; 
        
        if (activated)
        {
            StartCoroutine(SpawnBlood());
            StartCoroutine(DespawnBlood());
        }
    }

    IEnumerator SpawnBlood()
    {
        yield return new WaitForSeconds(spawnTime);
        sp.enabled = true;
    }

    IEnumerator DespawnBlood()
    {
        yield return new WaitForSeconds(despawnTime);
        anim.SetTrigger("Blood");
        anim.enabled = true;
        yield return new WaitForSeconds(0.5f);
        sp.enabled = false;
        anim.enabled = false;
    }
}
