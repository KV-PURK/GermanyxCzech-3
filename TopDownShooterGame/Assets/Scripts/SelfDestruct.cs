using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    [SerializeField] private float delay = 0.0f;

    void Start()
    {
        Destroy(gameObject, delay);
    }
}
