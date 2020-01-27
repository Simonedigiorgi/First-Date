using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Image[] buttons;

    public KeyCode[] keycode;

    void Update()
    {
        // Fill Amount on press
        for (int i = 0; i < keycode.Length; i++)
        {
            if (Input.GetKeyDown(keycode[i]))
            {
                GetComponent<GameManager>().bar.fillAmount += GetComponent<GameManager>().fillAmountOnPress;
            }
        }

        // Change color on press
        for (int i = 0; i < keycode.Length; i++)
        {
            if (Input.GetKey(keycode[i]))
            {
                buttons[i].color = Color.grey;
            }
            else
                buttons[i].color = Color.white;
        }
    }
}
