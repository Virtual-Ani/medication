using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine;

public class ActivateGun : MonoBehaviour
{
    private void Update()
    {
        // Primary Button�� ���ȴ��� Ȯ��
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Debug.Log("Primary Button�� ���Ƚ��ϴ�.");
            // Primary Button�� ������ �� ������ ������ ���⿡ �߰��մϴ�.
        }
    }
}