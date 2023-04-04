//using UnityEngine;
//using System.Collections;
//using UnityEngine.UI;

//public class MouseDetector : MonoBehaviour
//{
//    public GameObject descriptionBox;
//    public GameObject shadowIcon;
//    public GameObject shadow;
//    public GameObject violet;

//    private void Start()
//    {
//        violet.SetActive(true);
//    }

//    private void Update()
//    {
//        if(shadowIcon!= null && violet != null && shadow!=null)
//        {
//            if (shadowIcon.activeSelf)
//            {
//                shadow.SetActive(true);
//                violet.SetActive(false);
//            }

//            else
//            {
//                shadow.SetActive(false);
//                violet.SetActive(true);
//            }
//        }
//    }

//    void OnMouseOver()
//    {
//        if(descriptionBox.activeSelf== false)
//        {
//            Debug.Log("A");
//            descriptionBox.SetActive(true);
//        }
//    }

//    void OnMouseExit()
//    {
//        if (descriptionBox.activeSelf == true)
//        {
//            descriptionBox.SetActive(false);
//        }
//    }
//}