using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OptionsController : MonoBehaviour
{
    private Button backOptions;

    private VisualElement mainWin;
    private VisualElement optionsWin;
    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        backOptions = root.Q<Button>("back-options");

        mainWin = root.Q<VisualElement>("MainWin");
        optionsWin = root.Q<VisualElement>("OptionsWin");

        backOptions.clicked += () =>
        {
            optionsWin.AddToClassList("hide");
            mainWin.RemoveFromClassList("hide");
        };
    }

    
}
