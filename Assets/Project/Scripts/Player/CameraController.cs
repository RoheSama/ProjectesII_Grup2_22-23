using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public float duration = 0.5f;
    public bool start = false;
    public AnimationCurve curve;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, 
            target.transform.position.y, transform.position.z);

        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        }
    }

    IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strenght = curve.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strenght;
            yield return null;
        }
        transform.position = startPosition;
    }
}
