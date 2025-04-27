using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public TextMeshProUGUI MoneyText;
    public int currentMoney = 0;
    
    public void addMoney(int Price)
    {
        currentMoney += Price;
        MoneyText.text = "" + currentMoney;
    }
}
