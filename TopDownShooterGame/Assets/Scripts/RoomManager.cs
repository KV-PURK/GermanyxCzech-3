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

    private List<Room> notClearedRooms = new List<Room>();

    public List<GameObject> roomVariations;

    private void Awake()
    {
        Singleton = this;
    }

    public GameObject GetRandomRoomVariation()
    {
        return roomVariations[Random.Range(0, roomVariations.Count)];
    }

    public void OnRoomSpawn(Room room)
    {
        room.onRoomCleared.AddListener(new UnityEngine.Events.UnityAction<Room>(OnRoomCleared));
        notClearedRooms.Add(room);
    }

    public void OnRoomCleared(Room room)
    {
        notClearedRooms.Remove(room);

        if (notClearedRooms.Count <= 0)
        {
            UIManager.Singleton.DungeonCleared();
        }
    }
}
