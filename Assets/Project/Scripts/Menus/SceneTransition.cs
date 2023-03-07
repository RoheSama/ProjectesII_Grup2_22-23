using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private GameObject image;
    public Animator anim;
    public GameObject dialogue;


    // Update is called once per frame
    void Update()
    {
        if(dialogue.GetComponent<Dialogue>().chargeScene)
        {
            image.SetActive(true);
            StartCoroutine(LoadScene());
            
        }
    }

    IEnumerator LoadScene()
    {
        anim.SetTrigger("start");
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene("TopDownMap");
    }
}
