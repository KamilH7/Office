using GameEventSystem;
using UnityEngine;

namespace Player.Events
{
    [CreateAssetMenu(fileName = "PlayerHealed", menuName = "SO/Player/Events/PlayerHealed")]
    public class PlayerHealed : GameEventWithParameter<float>
    {
    }
}