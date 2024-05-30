using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 30; // 게임 제한 시간 
    public Text timerText; // 타이머표시 UI 텍스트


    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            Debug.Log("시간 종료!");
            // 여기에 엔딩씬?혹은 무언가 이벤트 넣으면 될꺼같습니다.
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; // 시각적으로 0이 되기 전에 타이머가 00:00으로 보이게 하기 위함
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartTimer()
    {
        timeRemaining = 30; // 타이머 시간 초기화 (필요한 시간으로 설정)
        enabled = true; // Update 함수가 작동하도록 Timer 스크립트를 활성화

    }
}
