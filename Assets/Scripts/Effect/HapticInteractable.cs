using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticInteractable : MonoBehaviour
{
    [SerializeField] private float amplitude = 0.5f;//����(����)
    [SerializeField] private float duration = 0.05f;//���ӽð�

    private XRBaseInteractable target;

    private void Awake()
    {
        target = GetComponent<XRBaseInteractable>();
    }

    public void Call()
    {
        if (target == null) return;

        if (target.firstInteractorSelecting == null) return;

        if (!(target.firstInteractorSelecting is XRBaseControllerInteractor)) return;

        var interactor = target.firstInteractorSelecting as XRBaseControllerInteractor;

        if (interactor.xrController == null) return;

        //����
        interactor.xrController.SendHapticImpulse(amplitude, duration);

    }


}