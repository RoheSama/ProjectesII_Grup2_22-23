using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawScript : MonoBehaviour
{
    /*
    public MouseClick mouseCheck;
    // Variables per dibuixar
    public GameObject brush;
    LineRenderer currentLineRenderer;
    Vector2 lastPos;

    private void Update()
    {
        Draw();
    }
    private void Draw()
    {
        
            // Si el Left-click està sent apretat crida al Create Brush i reseteja la posició perquè pugui dibuixar
        if (Input.GetKeyDown(KeyCode.Mouse0))
             {
                CreateBrush();
             }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos != lastPos)
            {
                AddAPoint(mousePos);
                lastPos = mousePos;
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            // Quan el Left-click no està sent apretat deixa de dibuixar
            currentLineRenderer = null;
            // Quan el Left-click no està sent apretat destrueix tots els GameObjects que tinguin el Tag Draw (Les línies)
            Destroy(GameObject.FindWithTag("Draw"));
            //Tornar tots els pins a l'estat original quan el Left-click no està sent apretat
            pin_red_1.SetActive(true);
            pin_red_2.SetActive(true);
            pin_red_3.SetActive(true);
            pin_red_4.SetActive(true);
            pin_red_5.SetActive(true);
            pin_red_6.SetActive(true);
            pin_red_7.SetActive(true);
            pin_red_8.SetActive(true);
            pin_red_9.SetActive(true);
            pin_collider_1.SetActive(true);
            pin_collider_2.SetActive(true);
            pin_collider_3.SetActive(true);
            pin_collider_4.SetActive(true);
            pin_collider_5.SetActive(true);
            pin_collider_6.SetActive(true);
            pin_collider_7.SetActive(true);
            pin_collider_8.SetActive(true);
            pin_collider_9.SetActive(true);
            pin_red_activated_1.SetActive(false);
            pin_red_activated_2.SetActive(false);
            pin_red_activated_3.SetActive(false);
            pin_red_activated_4.SetActive(false);
            pin_red_activated_5.SetActive(false);
            pin_red_activated_6.SetActive(false);
            pin_red_activated_7.SetActive(false);
            pin_red_activated_8.SetActive(false);
            pin_red_activated_9.SetActive(false);
        }
    }

    void CreateBrush()
    {
        GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        currentLineRenderer.tag = "Draw";


        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }

    void AddAPoint(Vector2 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }
    */
}

