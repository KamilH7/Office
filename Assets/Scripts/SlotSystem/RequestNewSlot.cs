using GameEventSystem;
using UnityEngine;

namespace SlotSystem
{
    [CreateAssetMenu(fileName = "RequestNewSlot", menuName = "SO/EnemySystem/RequestNewSlot")]
    public class RequestNewSlot : GameEventWithParameter<ISlottable>
    {
    }
}