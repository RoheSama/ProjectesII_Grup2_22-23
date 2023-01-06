using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public float followSpeed = 2f;
    public Transform target;

    public float duration = 0.5f;
    public bool start = false;
    public AnimationCurve curve;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = (Vector3)target.GetComponent<Rigidbody2D>().velocity * 0.1f + target.position + Vector3.up;
        targetPos.z = -10f;
        Vector3 newPos = new Vector3(targetPos.x, targetPos.y, -10f);
        transform.position = Vector3.Slerp(targetPos, newPos, followSpeed * Time.deltaTime);

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
