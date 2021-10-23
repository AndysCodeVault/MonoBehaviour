using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTracker : MonoBehaviour
{
    private float _updateCount = 0;
    private float _fixedUpdateCount = 0;
    private float _updateCountPerSecond = 0;
    private float _fixedUpdateCountPerSecond = 0;
    private float _lastDisplayTime = 0;
        
    // Update is called once per frame
    void Update()
    {
        _updateCount += 1;
        if (Time.time > _lastDisplayTime + 1f)
        {
            _updateCountPerSecond = _updateCount;
            _fixedUpdateCountPerSecond = _fixedUpdateCount;
            _updateCount = 0;
            _fixedUpdateCount = 0;
            _lastDisplayTime = Time.time;
        }
    }

    private void FixedUpdate()
    {
        _fixedUpdateCount += 1;
    }

    private void OnGUI()
    {
        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
        fontSize.fontSize = 24;
        GUI.color = new Color(0.35f, 0, 0, 1f);
        GUI.Label(new Rect(100, 100, 200, 50), "Update: " + _updateCountPerSecond.ToString(), fontSize);
        GUI.Label(new Rect(100, 125, 200, 50), "FixedUpdate: " + _fixedUpdateCountPerSecond.ToString(), fontSize);
    }
}
