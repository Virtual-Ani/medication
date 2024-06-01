using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Gamestartassistance : MonoBehaviour
{
    //public GameObject startPanel; // ���� �г�
    public GameObject textPanel2; // �ڸ� �г�
    public TMP_Text mainText2; // �ڸ� �ؽ�Ʈ
    private string uiStr; // �ڸ��� �� ����

    public GameObject helper; // ����� ĳ����
    public GameObject helperPos; // ����� ĳ���� ���� ��ġ
    
    //public Button startBtn; // ���� ��ư
    private bool start = false;
    private int explainInt = 0; // ���� ��Ȳ�� ǥ���ϴ� ����

    public GameObject monsterPrefab; // ���� ������
    public Transform monsterSpawnPoint; // ���� ������ ��ġ
    public float spawnRadius = 10f; // ���Ͱ� ��Ÿ�� �ݰ�
    public int numberOfMonsters = 7;

    void Start()
    {
        StartCoroutine(StartDialogue2()); // ��ȭ ���� �ڷ�ƾ ȣ��

    }


    IEnumerator StartDialogue2()
    {
        //startPanel.SetActive(false);
        start = true;
        
        Instantiate(helper, helperPos.transform.position, helperPos.transform.rotation);

        while (explainInt < 4) // ���� �ؽ�Ʈ�� �� �̻� ���� ������ �ݺ�
        {
            setExplainUI2();
            yield return new WaitForSeconds(3f); // 7�� ���
            explainInt++; // ���� �ؽ�Ʈ�� �Ѿ
        }
        EndDialogue2();

    }

    public void setExplainUI2()
    {

        if (explainInt == 0)
        {
            uiStr = "�ȳ�! ���� ģ���� ��簡 �� �� �ֵ��� ������ ưư�̶����!";
            setText2(mainText2, uiStr);
        }

        if (explainInt == 1)
        {
            uiStr = "ū�ϳ���! ���� ���� ���յ��� �����ͼ� �츮�� ���������־�! ���� ������?";
            setText2(mainText2, uiStr);
            SpawnMonster();
        }

        if (explainInt == 2)
        {
            uiStr = "ģ���� ������ �����ļ� �츮�� �������ʵ��� ������ �� ������?";
            setText2(mainText2, uiStr);
        }


        if (explainInt == 3)
        {
            uiStr = "���� ??��ġ�� ������ �Ծ���!";
            setText2(mainText2, uiStr);
        }
    }

    void EndDialogue2()
    {
        textPanel2.SetActive(false); // �ؽ�Ʈ �г� �����                
    }

    private void setText2(TMP_Text text, string str)
    {
        text.text = str;
    }

    void SpawnMonster()
    {
        for (int i = 0; i < numberOfMonsters; i++)
        {
            // ���Ͱ� ��Ÿ�� ��ġ�� �÷��̾� �ֺ��� ������ ��ġ�� ����
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            //spawnPosition.y = 0; // ���Ͱ� ���� ���� ��Ÿ������ y ��ġ ����

            // ���� �������� �ν��Ͻ� ����
            Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
        }
    }

    // ���� ���� �����ϴ� �Լ�
    /*public void SetNumberOfMonsters(int newNumber)
    {
        numberOfMonsters = newNumber;
        // ������ ������ ���͸� ��� ����
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        // ���ο� ���� ���� ���� ����
        SpawnMonsters();
    }*/
}