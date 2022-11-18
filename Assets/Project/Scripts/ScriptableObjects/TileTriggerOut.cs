using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileTriggerOut : MonoBehaviour
{
    public Collider2D col;
    public Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        tilemap.color = new Color(tilemap.color.r, tilemap.color.g, tilemap.color.b, 1f);
    }
}
