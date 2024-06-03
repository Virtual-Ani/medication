using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medicine : MonoBehaviour
{
    public exGameManager exGameManager;
    // Start is called before the first frame update
    void Start()
    {
        exGameManager = exGameManager.GetComponent<exGameManager>();
        if (exGameManager != null)
        {
            Debug.Log("gotcha! exGameManager!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("medicine"))
        {
            Debug.Log("충돌! 약 놓았다");

            exGameManager.putMedicine = true;
        }
    }
}
