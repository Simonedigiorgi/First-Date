using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public string[] dialogue;

    //public string normalDialogue;

    public Text dialogueText;

    private float timeLeft = 3;

    public Animator dialogueAnim;
    public Animator maleDialogueAnim;

    private bool isRandomized = true;
    public Text maleText;
    public string[] maleDialogues;

    private void Update()
    {
        if (isRandomized)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                timeLeft = 3;
                RandomDialog();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            MaleDialogue();
        }
    }

    public void RandomDialog()
    {
        dialogueText.text = dialogue[Random.Range(0, dialogue.Length)];
        dialogueAnim.Play("Right_Popup");
    }

    public void MaleDialogue()
    {
        if (!maleText.enabled)
        {
            maleDialogueAnim.Play("Male_Popup");
            maleText.text = maleDialogues[Random.Range(0, maleDialogues.Length)];
        }
    }
}
