using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] Camera cam;

    private float zoom;
    private float zoomFactor = 3f;
    private float zoomLerpSpeed = 10f;
    private float maxIn = 1.5f;
    private float maxOut = 5f;

    private void Start()
    {
        cam = Camera.main;
        zoom = cam.orthographicSize;
    }
    // Update is called once per frame
    void Update()
    {
        float scrollData;

        scrollData = Input.GetAxis("Mouse ScrollWheel");

        zoom -= scrollData * zoomFactor;
        zoom = Mathf.Clamp(zoom, maxIn, maxOut);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoom, Time.deltaTime);
    }
}
