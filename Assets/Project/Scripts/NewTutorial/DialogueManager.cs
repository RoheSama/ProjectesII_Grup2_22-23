using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogue1;
    public GameObject dialogue2;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TutorialIA")
        {
            dialogue1.SetActive(false);
            dialogue2.SetActive(true);
            
        }
    }
}
