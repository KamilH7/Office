using System.Collections;
using Player;
using Player.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private PlayerData playerData;

        [Header("UI References"), SerializeField, Space(10)]
        private Image fillImage;
        [SerializeField]
        private TMP_Text healthChangeText;

        [SerializeField, Header("Listening to:")]
        private PlayerDamaged playerDamaged;
        [SerializeField]
        private PlayerHealed playerHealed;

        #endregion

        #region Private Fields

        private IEnumerator textBlinkCoroutine;
        private bool coroutineRunning;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            AssignCallbacks();
        }

        private void OnDisable()
        {
            UnAssignCallbacks();
        }

        private void Start()
        {
            RestartHealthBar();
        }

        #endregion

        #region Private Methods

        private void RestartHealthBar()
        {
            DisableHealthChangeText();
            UpdateHealthBar();
        }

        private void PlayerHealthIncreased(float changeAmount)
        {
            UpdateHealthBar();
            RestartTextBlinkCoroutine($"+{changeAmount}");
        }

        private void PlayerHealthDecreased(float changeAmount)
        {
            UpdateHealthBar();
            RestartTextBlinkCoroutine($"{changeAmount}");
        }

        private void UpdateHealthBar()
        {
            fillImage.fillAmount = playerData.GetHealthPercentage();
        }

        private void RestartTextBlinkCoroutine(string text)
        {
            
            if (coroutineRunning)
            {
                StopCoroutine(textBlinkCoroutine);
            }

            textBlinkCoroutine = BlinkHealthChangeText(text);
            
            StartCoroutine(BlinkHealthChangeText(text));
        }

        private IEnumerator BlinkHealthChangeText(string text)
        {
            coroutineRunning = true;
            healthChangeText.text = text;
            EnableHealthChangeText();

            yield return new WaitForSeconds(1);

            DisableHealthChangeText();
            coroutineRunning = false;
        }

        private void DisableHealthChangeText()
        {
            healthChangeText.enabled = false;
        }

        private void EnableHealthChangeText()
        {
            healthChangeText.enabled = true;
        }

        private void AssignCallbacks()
        {
            playerDamaged.Subscribe(PlayerHealthIncreased);
            playerHealed.Subscribe(PlayerHealthDecreased);
        }

        private void UnAssignCallbacks()
        {
            playerDamaged.UnSubscribe(PlayerHealthIncreased);
            playerHealed.UnSubscribe(PlayerHealthDecreased);
        }

        #endregion
    }
}