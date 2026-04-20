using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class RadioButtons : MonoBehaviour
{
    public GameObject[] buttons;
    public string selectedInfo = "";
    private GameObject selectedButton;
    private Color selectedColor;
    private Color deselectedColor = Color.white;

    private void Start()
    {
        //button[0] selected
        EventSystem.current.SetSelectedGameObject(buttons[0]);
        selectedButton = EventSystem.current.currentSelectedGameObject;
        selectedColor = selectedButton.GetComponent<Button>().colors.selectedColor;
        deselectedColor = selectedButton.GetComponent<Button>().colors.normalColor;
    }

    private void FixedUpdate()
    {
        foreach (GameObject button in buttons)
        {
            if (button == EventSystem.current.currentSelectedGameObject)
            {
                selectedButton = button;
                selectedInfo = button.name;
            }
            else
            {
                button.GetComponent<Image>().color = deselectedColor;
            }
            selectedButton.GetComponent<Image>().color = selectedColor;
        }
    }
}
