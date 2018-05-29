using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindWithTag : MonoBehaviour
{

    public float rotationSpeed = 70.0f;

    bool repeatRotateRight = false;
    private bool isDetecting;
    public Text PlaneEnabled;
    public Text PlaneDisabled;

    // Use this for initialization
    void Start ()
    {
        PlaneEnabled.enabled = true;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (repeatRotateRight)
        {
            RotationRightButton();
        }

    }

    public void RotationRightButton()
    {
        GameObject go = GameObject.FindWithTag("Caballero");

        if (go && go.activeSelf)
        {
            go.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }

    public void RotationRightButtonRepeat()
    {
        // transform.Rotate (0, -rotationSpeed * Time.deltaTime, 0);
        repeatRotateRight = true;
    }

    public void RotationRightButtonStop()
    {
        repeatRotateRight = false;
    }

    public void DetectionOff()
    {
        if (isDetecting == true)
        {
            Debug.Log("deshabilitado");
            isDetecting = false;
            PlaneDisabled.enabled = true;
        }
        else
        {
            Debug.Log("habilitado");
            isDetecting = true;
            PlaneEnabled.enabled = true;

        }
    }
}

