using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RadioButtons : MonoBehaviour
{
    public GameObject[] buttons;
    public string[] selectedInfo;
    private int infoState = 0;
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
                selectedInfo[infoState] = button.transform.parent.GetComponent<GetQuestionRadio>().question + ": " + selectedButton.name;
            }
            else
            {
                button.GetComponent<Image>().color = deselectedColor;
            }
            selectedButton.GetComponent<Image>().color = selectedColor;
        }
    }

    public void FlushButtons(GameObject buttonParent)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i] = buttonParent.transform.GetChild(i).gameObject;
        }
        infoState++;
    }
}
