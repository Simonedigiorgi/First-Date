using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public string[] dialogue;
    public Text dialogueText;

    private float timeLeft = 3;

    public Animator dialogueAnim;

    private bool isRandomized;

    private void Update()
    {
        if (isRandomized)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                timeLeft = 3;
            }
        }
    }

    public void RandomDialog()
    {
        isRandomized = true;
        dialogueText.text = dialogue[Random.Range(0, dialogue.Length)];
        dialogueAnim.Play("Right_Popup");


    }
}
