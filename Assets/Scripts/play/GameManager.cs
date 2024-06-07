using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    //public GameObject startPanel; //시작 패
    public GameObject textPanel; //자막 패널
    public Text mainText; //자막 text
    private string uiStr; // 자막에 들어갈 내용



    //public GameObject Gun; //총 오브젝트
    //public GameObject GunPos; //총 생길위치
    //private bool isGun = false; //총이 있는지

    public GameObject mon1; //몹 캐릭1
    public GameObject mon2; //몹 캐릭2
    public GameObject mon3; //몹 캐릭3



    //public Button startBtn; //startPanel_startBtn
    private bool start = false;
    private int explainInt = 0; //상황설명시 자막의 기준이 되는 변&

    //public float delayInSeconds = 3f;

    public GameObject monsterPrefab; // 몬스터 프리팹
    public Transform spawnArea; // 몬스터가 나타날 범위
    public float spawnRadius = 3f; // 몬스터가 나타날 반경
    public int numberOfMonsters = 2;

    public Timer timerScript;
    public GameObject TimerPanel; // 타이머 패널
    
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("ActivateObject", delayInSeconds);
        //textPanel.SetActive(false);
        StartCoroutine(StartDialogue()); // 대화 시작 코루틴 호출
    }

    /*// Update is called once per frame
    void Update()
    {
        setExplainUI(); //ExplainUI 관리

    }*/


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

        while (explainInt < 3) // 설명 텍스트가 더 이상 없을 때까지 반복
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
            uiStr = "이제 곧 총이 생기고,\n그 총으로 세균들을 물리쳐주면 돼!";
            setText(mainText, uiStr);
        }

        if (explainInt == 1)
        {
            uiStr = "제한시간은 30초정도야.\n그럼 잘 부탁해!";
            setText(mainText, uiStr);
        }

        if (explainInt == 2)
        {
            uiStr = "세균을 물리쳐줘!";
            setText(mainText, uiStr);
            //appearGun();
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
        randomPos.y = 1; // Y축 위치 조정
        return randomPos;
    }
  
    GameObject GetRandomMon()
    {
        int random = Random.Range(0, 3);
        if(random == 0)
        {
            monsterPrefab = mon1;
        }
        else if(random == 1)
        {
            monsterPrefab = mon2;
        }
        else { monsterPrefab = mon3;}
        return monsterPrefab;
    }

    //public void appearGun()
    //{
    //    Instantiate(Gun, GunPos.transform.position, GunPos.transform.rotation);
    //    isGun = true;
    //}


    /*public void nextText()
    {
        explainInt++;
    }*/
    
    // Text의 내용을 변경
    private void setText(Text text, string str)
    {
        text.text = str;
    }
}
