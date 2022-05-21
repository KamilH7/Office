using GameEventSystem;
using UnityEngine;

namespace Player.Events
{
    [CreateAssetMenu(fileName = "ScoreChanged", menuName = "SO/Player/Events/ScoreChanged")]
    public class ScoreChanged : GameEventWithParameter<int>
    {
    }
}