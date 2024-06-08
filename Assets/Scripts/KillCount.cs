using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCount : MonoBehaviour
{
    public static int killcount;
    public TMP_Text killCountTxt; //몬스터죽인수 text
    

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
