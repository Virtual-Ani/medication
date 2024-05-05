using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine;

public class ActivateGun : MonoBehaviour
{
    private void Update()
    {
        // Primary Button이 눌렸는지 확인
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Debug.Log("Primary Button이 눌렸습니다.");
            // Primary Button이 눌렸을 때 실행할 동작을 여기에 추가합니다.
        }
    }
}