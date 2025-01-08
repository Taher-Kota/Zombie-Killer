using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    private void Start()
    {
        Invoke("DeactivateItems", 2f);
    }
    void DeactivateItems()
    {        
        gameObject.SetActive(false);
    }
}
