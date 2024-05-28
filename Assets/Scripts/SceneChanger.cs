using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // UI ��Ҹ� ����ϱ� ���� �߰�
using System.Collections; // �ڷ�ƾ ����� ���� �߰�

public class SceneChanger : MonoBehaviour
{
    public string targetTag = "Enemy"; // ������ ����� �±� �̸�
    public Text countdownText; // ī��Ʈ�ٿ��� ǥ���� UI �ؽ�Ʈ
    public Text guide; //�ȳ� �ؽ�Ʈ

    private void Start()
    {
        // ������ �� �ؽ�Ʈ�� ����
        countdownText.enabled = false;
        guide.enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            guide.enabled = true; // �浹�� �ȳ��ؽ�Ʈ ��Ÿ��
            countdownText.enabled = true; // �浹 �� �ؽ�Ʈ�� ��Ÿ��
            StartCoroutine(ChangeSceneAfterDelay("PlayScene", 7)); // �ڷ�ƾ ȣ��
        }
    }

    IEnumerator ChangeSceneAfterDelay(string sceneName, int delay)
    {
        for (int i = delay; i > 0; i--)
        {
            countdownText.text = i.ToString(); // ī��Ʈ�ٿ� ���ڸ� �ؽ�Ʈ�� ����
            yield return new WaitForSeconds(1); // 1�� ���
        }

        SceneManager.LoadScene(sceneName); // ������ �� �ε�
    }
}
