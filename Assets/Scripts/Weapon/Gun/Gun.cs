using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Gun : MonoBehaviour
{
    public UnityEvent OnGrab;//������
    public UnityEvent OnRelease;//������
    private InputDevice targetDevice;
    private void Start()
    {
        // ������ Oculus Touch ��Ʈ�ѷ��� ã��
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        targetDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
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
    public void Grab(SelectEnterEventArgs args)
    {
        var interactor = args.interactorObject;
        if(interactor is XRDirectInteractor)
        {
            OnGrab?.Invoke();
        }
    }

    public void Release(SelectExitEventArgs args)
    {
        var interactor = args.interactorObject;
        if (interactor is XRDirectInteractor)
        {
            OnRelease?.Invoke();
        }
    }
}
