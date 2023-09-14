using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleController : MonoBehaviour
{
            
    void Start()
    {
        Singletun.Instance.InscreaseScore(10);
        GameManager.Instance.InscreaseScrore(15);
    }
    
    

}
