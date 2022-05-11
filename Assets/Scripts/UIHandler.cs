using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] float _moveXTime = 1f;

    void OnEnable()
    {
        LeanTween.moveX(gameObject, Screen.width/2, _moveXTime).setEaseOutElastic();
    }

    
}
