using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEngine.GraphicsBuffer;

public class targetScript : MonoBehaviour
{
    public Collider2D col;
    public GameObject Target { get; private set; }
    PatternController patternController;
    [HideInInspector]
    public bool isPatternActivated = false;

    void Start()
    {
        //isPatternActivated = GameObject.Find("Pattern Controller").GetComponent<PatternController>().corruptionActivated;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //funcio per cambiar el tag
    void OnTriggerEnter2D(Collider2D col)
    {
        Target = col.gameObject;
    }

    public void ClearTarget()
    {
        Target = null;
    }
    //una vegada cambiat el tag y fet el pattern
}
