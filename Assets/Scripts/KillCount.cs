using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCount : MonoBehaviour
{
    private int killcount;
    public TMP_Text killCountTxt; //�������μ� text

    private void UpdateUI()
    {
        killCountTxt.text = $"Kill : \n{killcount}";
    }
    public void OnKill()
    {
        killcount++;
        UpdateUI();
    }
}
