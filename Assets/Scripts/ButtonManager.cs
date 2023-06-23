using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Color selectedColor; // The color for the selected button
    public Color defaultColor; // The default color for buttons

    private Button selectedButton; // The currently selected button

    private void Update()
    {
        // Get all the buttons in your scene or hierarchy
        Button[] buttons = FindObjectsOfType<Button>();

        // Attach the OnButtonClick method to each button's click event
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    private void OnButtonClick(Button button)
    {
        // Check if a button was already selected
        if (selectedButton != null)
        {
            // Reset the color of the previously selected button
            selectedButton.image.color = defaultColor;
        }

        // Set the new button as the selected button
        selectedButton = button;
        // Change the color of the selected button
        selectedButton.image.color = selectedColor;
    }
}
