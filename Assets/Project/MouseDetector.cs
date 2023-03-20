using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MouseDetector : MonoBehaviour
{
    public GameObject descriptionBox;

    private void Start()
    {
        descriptionBox.SetActive(false);
    }

    void OnMouseOver()
    {
        if(descriptionBox.activeSelf== false)
        {
            Debug.Log("A");
            descriptionBox.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        if (descriptionBox.activeSelf == true)
        {
            descriptionBox.SetActive(false);
        }
    }
}