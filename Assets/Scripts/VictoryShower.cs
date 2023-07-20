using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryShower : MonoBehaviour
{
    public GameObject victoryPanel;
    public TMP_Text victoryText;
    private Dictionary<Color, string> colorsToString = new Dictionary<Color, string>() { 
        {Color.red, "Красный"},
        {Color.blue, "Синий"},
        {Color.green, "Зелёный"},
        {Color.magenta, "Пурпурный"},
        {Color.white, "Белый"},
        {Color.cyan, "Голубой"},
        {Color.black, "Чёрный"},
        {Color.clear, "Пустой"}
    };

    public void ShowVictoryScreen(Color playerColor, int coinNumber)
    {
        victoryPanel.SetActive(true);
        victoryText.text = $"{colorsToString[playerColor]} победил! Он собрал {coinNumber} монет";
    }
}
