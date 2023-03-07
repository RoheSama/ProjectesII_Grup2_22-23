using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceVoids : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClipWalk;
    public AudioClip audioCry;
    public AudioClip audioHide;

    public GameObject gameObjectVoid;

    public float x;
    public float y;
    public float lastX;
    public float lastY;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        x = gameObjectVoid.transform.position.x;
        y = gameObjectVoid.transform.position.y;
        timer += Time.deltaTime;

        if (timer >= 1)
        {
            lastX = x;
            lastY = y;
            timer = 0;
        }

        if (x < lastX + 0.1f && x > lastX - 0.1f && y < lastY + 0.1f && y > lastY - 0.1f)
        {
            walkingVoidOn();
        }

    }

    public void walkingVoidOn()
    {
        audioSource.clip = audioClipWalk;
        audioSource.Play();
    }

    public void cryingVoidOn()
    {
        audioSource.clip = audioCry;
        audioSource.Play();
    }

    public void hideVoidOn()
    {
        audioSource.clip = audioHide;
        audioSource.Play();
    }
}
