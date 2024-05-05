using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class Core : MonoBehaviour
{
    [SerializeField] int maxHp = 10;
    private int Hp;

    public UnityEvent<string> OnHpChanged;
    public UnityEvent OnHit;
    public UnityEvent OnDestroy;

    private static Core instance;

    public static Core Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<Core>();

            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        Hp = maxHp;
        UpdateUI();
    }

    private void DecreaseHp(int amount)
    {
        if (Hp <= 0) return;

        Hp -= amount;

        if (Hp <= 0)
        {
            Hp = 0;
            OnDestroy?.Invoke();
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        OnHpChanged?.Invoke($"HP\n{Hp}");
    }

    private void OnTriggerEnter(Collider other)
    {
        /*var mon = other.GetComponent<Monster>();

        if (mon != null)
        {
            OnHit?.Invoke();
            DecreaseHp(1);
            mon.Destroy();
        }*/
    }
}