using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choisen : MonoBehaviour
{

    public Transform playerParent;

    private void Start()
    {
        // Get the selected character index from PlayerPrefs (default to 0 if not set)
        int selectedCharacter = PlayerPrefs.GetInt("warrior", 0);

        // Check if the selected character is valid
        if (selectedCharacter >= 0 && selectedCharacter < playerParent.childCount)
        {
            // Deactivate all child objects (if needed)
            for (int i = 0; i < playerParent.childCount; i++)
            {
                playerParent.GetChild(i).gameObject.SetActive(false);
            }

            // Activate the selected character
            playerParent.GetChild(selectedCharacter).gameObject.SetActive(true);

            // Assign the virtual camera to follow the character
            
        }
        else
        {
            Debug.LogError("Invalid selected character index: " + selectedCharacter);
        }
    }

}
