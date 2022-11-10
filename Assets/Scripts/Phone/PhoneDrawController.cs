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

    //Momentani, això es borrarà en un futur, només pel protoip
    public Vector2 mousePosWorldSpace;
    public Collider2D touchedObjectCollider;
    public Collider2D pin0;
    public Collider2D pin1;
    public Collider2D pin2;
    public Collider2D pin3;
    public Collider2D pin4;
    public Collider2D pin5;
    public Collider2D pin6;
    public Collider2D pin7;
    public Collider2D pin8;
    bool canDraw = false;


    public AudioClip drawSound;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    void Update()
    {
       // if(canDraw)
       //{
            Draw();
      //  }
        
        //MouseCoords();

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

            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(drawSound, 1f);
            }
        }
        else
        {
            if (isDrawing)
            {
                ClearParticlesandLine();
            }
            isDrawing = false;
            audioSource.Stop();
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

    //Momentani, això es borrarà en un futur, només pel protoip
    void MouseCoords()
    {
        Vector2 mousePosScreenSpace = Input.mousePosition;
        mousePosWorldSpace = Camera.main.ScreenToWorldPoint(mousePosScreenSpace);
        if (touchedObjectCollider == Physics2D.OverlapPoint(mousePosWorldSpace) || pin0 == Physics2D.OverlapPoint(mousePosWorldSpace) || pin1 == Physics2D.OverlapPoint(mousePosWorldSpace)
            || pin2 == Physics2D.OverlapPoint(mousePosWorldSpace) || pin3 == Physics2D.OverlapPoint(mousePosWorldSpace) || pin4 == Physics2D.OverlapPoint(mousePosWorldSpace)
            || pin5 == Physics2D.OverlapPoint(mousePosWorldSpace) || pin6 == Physics2D.OverlapPoint(mousePosWorldSpace) || pin7 == Physics2D.OverlapPoint(mousePosWorldSpace)
            || pin8 == Physics2D.OverlapPoint(mousePosWorldSpace))
        {
            canDraw = true;
        }
        else canDraw = false;
    }
}