using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Color selectedColor; 
    public Color defaultColor; 

    private Button selectedButton; 

    public Button[] exceptions;

    private void Update()
    {
        
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {

            if (ArrayContainsButton(exceptions, button))
                continue;

            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    private void OnButtonClick(Button button)
    {
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

        for (int i = 0; i < buttonArray.Length; i++)
        {
            if (buttonArray[i] == targetButton)
                return true;
        }
        return false;
    }
}
