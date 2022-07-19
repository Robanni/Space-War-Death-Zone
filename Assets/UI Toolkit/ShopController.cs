using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShopController : MonoBehaviour
{
    private Button btnShopDamage;
    private int levelUp = 1;
    

    private Label hpLvl;
    // Start is called before the first frame update
    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        btnShopDamage = root.Q<Button>("shop-btn-damage");
        hpLvl = root.Q<Label>("hp-number");
        

        btnShopDamage.clicked += () =>
        {
            if(levelUp != 100)
            {
                levelUp += 1;
                hpLvl.text = "LVL " + levelUp.ToString();
            }
        };
    }
}
