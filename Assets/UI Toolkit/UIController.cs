using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    private Button buttonStart;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement; // Search a root element of window
        buttonStart = root.Q<Button>("start-button"); // Get a button on UXML document

        buttonStart.clicked += StartButtonPressed; // Add a func in button
    }

    void StartButtonPressed()
    {
        SceneManager.LoadScene("Level_1"); // Loading scene of game
    }

}
