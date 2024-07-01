using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    //public GameObject startPanel; //시작 패널
    public GameObject textPanel; //자막 패널
    public Text mainText; //자막 text
    private string uiStr; // 자막에 들어갈 내용


    public GameObject mon1; //몹 캐릭1
    public GameObject mon2; //몹 캐릭2
    public GameObject mon3; //몹 캐릭3
    public GameObject mon4; //몹 캐릭3



    //public Button startBtn; //startPanel_startBtn
    private bool start = false;
    private int explainInt = 0; //상황설명시 자막의 기준이 되는 변수



    public GameObject monsterPrefab; // 몬스터 프리팹
    public Transform spawnArea; // 몬스터가 나타날 범위
    public float spawnRadius = 3f; // 몬스터가 나타날 반경
    public int numberOfMonsters = 2;

    public Timer timerScript;
    private Timer timer;
    private bool isMonsterSpawning = true;
    public GameObject TimerPanel; // 타이머 패널
    
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("ActivateObject", delayInSeconds);
        //textPanel.SetActive(false);
        StartCoroutine(StartDialogue()); // 대화 시작 코루틴 호출
        timer = FindObjectOfType<Timer>(); // 타이머 스크립트의 인스턴스를 찾아 참조
        timer.OnTimerEnded += StopMonsterSpawn; // 타이머가 끝났을 때 StopMonsterSpawn 메서드 호출

    }


    /*public void startPlay()
    {
        
        startPanel.SetActive(false);
        start = true;
        textPanel.SetActive(true);
        Instantiate(helper, helperPos.transform.position, helperPos.transform.rotation);     
    }*/

    IEnumerator StartDialogue()
    {
        //startPanel.SetActive(false);
        //start = true;
        TimerPanel.SetActive(false);
        //Instantiate(helper, helperPos.transform.position, helperPos.transform.rotation);


        while (explainInt < 4) // 설명 텍스트가 더 이상 없을 때까지 반복
        {
            setExplainUI();
            yield return new WaitForSeconds(5f); // 5초 대기
            explainInt++; // 다음 텍스트로 넘어감
        }
        EndDialogue();

    }

    public void setExplainUI()
    {

        if (explainInt == 0)
        {
            uiStr = "총이 보이지?\n그 총으로 세균들을 물리쳐주면 돼!";
            setText(mainText, uiStr);
        }

        if (explainInt == 1)
        {
            uiStr = "총을 잡고 트리거버튼을 누르면 총알이 나갈거야.\n총알 장전은 A, B버튼을 눌러줘";
            setText(mainText, uiStr);
        }

        if (explainInt == 2)
        {
            uiStr = "제한시간은 30초정도야.\n그럼 잘 부탁해!";
            setText(mainText, uiStr);
        }

        if (explainInt == 3)
        {
            uiStr = "세균을 물리쳐줘!";
            setText(mainText, uiStr);
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
        monsterPrefab = GetRandomMon();
        GameObject spawnedMonster = Instantiate(monsterPrefab, randomPos, Quaternion.Euler(0,180,0));
        StartCoroutine(DisappearMonster(spawnedMonster)); // 세균 사라짐과 재생성을 관리하는 코루틴
    }

    // 몬스터 생성 함수
    void SpawnMonsters()
    {
        if (isMonsterSpawning)
        {
            for (int i = 0; i < numberOfMonsters; i++)
            {
                SpawnMonster();
            }
        }
    }

    // 수정된 몬스터 사라짐 및 재생성 코루틴
    IEnumerator DisappearMonster(GameObject monster)
    {
        yield return new WaitForSeconds(4f); // 4초 대기
        Destroy(monster); // 몬스터 오브젝트 파괴
        if (isMonsterSpawning) // 몬스터 재생성 중지
        {
            yield return new WaitForSeconds(2f);
            SpawnMonster();
        }
    }

    // 무작위 위치 생성 함수
    Vector3 GetRandomPosition()
    {
        Vector3 randomPos = Random.insideUnitSphere * spawnRadius;
        randomPos += spawnArea.position; // spawnArea를 중심으로 위치 조정
        randomPos.y = 1; // Y축 위치 조정
        return randomPos;
    }
  
    GameObject GetRandomMon()
    {
        int random = Random.Range(0, 4);
        if(random == 0)
        {
            monsterPrefab = mon1;
        }
        else if(random == 1)
        {
            monsterPrefab = mon2;
        }
        else if (random == 2)
        {
            monsterPrefab = mon3;
        }
        else { monsterPrefab = mon4;}
        return monsterPrefab;
    }





    public void StopMonsterSpawn()
    {
        isMonsterSpawning = false;
        StopAllCoroutines(); // 모든 코루틴 중지
    }

    // Text의 내용을 변경
    private void setText(Text text, string str)
    {
        text.text = str;
    }
}
