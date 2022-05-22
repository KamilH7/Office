using System;
using PowerUpSystem.PowerUps;

namespace PowerUpSystem.Spawning
{
    [Serializable]
    public class SpawnablePowerUp
    {
        public BasePowerUpController prefab;
        public int spawnWeight;
    }
}