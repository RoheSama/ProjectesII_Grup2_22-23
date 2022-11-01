using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public float panSpeed = 24f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dx = panSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float dy = panSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        Camera.main.transform.Translate(dx, dy, 0);


    }
}
