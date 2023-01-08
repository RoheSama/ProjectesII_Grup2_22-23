using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    //Detection
    private bool isPlayerInRange;
    [SerializeField] private GameObject interactAlert;

    //Dialogue
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject hud;
    [SerializeField] private GameObject dialogueSystem;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private KeyCode next;
    [SerializeField] private Image sprite1;
    [SerializeField] private Image sprite2;
    [SerializeField, TextArea(4, 6)] private string[] dialogueImage;
    [SerializeField, TextArea(4, 6)] private string[] dialogueName;
    [SerializeField] private TMP_Text character1;
    [SerializeField] private TMP_Text character2;
    [SerializeField] private TMP_Text character3;

    private float typingTime = 0.05f;

    private bool didDialogueStart;
    private bool startDialogue;
    private int lineIndex;


    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyUp(next))
        {
            if (!didDialogueStart)
            {
                StarDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }

            
        }

        ImageManager();
        NamesManager(); 
    }
    
    private void ImageManager()
    {
        if (dialogueImage[lineIndex] == "1")
        {
            sprite1.enabled = true;
            sprite2.enabled = false;
        }
        else if (dialogueImage[lineIndex] == "2")
        {
            sprite2.enabled = true;
            sprite1.enabled = false;
        }
        else if (dialogueImage[lineIndex] == "3")
        {
            sprite2.enabled = false;
            sprite1.enabled = false;
        }
    }

    private void NamesManager()
    {
        if (dialogueImage[lineIndex] == "1")
        {
            character1.enabled = true;
            character2.enabled = false;
            character3.enabled = false;
        }
        else if (dialogueImage[lineIndex] == "2")
        {
            character2.enabled = true;
            character1.enabled = false;
            character3.enabled = false;
        }
        else if (dialogueImage[lineIndex] == "3")
        {
            character2.enabled = false;
            character1.enabled = false;
            character3.enabled = true;
        }
    }
    private void StarDialogue()
    {
        didDialogueStart = true;
        dialogueSystem.SetActive(true); 
        hud.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if(lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            hud.SetActive(true);
            startDialogue = false;
            dialogueSystem.SetActive(false);
            Time.timeScale = 1f;
        }
        
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach(char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            interactAlert.SetActive(true);
            Debug.Log("dialogue");
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            interactAlert.SetActive(false);
            Debug.Log("nondialogue");
        }
    }
}
