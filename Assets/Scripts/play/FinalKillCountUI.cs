using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalKillCountUI : MonoBehaviour
{
    //public KillCount killCountScript; // ų ī��Ʈ ��ũ��Ʈ ����
    //public Timer timerScript; // Ÿ�̸� ��ũ��Ʈ ����
    public TMP_Text finalKillCountText; // ���� ų ī��Ʈ�� ǥ���� UI �ؽ�Ʈ

    public GameObject textPanel; //�ڸ� �г�
    public Text mainText; //�ڸ� text
    private string uiStr; // �ڸ��� �� ����
    private int explainInt = 0; //��Ȳ����� �ڸ��� ������ �Ǵ� ����


    private void Start()
    {
        // Ÿ�̸� ��ũ��Ʈ�� Ÿ�̸� ���� �̺�Ʈ�� �Լ� ����
        //timerScript.OnTimerEnd += DisplayFinalKillCount;
        DisplayFinalKillCount();

        StartCoroutine(EndingDialogue()); // ��ȭ ���� �ڷ�ƾ ȣ��


    }

    private void DisplayFinalKillCount()
    {
        // ų ī��Ʈ ��ũ��Ʈ�� killcount ���� ���� �����ͼ� UI �ؽ�Ʈ�� ǥ��
        finalKillCountText.text = $"Final Kill Count: \n{KillCount.killcount}";
    }


    IEnumerator EndingDialogue()
    {

        textPanel.SetActive(true);


        while (explainInt < 4) // ���� �ؽ�Ʈ�� �� �̻� ���� ������ �ݺ�
        {
            setExplainUI();
            yield return new WaitForSeconds(4f); // 4�� ���
            explainInt++; // ���� �ؽ�Ʈ�� �Ѿ
        }

    }

    public void setExplainUI()
    {

        if (explainInt == 0)
        {
            uiStr = "���� ���յ��� ��� �����ƾ�!";
            setText(mainText, uiStr);
        }

        if (explainInt == 1)
        {
            uiStr = "ģ���� ���� �Ծ��ְ� ��簡 �Ǿ��� ���п� �� �� �־���";
            setText(mainText, uiStr);
        }

        if (explainInt == 2)
        {
            uiStr = "��ó�� ���� ������ �ǰ��ϰ�, ưư�� ����� �� �� �ִٴ� �� ������!";
            setText(mainText, uiStr);
        }

        if (explainInt == 3)
        {
            uiStr = "�׷� �����ε� �� �� �Ա��!\n�츮 ��� �ǰ��� ��簡 ����! �ȳ�~!";
            setText(mainText, uiStr);
        }
    }


    // Text�� ������ ����
    private void setText(Text text, string str)
    {
        text.text = str;
    }
}
