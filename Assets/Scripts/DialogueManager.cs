using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public string[] dialogue;

    public string normalDialogue;

    public Text dialogueText;

    private float timeLeft = 3;

    public Animator dialogueAnim;

    private bool isRandomized = true;

    private void Update()
    {
        if (isRandomized)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                timeLeft = 3;
                RandomDialog(true);
            }
        }
    }

    public void RandomDialog(/*bool isBadDialogue,*/bool isAnimation)
    {
        dialogueText.text = dialogue[Random.Range(0, dialogue.Length)];
        /*if (isBadDialogue)
        {
            dialogueText.text = dialogue[Random.Range(0, dialogue.Length)];
        }
        else
            dialogueText.text = normalDialogue;*/

        if (isAnimation)
        {
            dialogueAnim.Play("Right_Popup");
        }
    }
}
