using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryShower : MonoBehaviour
{
    public GameObject victoryPanel;
    public TMP_Text victoryText;
    private Dictionary<Color, string> colorsToString = new Dictionary<Color, string>() { 
        {Color.red, "�������"},
        {Color.blue, "�����"},
        {Color.green, "������"},
        {Color.magenta, "���������"},
        {Color.white, "�����"},
        {Color.cyan, "�������"},
        {Color.black, "׸����"},
        {Color.clear, "������"}
    };

    public void ShowVictoryScreen(Color playerColor, int coinNumber)
    {
        victoryPanel.SetActive(true);
        victoryText.text = $"{colorsToString[playerColor]} �������! �� ������ {coinNumber} �����";
    }
}
