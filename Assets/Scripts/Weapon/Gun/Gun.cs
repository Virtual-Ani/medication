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
    public UnityEvent OnGrab;//잡을때
    public UnityEvent OnRelease;//놓을때
    private InputDevice targetDevice;

    [SerializeField]public GameObject btnMapper;
    private void Start()
    {
        //btnMapper = GameObject.FindWithTag("ButtonMapper");
        // 오른손 Oculus Touch 컨트롤러를 찾음
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        targetDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        btnMapper.SetActive(false);
    }

    private void Update()
    {
        // 컨트롤러의 트리거 버튼 입력 확인
        if (targetDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerPressed) && triggerPressed)
        {
            Debug.Log("Trigger Button Pressed!");
            // 여기에 트리거 버튼을 눌렀을 때의 동작을 추가할 수 있습니다.
        }

        // 컨트롤러의 그립 버튼 입력 확인
        if (targetDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool gripPressed) && gripPressed)
        {
            Debug.Log("Grip Button Pressed!");

            // 여기에 그립 버튼을 눌렀을 때의 동작을 추가할 수 있습니다.
        }
    }
    public void Grab()
    {
        OnGrab?.Invoke();
        Debug.Log("그랩");
        btnMapper.SetActive(true);
    }

    public void Release()
    {
        OnRelease?.Invoke();
        Debug.Log("놓기");
        btnMapper.SetActive(false);
    }
}
