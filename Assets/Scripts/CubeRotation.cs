using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    public float rotationSpeed = 5f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    //Obrót cube w zale¿noœci od ruchu myszki
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotationX -= mouseY * rotationSpeed;
        rotationY += mouseX * rotationSpeed;

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }
}
