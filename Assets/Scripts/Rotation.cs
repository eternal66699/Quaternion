using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Quaternion currentRotation;
    public float x, y, z;
    public Vector3 currentEulerAngles;
    public float rotSpeed;

    public Transform TargetA, TargetB;
    float timeCount = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        //transform.rotation = Quaternion.Euler(90,90,90);
        transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        //RotationInputs();
        //QuaternionRotateTowards();
        //QuaternionSlerp();
        LookRotation();
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 28;

        GUI.Label(new Rect(10, 0, 0, 0),"Rotating on X" + x + "Y" + y + "Z" + z, style);

        GUI.Label(new Rect(10, 25, 0, 0), "Current Euler angles" + currentEulerAngles, style);

        GUI.Label(new Rect(10, 50, 0, 0), "Game Object World Euler angles" + transform.eulerAngles, style);
    }

    void RotationInputs()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            x = 1 - x;
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            y = 1 - y;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            z = 1 - z;
        }

        currentEulerAngles += new Vector3(x, y, z) * Time.deltaTime * rotSpeed;
        currentRotation.eulerAngles = currentEulerAngles;
        transform.rotation = currentRotation;
    }

    void QuaternionRotateTowards()
    {
        var step = rotSpeed * Time.time;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetA.rotation, step);
    }

    void QuaternionSlerp()
    {
        transform.rotation = Quaternion.Slerp(TargetA.rotation, TargetB.rotation, timeCount);
        timeCount = timeCount + Time.deltaTime;
    }

    void LookRotation()
    {
        Vector3 relativePos = TargetA.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }
}
