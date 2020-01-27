using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Girl girl;
    public Transform scaleBar;

    public Image bar;
    private float limitFill = 0.5f; // Limit of the fillBar before the camera move
    private float increaseValue = 0.3f; // Initial speed

    public float fillAmountOnPress;

    private float timeLeft; // Increase difficulty every TOT seconds
    private float timeBeforeBadDialogue = 10;

    private float cameraUpSpeed = 0.4f;
    private float cameraDownSpeed = 0.8f;

    public Text stressText;

    private bool isRedZone;

    void Start()
    {
        timeLeft = girl.timeIncreaseDifficulty;
        stressText.text = "" + increaseValue.ToString("0.0");
        Vector3 mainCamera = Camera.main.transform.position;
    }

    void Update()
    {
        scaleBar.localScale = new Vector2(bar.fillAmount / limitFill, 1);

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = girl.timeIncreaseDifficulty;
            if (increaseValue <= girl.maxIncreaseValue)
            {
                increaseValue += girl.increaseValueAmount;

                //animazione!!
                /*if(bar.fillAmount < limitFill)
                {
                    GetComponent<DialogueManager>().RandomDialog();
                }*/
            }
            stressText.text = "" + increaseValue.ToString("0.0");
        }

        bar.fillAmount -= increaseValue * Time.deltaTime;

        if (bar.fillAmount < limitFill)
        {
            if (!isRedZone)
            {
                isRedZone = true;
                GetComponent<DialogueManager>().RandomDialog();
            }

            if (Camera.main.transform.position.y >= -2f)
            {
                bar.color = Color.red;
                Camera.main.transform.position = new Vector3(0, Camera.main.transform.position.y - cameraUpSpeed * Time.deltaTime, -10);
            }

            timeBeforeBadDialogue -= Time.deltaTime;
            if (timeBeforeBadDialogue < 0)
            {
                timeBeforeBadDialogue = 10;
                Debug.Log("Bad Dialogue"); // Blocca la barra, i comandi, porta su l'inquadratura e inizia il dialogo
            }
        }
        else if (bar.fillAmount > limitFill)
        {
            if (isRedZone)
            {
                isRedZone = false;
                GetComponent<DialogueManager>().RandomDialog();
            }

            if (Camera.main.transform.position.y <= 0f)
            {
                bar.color = Color.green;
                Camera.main.transform.position = new Vector3(0, Camera.main.transform.position.y + cameraDownSpeed * Time.deltaTime, -10);
            }

            timeBeforeBadDialogue = 10;
        }
    }
}
