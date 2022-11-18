using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class PhoneDrawController : MonoBehaviour
{

    public bool isDrawing = false;
    public MouseCheck mouseCheck;
    public PatternController patternController;
    public ParticleSystem particles;
    public LineRenderer line;
    Vector2 lastPos;
    public UILineRenderer rend;

    void Update()
    {
        Draw();
    }
    void Draw()
    {
        // Quan estàs dibuixant
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (!isDrawing)
            {
                StartParticlesAndLine();
            }
            isDrawing = true;
            UpdateParticles();
            UpdateLineRenderer();
        }
        // Quan no estàs dibuixant
        else
        {
            if (isDrawing)
            {
                ClearParticlesandLine();
            }
            isDrawing = false;
        }
    }

    void StartParticlesAndLine()
    {
        line.positionCount = 2;
        line.SetPosition(0, mouseCheck.mousePosWorldSpace);
        line.SetPosition(1, mouseCheck.mousePosWorldSpace);

        particles.transform.position = mouseCheck.mousePosWorldSpace;
        particles.Play();
    }

    void UpdateParticles()
    {
        particles.transform.position = mouseCheck.mousePosWorldSpace;
    }

    void UpdateLineRenderer()
    {
        Vector2 mousePos = mouseCheck.mousePosWorldSpace;
        if (mousePos != lastPos)
        {
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, (Vector3)mouseCheck.mousePosWorldSpace + Vector3.back * 7.0f);
            lastPos = mousePos;
        }
    }

    // Borrar el dibuix al deixar de dibuixar
    void ClearParticlesandLine()
    {
        line.positionCount = 0;
        particles.Stop();
    }
}