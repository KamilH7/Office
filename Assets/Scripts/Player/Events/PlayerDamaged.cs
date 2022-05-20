using GameEventSystem;
using UnityEngine;

namespace Player.Events
{
    [CreateAssetMenu(fileName = "PlayerDamaged", menuName = "SO/Player/Events/PlayerDamaged")]
    public class PlayerDamaged : GameEventWithParameter<float>
    {
    }
}