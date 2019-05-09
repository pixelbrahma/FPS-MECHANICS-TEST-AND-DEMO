using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] private float spinSpeed = 3f;

    void Update()
    {
        transform.Rotate(0, spinSpeed, 0);
    }
}
