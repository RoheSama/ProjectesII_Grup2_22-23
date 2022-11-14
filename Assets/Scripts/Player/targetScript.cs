using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using static UnityEngine.GraphicsBuffer;

public class targetScript : MonoBehaviour
{
    public Collider2D col;
    public GameObject Target { get; private set; }
    PatternController patternController;
    [HideInInspector]
    public bool isPatternActivated = false;

    [SerializeField]
    Transform[] voids;

    int voidsIndex = 0;

    //void Start()
    //{
    //    //isPatternActivated = GameObject.Find("Pattern Controller").GetComponent<PatternController>().corruptionActivated;
    //    voidsIndex = voids.Length;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (voidsIndex == 0)
    //    {
    //        Debug.Log("WIN");
    //        StartCoroutine(Wait());
    //    }
    //}

    ////funcio per cambiar el tag
    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    Debug.Log("Trigger");
    //    if(col.gameObject.tag == "Target")//only delete Targets
    //    {
    //        Debug.Log("ENTER");
    //        Target = col.gameObject;
    //    }
    //}


    //public void ClearTarget()
    //{
    //    Debug.Log("Clear");
    //    Target = null;
    //    voidsIndex--;
    //}

    //IEnumerator Wait()
    //{
    //    yield return new WaitForSeconds(1);
    //    SceneManager.LoadScene("MainMenu");

    //}
    ////una vegada cambiat el tag y fet el pattern
}
