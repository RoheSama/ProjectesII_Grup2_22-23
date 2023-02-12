using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayerScript : MonoBehaviour
{

    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        // sprite.sortingOrder = 3;
       //  sprite.sortingLayerName = "EMMA MAMAGUEVA";
    }
}
