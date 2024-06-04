using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MonsterManager : MonoBehaviour
{
    private static MonsterManager instance;

    public static MonsterManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<MonsterManager>();

            return instance;
        }
    }
    public UnityEvent<Enemy> OnDestroy;
    public void OnDestroyed(Enemy mon)
    {
        OnDestroy?.Invoke(mon);
        Debug.Log("∏ÛΩ∫≈Õ¡◊¿”!!!");
    }

}
