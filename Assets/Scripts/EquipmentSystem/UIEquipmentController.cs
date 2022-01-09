using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIEquipmentController : MonoBehaviour
{
    public static UIEquipmentController instance;
    public TextMeshProUGUI strengthPointText;
    public TextMeshProUGUI healthPointText;
    public TextMeshProUGUI defensePointText;
    public TextMeshProUGUI speedPointText;
    public TextMeshProUGUI moneyPointText;
    #region Singleton
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    #endregion
    private void Start()
    {
        updateMoney();
        updateUIStats();
    }
    public void updateUIStats()
    {
        Stats characterStats = CharacterController.instance.characterStats;
        strengthPointText.text = characterStats.strength.ToString();
        healthPointText.text = characterStats.healthPoint.ToString();
        defensePointText.text = characterStats.defense.ToString();
        speedPointText.text = characterStats.speed.ToString();
    }
    public void updateMoney()
    {
        Money characterMoney = CharacterController.instance.money;
        moneyPointText.text = characterMoney.amount.ToString();
    }
}
