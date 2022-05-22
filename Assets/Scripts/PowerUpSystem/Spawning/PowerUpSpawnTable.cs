using System.Collections.Generic;
using System.Linq;
using PowerUpSystem.PowerUps;
using UnityEngine;

namespace PowerUpSystem.Spawning
{
    [CreateAssetMenu(fileName = "PowerUpSpawnTable", menuName = "SO/PowerUpSystem/PowerUpSpawnTable")]
    public class PowerUpSpawnTable : ScriptableObject
    {
        #region Serialized Fields

        [SerializeField]
        private List<SpawnablePowerUp> spawnablePowerUps;

        #endregion

        #region Public Methods

        public BasePowerUpController GetRandomPowerUpPrefab()
        {
            int randomNumber = Random.Range(0, CalculateWeightSum());

            foreach (SpawnablePowerUp powerUp in spawnablePowerUps)
            {
                if (powerUp.spawnWeight >= randomNumber)
                {
                    return powerUp.prefab;
                }

                randomNumber -= powerUp.spawnWeight;
            }

            return null;
        }

        #endregion

        #region Private Methods

        private int CalculateWeightSum()
        {
            return spawnablePowerUps.Sum(powerUp => powerUp.spawnWeight);
        }

        #endregion
    }
}