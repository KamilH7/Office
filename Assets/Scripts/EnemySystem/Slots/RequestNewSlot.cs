using GameEventSystem;
using UnityEngine;

namespace EnemySystem.Slots
{
    [CreateAssetMenu(fileName = "RequestNewSlot", menuName = "SO/EnemySystem/RequestNewSlot")]
    public class RequestNewSlot : GameEventWithParameter<BaseEnemyController>
    {
    }
}