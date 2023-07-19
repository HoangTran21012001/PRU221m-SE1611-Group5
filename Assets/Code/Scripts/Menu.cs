using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    Text currencyUI;
    private bool isMenuOpen = true;

    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
    }

    private void OnGUI()
    {
        currencyUI.text = LevelManager.main.currency.ToString();
    }

    public void SetSelected()
    {

    }
}
