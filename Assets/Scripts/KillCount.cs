using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCount : MonoBehaviour
{
    public static int killcount;
    public TMP_Text killCountTxt; //�������μ� text
    

    private void UpdateUI()
    {
        killCountTxt.text = $"Kill : {killcount}";
    }
    public void OnKill()
    {
        killcount++;
        UpdateUI();
    }
}
