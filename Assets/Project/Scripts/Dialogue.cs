using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject hud;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private KeyCode next;

    private float typingTime = 0.05f;

    private bool didDialogueStart;
    private bool startDialogue;
    private int lineIndex;

    // Start is called before the first frame update
    void Start()
    {
        startDialogue = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (startDialogue && Input.GetKeyUp(next))
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
        
    }
    
    private void StarDialogue()
    {
       
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
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
}
