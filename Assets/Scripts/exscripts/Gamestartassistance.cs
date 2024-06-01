using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Gamestartassistance : MonoBehaviour
{
    //public GameObject startPanel; // 시작 패널
    public GameObject textPanel2; // 자막 패널
    public TMP_Text mainText2; // 자막 텍스트
    private string uiStr; // 자막에 들어갈 내용

    public GameObject helper; // 도우미 캐릭터
    public GameObject helperPos; // 도우미 캐릭터 생성 위치
    
    //public Button startBtn; // 시작 버튼
    private bool start = false;
    private int explainInt = 0; // 설명 상황을 표시하는 변수

    public GameObject monsterPrefab; // 몬스터 프리팹
    public Transform monsterSpawnPoint; // 몬스터 생성될 위치
    public float spawnRadius = 10f; // 몬스터가 나타날 반경
    public int numberOfMonsters = 7;

    void Start()
    {
        StartCoroutine(StartDialogue2()); // 대화 시작 코루틴 호출

    }


    IEnumerator StartDialogue2()
    {
        //startPanel.SetActive(false);
        start = true;
        
        Instantiate(helper, helperPos.transform.position, helperPos.transform.rotation);

        while (explainInt < 4) // 설명 텍스트가 더 이상 없을 때까지 반복
        {
            setExplainUI2();
            yield return new WaitForSeconds(3f); // 7초 대기
            explainInt++; // 다음 텍스트로 넘어감
        }
        EndDialogue2();

    }

    public void setExplainUI2()
    {

        if (explainInt == 0)
        {
            uiStr = "안녕! 나는 친구가 용사가 될 수 있도록 도와줄 튼튼이라고해!";
            setText2(mainText2, uiStr);
        }

        if (explainInt == 1)
        {
            uiStr = "큰일났어! 몸에 나쁜 세균들이 몰려와서 우리를 괴롭히고있어! 저기 보이지?";
            setText2(mainText2, uiStr);
            SpawnMonster();
        }

        if (explainInt == 2)
        {
            uiStr = "친구가 세균을 물리쳐서 우리가 아프지않도록 도와줄 수 있을까?";
            setText2(mainText2, uiStr);
        }


        if (explainInt == 3)
        {
            uiStr = "빨리 ??위치에 포션을 먹어줘!";
            setText2(mainText2, uiStr);
        }
    }

    void EndDialogue2()
    {
        textPanel2.SetActive(false); // 텍스트 패널 숨기기                
    }

    private void setText2(TMP_Text text, string str)
    {
        text.text = str;
    }

    void SpawnMonster()
    {
        for (int i = 0; i < numberOfMonsters; i++)
        {
            // 몬스터가 나타날 위치를 플레이어 주변의 무작위 위치로 설정
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            //spawnPosition.y = 0; // 몬스터가 지면 위에 나타나도록 y 위치 조정

            // 몬스터 프리팹의 인스턴스 생성
            Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
        }
    }

    // 몬스터 수를 조정하는 함수
    /*public void SetNumberOfMonsters(int newNumber)
    {
        numberOfMonsters = newNumber;
        // 기존에 생성된 몬스터를 모두 제거
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        // 새로운 수에 따라 몬스터 생성
        SpawnMonsters();
    }*/
}