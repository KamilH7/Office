using GameEventSystem;
using UnityEngine;

namespace Player.Events
{
    [CreateAssetMenu(fileName = "PlayerDied", menuName = "SO/Player/Events/PlayerDied")]
    public class PlayerDied : GameEventWithParameter<int>
    {
    }
}