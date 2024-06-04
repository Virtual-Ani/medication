using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    //생성과 파괴를 담당할 이벤트
    //public UnityEvent OnCreated;
    public UnityEvent OnDestroyed;
    private float destroyDelay = 1f;
    private bool isDestroyed = false;

    /*void Start()
    {
        OnCreated?.Invoke();

        MonsterManager.Instance.OnSpawned(this);
    }*/

    public void Destroy()
    {
        if (isDestroyed) return;

        isDestroyed = true;

        Destroy(gameObject, destroyDelay);

        OnDestroyed?.Invoke();

        MonsterManager.Instance.OnDestroyed(this);
    }

}
