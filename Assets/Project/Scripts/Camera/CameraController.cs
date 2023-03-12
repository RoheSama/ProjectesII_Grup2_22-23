using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetNormal;
    public Transform targetShadow;

    public float duration = 0.5f;
    public bool start = false;
    public AnimationCurve curve;

    void Update()
    {
        if (FindObjectOfType<AbilityUI>().powerUpActivated == false)
        {
            transform.position = new Vector3(targetNormal.transform.position.x,
           targetNormal.transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(targetShadow.transform.position.x,
           targetShadow.transform.position.y, transform.position.z);
        }


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
