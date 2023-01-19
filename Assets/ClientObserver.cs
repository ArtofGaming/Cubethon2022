using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientObserver : MonoBehaviour
{
    private CubeController cubeController;

    // Start is called before the first frame update
    void Start()
    {
        cubeController = (CubeController)GetComponent(typeof(CubeController));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
