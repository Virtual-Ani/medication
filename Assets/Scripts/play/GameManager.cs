using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{
    //public GameObject startPanel; // 시작 패널
    public GameObject textPanel; // 자막 패널
    public TMP_Text mainText; // 자막 텍스트
    private string uiStr; // 자막에 들어갈 내용

    public GameObject helper; // 도우미 캐릭터
    public GameObject helperPos; // 도우미 캐릭터 생성 위치
    public GameObject Gun; // 총 오브젝트
    public GameObject GunPos; // 총 생성 위치
    private bool isGun = false; // 총이 있는지 여부

    //public Button startBtn; // 시작 버튼
    private bool start = false;
    private int explainInt = 0; // 설명 상황을 표시하는 변수

    public GameObject monsterPrefab; // 몬스터 프리팹
    public Transform spawnArea; // 몬스터가 나타날 범위
    public float spawnRadius = 10f; // 몬스터가 나타날 반경
    public int numberOfMonsters = 5;

    public Timer timerScript;
    public GameObject TimerPanel; // 타이머 패널

    void Start()
    {
        StartCoroutine(StartDialogue()); // 대화 시작 코루틴 호출

    }
   

    IEnumerator StartDialogue()
    {
        //startPanel.SetActive(false);
        //start = true;
        TimerPanel.SetActive(false);
        Instantiate(helper, helperPos.transform.position, helperPos.transform.rotation);

        while (explainInt < 6) // 설명 텍스트가 더 이상 없을 때까지 반복
        {
            setExplainUI();
            yield return new WaitForSeconds(2f); // 7초 대기
            explainInt++; // 다음 텍스트로 넘어감
        }
        EndDialogue();
        
    }

    public void setExplainUI()
    {
        
        if (explainInt == 0)
        {
            uiStr = "안녕! 나는 친구가 용사가 될 수 있도록 도와줄 튼튼이라고해!\n(오른쪽에 있는 버튼을 눌러서 진행해줘)";
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
            uiStr = "이제 곧 총이 생기고,\n그 총으로 세균들을 물리쳐주면 돼!";
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
            appearGun();
        }

        
    }

    void EndDialogue()
    {
        textPanel.SetActive(false); // 텍스트 패널 숨기기     
        SpawnMonsters(); // 몬스터 생성 함수 호출
        timerScript.StartTimer(); // 타이머 시작
        TimerPanel.SetActive(true);
    }

    void SpawnMonster()
    {
        Vector3 randomPos = GetRandomPosition();
        GameObject spawnedMonster = Instantiate(monsterPrefab, randomPos, Quaternion.identity);
        StartCoroutine(DisappearMonster(spawnedMonster)); // 세균 사라짐과 재생성을 관리하는 코루틴
    }

    // 몬스터 생성 함수
    void SpawnMonsters()
    {
        for (int i = 0; i < numberOfMonsters; i++)
        {          
            // 이 위치에 몬스터를 생성
            SpawnMonster();
        }
    }

    // 수정된 몬스터 사라짐 및 재생성 코루틴
    IEnumerator DisappearMonster(GameObject monster)
    {
        yield return new WaitForSeconds(3f); // 3초 대기
        Destroy(monster); // 몬스터 오브젝트 파괴
        yield return new WaitForSeconds(3f); // 다시 3초 대기
        SpawnMonster(); 
    }

    // 무작위 위치 생성 함수
    Vector3 GetRandomPosition()
    {
        Vector3 randomPos = Random.insideUnitSphere * spawnRadius;
        randomPos += spawnArea.position; // spawnArea를 중심으로 위치 조정
        randomPos.y = 0; // Y축 위치 조정
        return randomPos;
    }

    public void appearGun()
    {
        Instantiate(Gun, GunPos.transform.position, GunPos.transform.rotation);
        isGun = true;
    }

    private void setText(TMP_Text text, string str)
    {
        text.text = str;
    }
}