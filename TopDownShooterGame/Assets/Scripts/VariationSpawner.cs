using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariationSpawner : MonoBehaviour
{
    void Start()
    {
        Instantiate(RoomManager.Singleton.GetRandomRoomVariation(), transform.position, Quaternion.identity);
    }
}
