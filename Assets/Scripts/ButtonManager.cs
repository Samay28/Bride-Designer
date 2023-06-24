using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
<<<<<<< HEAD
    public Color selectedColor; 
    public Color defaultColor; 

    private Button selectedButton; 

    public Button[] exceptions;

    private void Start()
    {
        
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {

            if (ArrayContainsButton(exceptions, button))
                continue;

=======
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
>>>>>>> 7fce7328804ead48413f3c0e61da45b02b15142d
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    private void OnButtonClick(Button button)
    {
<<<<<<< HEAD
        if (selectedButton != null)
        {
            
            if (!ArrayContainsButton(exceptions, selectedButton))
                selectedButton.image.color = defaultColor;
        }

        
        selectedButton = button;
        selectedButton.image.color = selectedColor;
    }

    private bool ArrayContainsButton(Button[] buttonArray, Button targetButton)
    {
        // Check if the target button is present in the button array
        for (int i = 0; i < buttonArray.Length; i++)
        {
            if (buttonArray[i] == targetButton)
                return true;
        }
        return false;
    }
=======
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
>>>>>>> 7fce7328804ead48413f3c0e61da45b02b15142d
}
