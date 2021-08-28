using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MultiObjectButton : MonoBehaviour
{
    [SerializeField] public List<ButtonObject> m_buttonObjects;

    [SerializeField, HideInInspector] public Button button;

    private Color noPowerupColour = new Color(0.1f, 0.1f, 0.1f, 1);

    public bool isInitialised = false;

    private void OnValidate()
    {
        button = GetComponent<Button>();
        if (m_buttonObjects != null)
        {
            foreach (var obj in m_buttonObjects)
            {
                obj.button = button;
                obj.noPowerupColour = noPowerupColour;
            }
        }
    }

    private void Awake()
    {
        isInitialised = false;
    }

    public void SetSelected(bool isSelected)
    {
        foreach(var obj in m_buttonObjects)
        {
            obj.SetColour(isSelected);
        }
    }

    public void InitPowerups()
    {
        if (isInitialised)
            return;

    }

    public void DisableExtras()
    {
    }

    public void EnableExtras()
    {
    }

}

[System.Serializable]
public class ButtonObject
{
    public GameObject gameObject;

    public bool overrideColour = true;

    public Button button;

    [HideInInspector]public Color noPowerupColour;

    public enum Type
    {
        IMAGE,
        TEXT,
    }

    public Type type;

    public ButtonObject()
    {
        gameObject      = null;
        button          = null;
        type            = Type.TEXT;
        overrideColour  = true;
    }

    public ButtonObject(GameObject _gameObject, Button _button, Type _type, bool _overrideColour = true)
    {
        gameObject      = _gameObject;
        button          = _button;
        type            = _type;
        overrideColour  = _overrideColour;
    }

    public void SetColour(bool isSelected)
    {
        switch (type)
        {
            case Type.IMAGE:
                if (isSelected)
                    gameObject.GetComponent<Image>().color = button.colors.selectedColor;
                else
                    gameObject.GetComponent<Image>().color = button.colors.normalColor;
                break;

            case Type.TEXT:

                if (isSelected)
                    gameObject.GetComponent<TextMeshProUGUI>().color = button.colors.selectedColor;
                else
                    gameObject.GetComponent<TextMeshProUGUI>().color = button.colors.normalColor;
                break;
        }


    }

    public void SetScale(bool isSelected)
    {
        if (isSelected)
            gameObject.GetComponent<Image>().color = button.colors.selectedColor;
        else
            gameObject.GetComponent<Image>().color = button.colors.normalColor;
    }

}

