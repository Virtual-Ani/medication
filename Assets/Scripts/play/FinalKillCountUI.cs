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

    public GameObject textPanel; //자막 패널
    public Text mainText; //자막 text
    private string uiStr; // 자막에 들어갈 내용
    private int explainInt = 0; //상황설명시 자막의 기준이 되는 변수


    private void Start()
    {
        // 타이머 스크립트의 타이머 종료 이벤트에 함수 연결
        //timerScript.OnTimerEnd += DisplayFinalKillCount;
        DisplayFinalKillCount();

        StartCoroutine(EndingDialogue()); // 대화 시작 코루틴 호출


    }

    private void DisplayFinalKillCount()
    {
        // 킬 카운트 스크립트의 killcount 변수 값을 가져와서 UI 텍스트에 표시
        finalKillCountText.text = $"Final Kill Count: \n{KillCount.killcount}";
    }


    IEnumerator EndingDialogue()
    {

        textPanel.SetActive(true);


        while (explainInt < 4) // 설명 텍스트가 더 이상 없을 때까지 반복
        {
            setExplainUI();
            yield return new WaitForSeconds(4f); // 4초 대기
            explainInt++; // 다음 텍스트로 넘어감
        }

    }

    public void setExplainUI()
    {

        if (explainInt == 0)
        {
            uiStr = "고마워 세균들을 모두 물리쳤어!";
            setText(mainText, uiStr);
        }

        if (explainInt == 1)
        {
            uiStr = "친구가 약을 먹어주고 용사가 되어준 덕분에 할 수 있었어";
            setText(mainText, uiStr);
        }

        if (explainInt == 2)
        {
            uiStr = "이처럼 약을 먹으면 건강하고, 튼튼한 사람이 될 수 있다는 걸 잊지마!";
            setText(mainText, uiStr);
        }

        if (explainInt == 3)
        {
            uiStr = "그럼 앞으로도 약 잘 먹기다!\n우리 모두 건강한 용사가 되자! 안녕~!";
            setText(mainText, uiStr);
        }
    }


    // Text의 내용을 변경
    private void setText(Text text, string str)
    {
        text.text = str;
    }
}
