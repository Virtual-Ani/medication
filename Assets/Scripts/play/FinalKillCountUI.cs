using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalKillCountUI : MonoBehaviour
{
    //public KillCount killCountScript; // 킬 카운트 스크립트 참조
    //public Timer timerScript; // 타이머 스크립트 참조
    public TMP_Text finalKillCountText; // 최종 킬 카운트를 표시할 UI 텍스트

    private void Start()
    {
        // 타이머 스크립트의 타이머 종료 이벤트에 함수 연결
        //timerScript.OnTimerEnd += DisplayFinalKillCount;
        DisplayFinalKillCount();
    }

    private void DisplayFinalKillCount()
    {
        // 킬 카운트 스크립트의 killcount 변수 값을 가져와서 UI 텍스트에 표시
        finalKillCountText.text = $"Final Kill Count: \n{KillCount.killcount}";
    }
}
