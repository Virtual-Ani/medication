using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class exGameManager : MonoBehaviour
{
    public GameObject textPanel; //자막 패널
    public Text mainText; //자막 text
    private string uiStr; // 자막에 들어갈 내용

    public GameObject helper; //도우미 캐릭
    private GameObject helperPos; //도우미 캐릭 생성장소

    public GameObject mon1; //몹 캐릭1
    public GameObject mon2; //몹 캐릭2
    public GameObject mon3; //몹 캐릭3
    private GameObject monPos1; //몹 생길위치
    private GameObject monPos2; //몹 생길위치
    private GameObject monPos3; //몹 생길위치

    private GameObject portalPos;//약포탈 위치
    private GameObject potionPos;//포션 위치


    public GameObject medicinePortal; //약포탈
    public GameObject potion; //포션 에셋



    private bool start = false;
    private int explainInt = 0; //상황설명시 자막의 기준이 되는 변&

    public float delayInSeconds = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(DelayedStart(5.0f));
        textPanel.SetActive(true);
        uiStr = "곧 '약먹는 용사들'이 시작됩니다..";
        setText(mainText, uiStr);
        StartCoroutine(StartExplain()); // 대화 시작 코루틴 호출
    }

    /*// Update is called once per frame
    void Update()
    {
        setExplainUI(); //ExplainUI 관리

    }*/

    private IEnumerator DelayedStart(float delay)
    {
        yield return new WaitForSeconds(delay);

        textPanel.SetActive(false);
        Debug.Log("기다렸땅");
    }

    public void startPlay()
    {
        monPos1 = GameObject.Find("MonsterSpot1");
        monPos2 = GameObject.Find("MonsterSpot2");
        monPos3 = GameObject.Find("MonsterSpot3");
        portalPos = GameObject.Find("MedicineSpot");
        helperPos = GameObject.Find("HelperSpot");
        //potionPos = GameObject.Find("MedicineSpot");


        if (portalPos != null)
        {
            Instantiate(medicinePortal, portalPos.transform.position, portalPos.transform.rotation);
        }
        else
        {
            Debug.LogError("portalPos가 설정되지 않았습니다.");
        }

        if (monPos1 != null)
        {
            Instantiate(mon1, monPos1.transform.position, monPos1.transform.rotation);
        }
        else
        {
            Debug.LogError("monPos1가 설정되지 않았습니다.");
        }

        if (monPos2 != null)
        {
            Instantiate(mon2, monPos2.transform.position, monPos2.transform.rotation);
        }
        else
        {
            Debug.LogError("monPos2가 설정되지 않았습니다.");
        }

        if (monPos3 != null)
        {
            Instantiate(mon3, monPos3.transform.position, monPos3.transform.rotation);
        }
        else
        {
            Debug.LogError("monPos3가 설정되지 않았습니다.");
        }



        Instantiate(medicinePortal, portalPos.transform.position, portalPos.transform.rotation);
        Instantiate(mon1, monPos1.transform.position, monPos1.transform.rotation);
        Instantiate(mon2, monPos2.transform.position, monPos2.transform.rotation);
        Instantiate(mon3, monPos3.transform.position, monPos3.transform.rotation);

        Instantiate(helper, helperPos.transform.position, helperPos.transform.rotation);
        start = true;
        textPanel.SetActive(true);
    }

    IEnumerator StartExplain()
    {
        //startPanel.SetActive(false);
        //start = true;
        yield return new WaitForSeconds(5f); // 5초 대기
        Debug.Log("기다렸땅");
        startPlay();


        while (explainInt < 6) // 설명 텍스트가 더 이상 없을 때까지 반복
        {
            setExplainUI();
            yield return new WaitForSeconds(2f); // 2초 대기
            explainInt++; // 다음 텍스트로 넘어감
        }
        EndDialogue();

    }

    public void setExplainUI()
    {

        if (explainInt == 0)
        {
            uiStr = "안녕! 나는 친구가 용사가 될 수 있도록 도와줄 튼튼이라고해!";
            setText(mainText, uiStr);
        }

        if (explainInt == 1)
        {
            uiStr = "몸에 나쁜 세균들이 몰려와서 우리를 괴롭히고있어! 저기 보이지?";
            setText(mainText, uiStr);
        }

        if (explainInt == 2)
        {
            uiStr = "친구가 세균을 물리쳐서 우리가 아프지않도록 도와줄 수 있을까?";
            setText(mainText, uiStr);
        }

        if (explainInt == 3)
        {
            uiStr = "7초 후에 총이 생길 거고,\n 컨트롤러로 총을 조작해서 세균들을 물리쳐주면 돼!";
            setText(mainText, uiStr);
        }

        if (explainInt == 4)
        {
            uiStr = "제한시간은 30초정도야.\n그럼 잘 부탁해!";
            setText(mainText, uiStr);
        }

        if (explainInt == 5)
        {
            uiStr = "세균을 물리쳐줘!";
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
