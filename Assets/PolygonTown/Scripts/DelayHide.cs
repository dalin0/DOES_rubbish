using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayHide : MonoBehaviour
{
    void OnEnable() 
    {
        Invoke("Hide",3);
    }

    void Hide() { gameObject.SetActive(false); }
}
