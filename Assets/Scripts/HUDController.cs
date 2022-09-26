using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : Observer
{
    private float _currentHealth;
    private CubeController cubeController;
    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(50, 50, 100, 200));
        GUILayout.BeginHorizontal("box");
        GUILayout.Label("Health: " + _currentHealth.ToString());
        GUILayout.EndHorizontal();
    }

    public override void Notify(Subject subject)
    {
        if (!cubeController)
        {
            cubeController = subject.GetComponent<CubeController>();
        }

        if(cubeController)
        {
            _currentHealth = cubeController.CurrentHealth;
        }
    }

}
