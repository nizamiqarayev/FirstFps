using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUi : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI promptText;

    [SerializeField]

    private TextMeshProUGUI health;

    [SerializeField]

    private TextMeshProUGUI deathPrompt;

    void Start()
    {

    }

    // Update is called once per frame
    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }
    public void UpdateHealth(int value)
    {
        if (value > 0)
        {
            health.text = $"{value}";

        }
        else
        {

            health.text = "";

        }

    }

    public void Death()
    {
        deathPrompt.text = "You Have Died. Press INTERACT to continue";
        Time.timeScale = 0;
    }
}
