using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image bar;
    //public Image limitLine;
    private float limitFill = 0.5f; // Limit of the fillBar before the camera move

    private float increaseValue = 0.3f; // Initial speed
    private float maxIncreaseValue = 0.9f; // Max Speed value of the fillBar
    private float increaseValueAmount = 0.01f; // Add difficulty
    public float fillAmountOnPress;

    private float timeLeft = 3; // Increase difficulty every TOT seconds
    private float timeBeforeBadDialogue = 10;
    //public bool badDialogue;

    private float cameraUpSpeed = 0.4f;
    private float cameraDownSpeed = 0.8f;

    public Transform dialogue;

    public Text stressText;



    void Start()
    {
        stressText.text = "" + increaseValue.ToString("0.0");
        Vector3 mainCamera = Camera.main.transform.position;

        //limitLine.fillAmount = limitFill / 1;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = 3;
            if (increaseValue <= maxIncreaseValue)
            {
                increaseValue += increaseValueAmount;
            }
            stressText.text = "" + increaseValue.ToString("0.0");
        }

        bar.fillAmount -= increaseValue * Time.deltaTime;

        /*if (!badDialogue)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                timeLeft = 3;
                if (increaseValue <= maxIncreaseValue)
                {
                    increaseValue += increaseValueAmount;
                }
                stressText.text = "" + increaseValue.ToString("0.0");
            }

            bar.fillAmount -= increaseValue * Time.deltaTime;
        }*/

        if (bar.fillAmount < limitFill)
        {
            if(Camera.main.transform.position.y >= -2f)
            {
                bar.color = Color.red;
                Camera.main.transform.position = new Vector3(0, Camera.main.transform.position.y - cameraUpSpeed * Time.deltaTime, -10);
            }

            if(dialogue.localScale.y >= 0.3f)
            {
                dialogue.localScale = new Vector2(dialogue.localScale.x - 0.2f * Time.deltaTime, dialogue.localScale.y - 0.2f * Time.deltaTime);
            }

            timeBeforeBadDialogue -= Time.deltaTime;
            if (timeBeforeBadDialogue < 0)
            {
                timeBeforeBadDialogue = 10;
                //badDialogue = true;
                Debug.Log("Bad Dialogue"); // Blocca la barra, i comandi, porta su l'inquadratura e inizia il dialogo
            }
        }
        else if (bar.fillAmount > limitFill)
        {
            if(Camera.main.transform.position.y <= 0f)
            {
                bar.color = Color.green;
                Camera.main.transform.position = new Vector3(0, Camera.main.transform.position.y + cameraDownSpeed * Time.deltaTime, -10);
            }

            if (dialogue.localScale.y <= 1)
            {
                dialogue.localScale = new Vector2(dialogue.localScale.x + 0.2f * Time.deltaTime, dialogue.localScale.y + 0.2f * Time.deltaTime);
            }

            timeBeforeBadDialogue = 10;
        }

        /*if (badDialogue)
        {
            if (Camera.main.transform.position.y <= 0f)
                Camera.main.transform.position = new Vector3(0, Camera.main.transform.position.y + 1f * Time.deltaTime, -10);
        }*/
    }
}
