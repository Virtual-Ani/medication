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

    private void Start()
    {
        // Ÿ�̸� ��ũ��Ʈ�� Ÿ�̸� ���� �̺�Ʈ�� �Լ� ����
        //timerScript.OnTimerEnd += DisplayFinalKillCount;
        DisplayFinalKillCount();
    }

    private void DisplayFinalKillCount()
    {
        // ų ī��Ʈ ��ũ��Ʈ�� killcount ���� ���� �����ͼ� UI �ؽ�Ʈ�� ǥ��
        finalKillCountText.text = $"Final Kill Count: \n{KillCount.killcount}";
    }
}
