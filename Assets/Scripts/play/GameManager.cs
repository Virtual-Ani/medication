using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject startPanel; //시작 패
    public GameObject textPanel; //자막 패널
    public TMP_Text mainText; //자막 text
    private string uiStr; // 자막에 들어갈 내용

    public GameObject helper; //도우미 캐릭
    public GameObject helperPos; //도우미 캐릭 생성장소
    public GameObject Gun; //총 오브젝트
    public GameObject GunPos; //총 생길위ㅊ
    private bool isGun = false; //총이 있는지

    public Button startBtn; //startPanel_startBtn
    private bool start = false;
    private int explainInt = 0; //상황설명시 자막의 기준이 되는 변&


    // Start is called before the first frame update
    void Start()
    {
        textPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        setExplainUI(); //ExplainUI 관리

    }


    public void startPlay()
    {
        startPanel.SetActive(false);
        start = true;
        textPanel.SetActive(true);
        Instantiate(helper, helperPos.transform.position, helperPos.transform.rotation);
        
    }


    public void setExplainUI()
    {
        if (start&&explainInt==0)
        {
            uiStr = "안녕! 나는 친구가 용사가 될 수 있도록 도와줄 튼튼이라고해!\n(오른쪽에 있는 버튼을 눌러서 진행해줘)";
            setText(mainText, uiStr);
        }
        if (start && explainInt == 1)
        {
            uiStr = "몸에 나쁜 세균들이 몰려와서 우리를 괴롭히고있어! 저기 보이지?";
            setText(mainText, uiStr);
        }
        if (start && explainInt == 2)
        {
            uiStr = "친구가 세균을 물리쳐서 우리가 아프지않도록 도와줄 수 있을까?";
            setText(mainText, uiStr);
        }
        if (start && explainInt == 3)
        {
            uiStr = "고마워! 앞에 보이는 빛나는 곳에 친구가 먹을 약을 놓아줄래?";
            setText(mainText, uiStr);
        }
        if (start && explainInt == 4)
        {
            uiStr = "좋아, 그럼 이제 그 약이 포션으로 바뀌어보일거야";
            setText(mainText, uiStr);
        }
        if (start && explainInt == 5)
        {
            uiStr = "포션을 먹으면 총이 생기고,\n친구는 그 총으로 세균들을 물리쳐주면 돼!";
            setText(mainText, uiStr);
        }
        if (start && explainInt == 6)
        {
            uiStr = "그럼 포션을 먹어보자! 잘 부탁해!";
            setText(mainText, uiStr);
        }
        if (start && explainInt == 7&&isGun==false)//테스트용
        {
            uiStr = "총이 생겼니?";
            setText(mainText, uiStr);
            appearGun();
        }

    }

    public void appearGun()
    {
        Instantiate(Gun, GunPos.transform.position, GunPos.transform.rotation);
        isGun = true;
    }




    public void nextText()
    {
        explainInt++;
    }
    



    // Text의 내용을 변경
    private void setText(TMP_Text text, string str)
    {
        text.text = str;
    }
}
