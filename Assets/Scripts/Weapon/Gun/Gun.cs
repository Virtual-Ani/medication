using Meta.XR.BuildingBlocks;
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;

public class Gun : MonoBehaviour
{
    public UnityEvent OnGrab;//������
    public UnityEvent OnRelease;//������
    private InputDevice targetDevice;

    [SerializeField]public GameObject btnMapper;
    private void Start()
    {
        //btnMapper = GameObject.FindWithTag("ButtonMapper");
        // ������ Oculus Touch ��Ʈ�ѷ��� ã��
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        targetDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        btnMapper.SetActive(false);
    }

    private void Update()
    {
        // ��Ʈ�ѷ��� Ʈ���� ��ư �Է� Ȯ��
        if (targetDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerPressed) && triggerPressed)
        {
            Debug.Log("Trigger Button Pressed!");
            // ���⿡ Ʈ���� ��ư�� ������ ���� ������ �߰��� �� �ֽ��ϴ�.
        }

        // ��Ʈ�ѷ��� �׸� ��ư �Է� Ȯ��
        if (targetDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool gripPressed) && gripPressed)
        {
            Debug.Log("Grip Button Pressed!");

            // ���⿡ �׸� ��ư�� ������ ���� ������ �߰��� �� �ֽ��ϴ�.
        }
    }
    public void Grab()
    {
        OnGrab?.Invoke();
        Debug.Log("�׷�");
        btnMapper.SetActive(true);
    }

    public void Release()
    {
        OnRelease?.Invoke();
        Debug.Log("����");
        btnMapper.SetActive(false);
    }
}
