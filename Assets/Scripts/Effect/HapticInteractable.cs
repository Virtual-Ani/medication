using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticInteractable : MonoBehaviour
{
    [SerializeField] private float amplitude = 0.5f;//강도(진폭)
    [SerializeField] private float duration = 0.05f;//지속시간

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

        //진동
        interactor.xrController.SendHapticImpulse(amplitude, duration);

    }


}
