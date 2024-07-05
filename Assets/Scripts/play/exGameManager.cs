using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

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
    public GameObject mon4; //몹 캐릭4
    private GameObject monPos1; //몹 생길위치
    private GameObject monPos2; //몹 생길위치
    private GameObject monPos3; //몹 생길위치
    private GameObject monPos4; //몹 생길위치

    private GameObject portalPos;//약포탈 위치
    private GameObject potionPos;//포션 위치
    private GameObject medicineCol; //약을 놓았는지 판단하는 콜리더

    public GameObject medicinePortal; //약포탈
    public GameObject potion; //포션 에셋

    public GameObject startBtn;


    private bool start = false;
    public bool putMedicine = false;
    private int explainInt = 0; //상황설명시 자막의 기준이 되는 변수

    public float delayInSeconds = 3f;



    private List<GameObject> monsters = new List<GameObject>();
    private List<Vector3> targetPositions = new List<Vector3>();
    private float moveSpeed = 2f;









    // Start is called before the first frame update
    void Start()
    {
        textPanel.SetActive(false);
        OnStartButtonClicked();
    }

    public void OnStartButtonClicked()
    {
        textPanel.SetActive(true);
        uiStr = "곧 '약먹는 용사들'이 시작됩니다";
        setText(mainText, uiStr);
        StartCoroutine(StartExplain()); // 대화 시작 코루틴 호출
    }






    public void startPlay()
    {
        monPos1 = GameObject.Find("MonsterSpot1");
        monPos2 = GameObject.Find("MonsterSpot2");
        monPos3 = GameObject.Find("MonsterSpot3");
        monPos4 = GameObject.Find("MonsterSpot4");
        portalPos = GameObject.Find("PortalSpot");
        helperPos = GameObject.Find("HelperSpot");
        potionPos = GameObject.Find("MedicineSpot");
        medicineCol = GameObject.Find("Cube_Med");

        //몬스터, 헬퍼 배치
        Instantiate(medicinePortal, portalPos.transform.position, portalPos.transform.rotation);
        //Instantiate(mon1, monPos1.transform.position, monPos1.transform.rotation);
        //Instantiate(mon2, monPos2.transform.position, monPos2.transform.rotation);
        //Instantiate(mon3, monPos3.transform.position, monPos3.transform.rotation);
        //Instantiate(mon4, monPos4.transform.position, monPos4.transform.rotation);

        //Instantiate(helper, helperPos.transform.position, helperPos.transform.rotation);


        monsters.Add(Instantiate(mon1, monPos1.transform.position, monPos1.transform.rotation));
        monsters.Add(Instantiate(mon2, monPos2.transform.position, monPos2.transform.rotation));
        monsters.Add(Instantiate(mon3, monPos3.transform.position, monPos3.transform.rotation));
        monsters.Add(Instantiate(mon4, monPos4.transform.position, monPos4.transform.rotation));
        GameObject helperObject = Instantiate(helper, helperPos.transform.position, helperPos.transform.rotation);




        start = true;

        //이동 목표 위치 설정
        SetTargetPositions(helper.transform.position);

    }

    void SetTargetPositions(Vector3 helperPosition)
    {
        foreach (var monster in monsters)
        {
            Vector3 randomOffset = new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));
            targetPositions.Add(helperPosition + randomOffset);
        }
    }


    void Update()
    {
        if (start)
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                if (monsters[i] != null)
                {
                    // 몬스터들을 목표 위치로 이동시킴
                    monsters[i].transform.position = Vector3.MoveTowards(monsters[i].transform.position, targetPositions[i], moveSpeed * Time.deltaTime);
                }
            }
        }
    }




    IEnumerator StartExplain()
    {
        //startPanel.SetActive(false);
        //start = true;
        startBtn.SetActive(false); // start버튼 비활성화
        yield return new WaitForSeconds(5f); // 5초 대기
        Debug.Log("게임 로딩..(씬 불러온다)");
        startPlay();


        while (explainInt < 4) // 설명 텍스트가 더 이상 없을 때까지 반복
        {
            setExplainUI();
            yield return new WaitForSeconds(3f); // 3초 대기
            explainInt++; // 다음 텍스트로 넘어감
        }

        // while 루프 내에서 putMedicine을 체크하도록 수정
        while (!putMedicine)
        {
            yield return null; // 매 프레임 대기
        }


        Debug.Log("약 놓음 확인");
        medicineCol.SetActive(false);
        yield return new WaitForSeconds(2f); // 2초 대기
        Instantiate(potion, potionPos.transform.position, potionPos.transform.rotation);


        yield return new WaitForSeconds(3f); // 3초 대기
        uiStr = "잘했어! 약은 이제 포션이 되었고, 먹으면 힘이 세질거야!";
        setText(mainText, uiStr);
        yield return new WaitForSeconds(3f); // 3초 대기
        uiStr = "포션을 집어서 먹고 용사가 되어보자!";
        setText(mainText, uiStr);
        yield return new WaitForSeconds(3f); // 3초 대기
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
            uiStr = "좋아, 그럼 포탈 가운데에 약을 놓아줘\n 그럼 힘이 생기는 포션이 생길거야!";
            setText(mainText, uiStr);
            putMedicine = false;
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
