using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    private Button buttonStart;
    private Button buttonShop;
    private Button buttonBack;
    private Button buttonExitGame;
    private Button buttonOptions;

    private Label coinLabel;


    // Start is called before the first frame update
    void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement; // Search a root element of window


        // Get refs of Windows
        var mainWin = root.Q<VisualElement>("MainWin");
        var shopWin = root.Q<VisualElement>("ShopWin");
        var optionsWin = root.Q<VisualElement>("OptionsWin");

        // // Get refs of buttons
        buttonStart = root.Q<Button>("start-button"); // Get a button on UXML document
        buttonShop = root.Q<Button>("shop-button");
        buttonBack = root.Q<Button>("back-button");
        buttonExitGame = root.Q<Button>("exit-button");
        buttonOptions = root.Q<Button>("options-button");

        coinLabel = root.Q<Label>("coin-bar");


        // Add events on buttons
        buttonStart.clicked += StartButtonPressed;

        buttonShop.clicked += () =>
        {

            mainWin.AddToClassList("hide");
            shopWin.RemoveFromClassList("hide");
        };

        buttonBack.clicked += () =>
        {
            mainWin.RemoveFromClassList("hide");
            shopWin.AddToClassList("hide");
        };

        buttonOptions.clicked += () =>
        {
            mainWin.AddToClassList("hide");
            optionsWin.RemoveFromClassList("hide");
        };

        buttonExitGame.clicked += ExitButtonPressed;

    }

    private void StartButtonPressed()
    {
        SceneManager.LoadScene("Level_1"); // Loading scene of game
    }

    private void ExitButtonPressed()
    {
        Application.Quit();
    }

}
