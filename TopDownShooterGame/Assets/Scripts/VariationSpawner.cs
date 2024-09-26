using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariationSpawner : MonoBehaviour
{
    void Start()
    {
        Transform killmePls = Instantiate(RoomManager.Singleton.GetRandomRoomVariation(), transform.position, Quaternion.identity).transform;
        killmePls.SetParent(transform);
    }
}
