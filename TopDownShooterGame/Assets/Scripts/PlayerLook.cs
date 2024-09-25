using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform rotateTarget;
    [SerializeField] private float offset;

    void Update()
    {
        if (PauseManager.Singleton.IsPaused) return;

        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - rotateTarget.position;
        float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg + offset;

        rotateTarget.eulerAngles = new Vector3(0, 0, angle);
    }
}
