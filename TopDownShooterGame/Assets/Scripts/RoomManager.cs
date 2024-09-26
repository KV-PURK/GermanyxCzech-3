using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    private static RoomManager _singleton;

    public static RoomManager Singleton
    {
        get => _singleton;

        set
        {
            if (_singleton == null)
            {
                _singleton = value;
            }
            else
            {
                Debug.LogWarning($"{nameof(RoomManager)} Instance already exists, destroying duplicate");
                Destroy(value);
            }
        }
    }

    private void Awake()
    {
        Singleton = this;
    }

    public List<GameObject> roomVariations;

    public GameObject GetRandomRoomVariation()
    {
        return roomVariations[Random.Range(0, roomVariations.Count)];
    }
}
