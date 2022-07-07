using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestRotate : MonoBehaviour
{
    public float rotateSpeed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, -rotateSpeed * Time.deltaTime, 0f);
    }
}
