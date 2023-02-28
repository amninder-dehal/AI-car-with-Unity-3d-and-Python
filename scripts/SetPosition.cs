using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour {
    Vector3 StartPoint;

 
 // Use this for initialization
public void Start () {
        StartPoint = transform.position;

 }
void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            print("button pressed");
            transform.position = StartPoint;
            Vector3 newRotation = new Vector3(0f, 00f, 0f);
            SetRotation(newRotation);

        }
    }

void SetRotation(Vector3 eulerRotation) 
{
    transform.rotation = Quaternion.Euler(eulerRotation);
}
public void reset_pos()
{
    transform.position = StartPoint;
}
}