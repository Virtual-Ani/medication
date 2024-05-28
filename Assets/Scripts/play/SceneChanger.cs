using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // UI 요소를 사용하기 위해 추가
using System.Collections; // 코루틴 사용을 위해 추가

public class SceneChanger : MonoBehaviour
{
    public string targetTag = "Enemy"; // 감지할 대상의 태그 이름
    public Text countdownText; // 카운트다운을 표시할 UI 텍스트
    public Text guide; //안내 텍스트

    private void Start()
    {
        // 시작할 때 텍스트를 숨김
        countdownText.enabled = false;
        guide.enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            guide.enabled = true; // 충돌시 안내텍스트 나타남
            countdownText.enabled = true; // 충돌 시 텍스트를 나타냄
            StartCoroutine(ChangeSceneAfterDelay("PlayScene", 7)); // 코루틴 호출
        }
    }

    IEnumerator ChangeSceneAfterDelay(string sceneName, int delay)
    {
        for (int i = delay; i > 0; i--)
        {
            countdownText.text = i.ToString(); // 카운트다운 숫자를 텍스트로 설정
            yield return new WaitForSeconds(1); // 1초 대기
        }

        SceneManager.LoadScene(sceneName); // 지정된 씬 로드
    }
}
