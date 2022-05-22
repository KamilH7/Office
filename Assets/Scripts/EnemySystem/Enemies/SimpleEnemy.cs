namespace EnemySystem.Enemies
{
    public class SimpleEnemy : BaseEnemyController
    {
        #region Public Methods

        public override void Initialize(float difficulty)
        {
            baseDamageTimer /= difficulty;
            baseDamage = (int) (baseDamage * difficulty);
        }

        #endregion
    }
}