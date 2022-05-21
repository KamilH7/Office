using System.Collections.Generic;
using System.Linq;
using EnemySystem.Slots;
using UnityEngine;
using Random = System.Random;

public class SlotManager : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField]
    private List<SpawnSlot> spawnSlots;

    #endregion

    #region Public Methods

    public SpawnSlot TryGetRandomFreeSpawnSlot()
    {
        List<SpawnSlot> freeSlots = spawnSlots.Where(slot => !slot.IsOccupied).ToList();

        Random random = new Random();

        return freeSlots.Count > 0 ? freeSlots[random.Next(0, freeSlots.Count - 1)] : null;
    }

    public void ClearAllSlots()
    {
        foreach (SpawnSlot spawnSlot in spawnSlots)
        {
            spawnSlot.ClearSpot();
        }
    }

    #endregion
}