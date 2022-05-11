using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] GameObject _tapCanvas;
    [SerializeField] GameObject _counterCanvas;
    [SerializeField] GameObject _deathCanvas;

    public void RemoveTap()
    {
        _tapCanvas.SetActive(false);
        _counterCanvas.SetActive(true);
    }

    public void DeathUI()
    {
        Invoke("EnableCanvas", 1f);
    }

    private void EnableCanvas()
    {
        _deathCanvas.SetActive(true);
    }
}
