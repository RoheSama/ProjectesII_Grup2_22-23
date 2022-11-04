using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneDrawController : MonoBehaviour
{

    public bool isDrawing = false;
    public MouseCheck mouseCheck;
    public PatternController patternController;
    public ParticleSystem particles;
    public LineRenderer line;
    Vector2 lastPos;

    private void Update()
    {
        Draw();
    }
    void Draw()
    {
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
            line.SetPosition(line.positionCount - 1, mouseCheck.mousePosWorldSpace);
            lastPos = mousePos;
        }
    }

    void ClearParticlesandLine()
    {
        line.positionCount = 0;
        particles.Stop();
    }
}