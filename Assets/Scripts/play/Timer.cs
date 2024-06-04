using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 30; // ���� ���� �ð� 
    public Text timerText; // Ÿ�̸�ǥ�� UI �ؽ�Ʈ
    public PlayableDirector director; // Ÿ�Ӷ����� ����� PlayableDirector ������Ʈ


    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            director.Play(); // PlayableDirector�� ���� Ÿ�Ӷ��� ���
            enabled = false; // Ÿ�̸Ӱ� ���߰� Update �Լ��� �� �̻� ȣ����� ����

        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; // �ð������� 0�� �Ǳ� ���� Ÿ�̸Ӱ� 00:00���� ���̰� 
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartTimer()
    {
        timeRemaining = 10; // Ÿ�̸� �ð� �ʱ�ȭ (�ʿ��� �ð����� ����)
        enabled = true; // Update �Լ��� �۵��ϵ��� Timer ��ũ��Ʈ�� Ȱ��ȭ

    }
}
