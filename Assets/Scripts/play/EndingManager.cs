using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EndingManager : MonoBehaviour
{
    //public GameObject startPanel; //���� �г�
    public GameObject textPanel; //�ڸ� �г�
    public Text mainText; //�ڸ� text
    private string uiStr; // �ڸ��� �� ����

    //public Button startBtn; //startPanel_startBtn
    private bool start = false;
    private int textInt = 0; //��Ȳ����� �ڸ��� ������ �Ǵ� ����

    public GameObject helper; //����� ĳ��
    public GameObject helperPos; //����� ĳ�� �������
    void Start()
    {
        //Invoke("ActivateObject", delayInSeconds);
        //textPanel.SetActive(false);
        StartCoroutine(StartEndingDialogue()); // ��ȭ ���� �ڷ�ƾ ȣ��
        Instantiate(helper, helperPos.transform.position, helperPos.transform.rotation);
    }


    IEnumerator StartEndingDialogue()
    {
        while (textInt < 5) // ���� �ؽ�Ʈ�� �� �̻� ���� ������ �ݺ�
        {
            setExplainUI();
            yield return new WaitForSeconds(5f); // 5�� ���
            textInt++; // ���� �ؽ�Ʈ�� �Ѿ
        }
        EndDialogue();

    }

    public void setExplainUI()
    {

        if (textInt == 0)
        {
            uiStr = "ģ�� ���п� �������� ���� ��Ƴ��� �� �־���! ����!";
            setText(mainText, uiStr);
        }

        if (textInt == 1)
        {
            uiStr = "���� �����ϱ� �츮 ���� ��ų �� �ִ� ���Ⱑ ��Ÿ����?";
            setText(mainText, uiStr);
        }

        if (textInt == 2)
        {
            uiStr = "�����ε� ���� ������ �츮 ģ���� ��ų �� �ִ� ���� ����ž�.";
            setText(mainText, uiStr);
        }

        if (textInt == 3)
        {
            uiStr = "�տ� ���̴� ��� ���� �������� ���� ������! ������� �ƴϾ�!";
            setText(mainText, uiStr);
        }

        if (textInt == 4)
        {
            uiStr = "�����ε� �츮 ģ���� �൵ �߸԰� ������ �� �ٴϱ⸦ �ٷ�!";
            setText(mainText, uiStr);
        }
    }

    void EndDialogue()
    {
        textPanel.SetActive(false); // �ؽ�Ʈ �г� �����     
    }

    // Text�� ������ ����
    private void setText(Text text, string str)
    {
        text.text = str;
    }
}
