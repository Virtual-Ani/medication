using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EndingManager : MonoBehaviour
{
    //public GameObject startPanel; //시작 패널
    public GameObject textPanel; //자막 패널
    public Text mainText; //자막 text
    private string uiStr; // 자막에 들어갈 내용

    //public Button startBtn; //startPanel_startBtn
    private bool start = false;
    private int textInt = 0; //상황설명시 자막의 기준이 되는 변수

    public GameObject helper; //도우미 캐릭
    public GameObject helperPos; //도우미 캐릭 생성장소
    void Start()
    {
        //Invoke("ActivateObject", delayInSeconds);
        //textPanel.SetActive(false);
        StartCoroutine(StartEndingDialogue()); // 대화 시작 코루틴 호출
        Instantiate(helper, helperPos.transform.position, helperPos.transform.rotation);
    }


    IEnumerator StartEndingDialogue()
    {
        while (textInt < 5) // 설명 텍스트가 더 이상 없을 때까지 반복
        {
            setExplainUI();
            yield return new WaitForSeconds(5f); // 5초 대기
            textInt++; // 다음 텍스트로 넘어감
        }
        EndDialogue();

    }

    public void setExplainUI()
    {

        if (textInt == 0)
        {
            uiStr = "친구 덕분에 세균으로 부터 살아남을 수 있었어! 고마워!";
            setText(mainText, uiStr);
        }

        if (textInt == 1)
        {
            uiStr = "약을 먹으니깐 우리 몸을 지킬 수 있는 무기가 나타났지?";
            setText(mainText, uiStr);
        }

        if (textInt == 2)
        {
            uiStr = "앞으로도 약을 먹으면 우리 친구를 지킬 수 있는 힘이 생길거야.";
            setText(mainText, uiStr);
        }

        if (textInt == 3)
        {
            uiStr = "앞에 보이는 약과 병원 도구들을 직접 만져봐! 무서운게 아니야!";
            setText(mainText, uiStr);
        }

        if (textInt == 4)
        {
            uiStr = "앞으로도 우리 친구가 약도 잘먹고 병원도 잘 다니기를 바래!";
            setText(mainText, uiStr);
        }
    }

    void EndDialogue()
    {
        textPanel.SetActive(false); // 텍스트 패널 숨기기     
    }

    // Text의 내용을 변경
    private void setText(Text text, string str)
    {
        text.text = str;
    }
}
