using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AlphaOcclusionSolver : MonoBehaviour
{
    List<GameObject> itemsInside = new List<GameObject>();

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        itemsInside.Add(collision.gameObject);

        //Set alpha to 0.2
        this.GetComponent<Tilemap>().color = new Color(1f, 1f, 1f, 0.25f);
        //Debug.Log("Entró :)");

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject obj = itemsInside.Find((x) => x == collision.gameObject);
        if(obj != null)
        {
            itemsInside.Remove(obj);
            if(itemsInside.Count <= 0)
            {
                //Set alpha to 1
                this.GetComponent<Tilemap>().color = new Color(1f, 1f, 1f, 1f);
                //Debug.Log("Se salio :(");
            }
        }
    }
}
