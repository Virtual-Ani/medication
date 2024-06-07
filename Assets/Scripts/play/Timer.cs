using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using System;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 30; // 게임 제한 시간 
    public Text timerText; // 타이머표시 UI 텍스트
    public PlayableDirector director; // 타임라인을 재생할 PlayableDirector 컴포넌트
    public event Action OnTimerEnded; // 타이머 종료 이벤트
    private GameManager gameManager; // 게임 매니저 스크립트의 인스턴스

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // 게임 매니저 스크립트의 인스턴스를 찾아 참조
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {        
            director.Play(); // PlayableDirector를 통해 타임라인 재생
            OnTimerEnded?.Invoke(); // 타이머 종료 이벤트 발생                
            enabled = false; // 타이머가 멈추고 Update 함수가 더 이상 호출되지 않음
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; // 시각적으로 0이 되기 전에 타이머가 00:00으로 보이게 
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartTimer()
    {
        timeRemaining = 10; // 타이머 시간 초기화 (필요한 시간으로 설정)
        enabled = true; // Update 함수가 작동하도록 Timer 스크립트를 활성화
    }

}
