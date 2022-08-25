using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;


public class PauseButton : MonoBehaviour, IPointerClickHandler
{
    private bool _isPaused = false;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(!_isPaused) Time.timeScale = 0;
        else Time.timeScale = 1;
        _isPaused = !_isPaused;
    }
}
