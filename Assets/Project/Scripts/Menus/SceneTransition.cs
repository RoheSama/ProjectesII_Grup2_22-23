using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private GameObject image;
    public Animator anim;
    public GameObject dialogue;

    void Update()
    {
        if(dialogue.GetComponent<TutorialTransition>().chargeScene)
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
