using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShopController : MonoBehaviour
{
    private Button btnShopHP;
    private Button btnShopDamage;
    private Button btnShopAttackSpeed;

    private int cost = 2;
    private int coinsPlayer = 0;

    private Label hpLvl;
    private Label damageLvl;
    private Label attackSpeedLvl;

    private Label costHP;
    private Label costDamage;
    private Label costAttackSpeed;

    private Label coinBar;

    // Start is called before the first frame update
    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        coinsPlayer = PlayerPrefs.GetInt("Coins");
        
        // Get btn from root
        btnShopHP = root.Q<Button>("shop-btn-hp");
        btnShopDamage = root.Q<Button>("shop-btn-damage");
        btnShopAttackSpeed = root.Q<Button>("shop-btn-attackSpeed");

        // Get lvl label from root
        hpLvl = root.Q<Label>("hp-number");
        damageLvl = root.Q<Label>("damage-number");
        attackSpeedLvl = root.Q<Label>("attackSpeed-number");

        // Get label cost from root
        costHP = root.Q<Label>("cost-hp");
        costDamage = root.Q<Label>("cost-damage");
        costAttackSpeed = root.Q<Label>("cost-attackSpeed");

        // Get coinBar from root
        coinBar = root.Q<Label>("coin-bar");

        hpLvl.text = "LVL " + PlayerPrefs.GetInt("HealthLevel").ToString();
        damageLvl.text = "LVL " + PlayerPrefs.GetInt("DamageLevel").ToString();
        attackSpeedLvl.text = "LVL " + PlayerPrefs.GetInt("AttackSpeedLevel").ToString();

        costHP.text = Mathf.Pow(cost, PlayerPrefs.GetInt("HealthLevel")).ToString();
        costDamage.text = Mathf.Pow(cost, PlayerPrefs.GetInt("DamageLevel")).ToString();
        costAttackSpeed.text = Mathf.Pow(cost, PlayerPrefs.GetInt("AttackSpeedLevel")).ToString();

        coinBar.text = PlayerPrefs.GetInt("Coins").ToString();

        ShopButton(btnShopHP);
        ShopButton(btnShopDamage);
        ShopButton(btnShopAttackSpeed);
    }

    private void ShopButton (Button btn)
    {
        switch (btn.name)
        {
            case "shop-btn-hp":
                btn.clicked += () =>
                {
                    if (coinsPlayer >= Mathf.Pow(cost, PlayerPrefs.GetInt("HealthLevel")))
                    {
                        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - (int)Mathf.Pow(cost, PlayerPrefs.GetInt("HealthLevel")));
                        hpLvl.text = "LVL " + PlayerPrefs.GetInt("HealthLevel").ToString();
                        PlayerPrefs.SetInt("HealthLevel", PlayerPrefs.GetInt("HealthLevel") + 1);

                        costHP.text = Mathf.Pow(cost, PlayerPrefs.GetInt("HealthLevel")).ToString();
                        hpLvl.text = "LVL " + PlayerPrefs.GetInt("HealthLevel").ToString();
                        coinBar.text = PlayerPrefs.GetInt("Coins").ToString();
                    }
                };

                break;
            case "shop-btn-damage":
                btn.clicked += () =>
                {
                    if (coinsPlayer >= Mathf.Pow(cost, PlayerPrefs.GetInt("DamageLevel")))
                    {
                        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - (int)Mathf.Pow(cost, PlayerPrefs.GetInt("DamageLevel")));
                        damageLvl.text = "LVL " + PlayerPrefs.GetInt("DamageLevel").ToString();
                        PlayerPrefs.SetInt("DamageLevel", PlayerPrefs.GetInt("DamageLevel") + 1);

                        costDamage.text = Mathf.Pow(cost, PlayerPrefs.GetInt("DamageLevel")).ToString();
                        damageLvl.text = "LVL " + PlayerPrefs.GetInt("DamageLevel").ToString();
                        coinBar.text = PlayerPrefs.GetInt("Coins").ToString();
                    }
                };

                break;

            case "shop-btn-attackSpeed":
                btn.clicked += () =>
                {
                    if (coinsPlayer >= Mathf.Pow(cost, PlayerPrefs.GetInt("AttackSpeedLevel")))
                    {
                        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - (int)Mathf.Pow(cost, PlayerPrefs.GetInt("AttackSpeedLevel")));
                        attackSpeedLvl.text = "LVL " + PlayerPrefs.GetInt("AttackSpeedLevel").ToString();
                        PlayerPrefs.SetInt("AttackSpeedLevel", PlayerPrefs.GetInt("AttackSpeedLevel") + 1);

                        costAttackSpeed.text = Mathf.Pow(cost, PlayerPrefs.GetInt("AttackSpeedLevel")).ToString();
                        attackSpeedLvl.text = "LVL " + PlayerPrefs.GetInt("AttackSpeedLevel").ToString();
                        coinBar.text = PlayerPrefs.GetInt("Coins").ToString();
                    }
                };

                break;

            default:
                break;
            
        }
        
    }
}
