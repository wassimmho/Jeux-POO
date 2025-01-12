using UnityEngine;
using TMPro;  // For TextMeshPro
using UnityEngine.UI;  // For Unity UI Text

public class Textsc : MonoBehaviour
{
    public string fullText = "Hello, world!"; // Full text you want to display
    private string currentText = ""; // Currently displayed text
    public float typingSpeed = 0.1f; // Speed of typing
    private float timer = 0f; // Timer to track typing speed
    private int index = 0; // Index of the character currently being typed

    private TextMeshProUGUI tmpText;  // For TextMeshPro
    private Text uiText;              // For Unity UI Text

    void Start()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
        uiText = GetComponent<Text>();

        // Make sure you have either TextMeshPro or Unity UI Text
        if (tmpText != null)
        {
            tmpText.text = "";
        }
        else if (uiText != null)
        {
            uiText.text = "";
        }
        else
        {
            Debug.LogError("No Text component found!");
        }
    }

    void Update()
    {
        // If the typing is not finished yet
        if (index < fullText.Length)
        {
            // Increment the timer by the time passed in the frame
            timer += Time.deltaTime;

            // When the timer exceeds the typing speed, display the next character
            if (timer >= typingSpeed)
            {
                // Reset the timer
                timer = 0f;

                // Add the next character to the displayed text
                currentText += fullText[index];

                // Set the text component to the current text
                if (tmpText != null)
                {
                    tmpText.text = currentText;
                }
                else if (uiText != null)
                {
                    uiText.text = currentText;
                }

                // Move to the next character
                index++;
            }
        }
    }
}
