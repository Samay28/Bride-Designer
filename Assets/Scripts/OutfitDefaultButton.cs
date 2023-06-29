using UnityEngine;
using UnityEngine.UI;

public class OutfitDefaultButton : MonoBehaviour
{
    public Color selectedColor;
    private ColorBlock defaultColors;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        defaultColors = button.colors;
        button.colors = SetSelectedColor(button.colors);
    }

    private void OnEnable()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        ResetButtonColors();
        button.colors = SetSelectedColor(button.colors);
    }

    private ColorBlock SetSelectedColor(ColorBlock colorBlock)
    {
        colorBlock.normalColor = selectedColor;
        return colorBlock;
    }

    private void ResetButtonColors()
    {
        button.colors = defaultColors;
    }
}
