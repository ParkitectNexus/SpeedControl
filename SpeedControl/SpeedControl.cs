using Parkitect.UI;
using UnityEngine;

namespace SpeedControl
{
    public class SpeedControl : MonoBehaviour
    {
        private float _defaultTimeStep;
        private void Awake()
        {
            _defaultTimeStep = Time.fixedDeltaTime;
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (UIUtility.isInputFieldFocused())
                return;

            if (Input.GetKeyUp(KeyCode.Alpha4))
                SetGameSpeed(5);
            if (Input.GetKeyUp(KeyCode.Alpha5))
                SetGameSpeed(7);
            if (Input.GetKeyUp(KeyCode.Alpha6))
                SetGameSpeed(10);
        }

        private void SetGameSpeed(float newSpeed)
        {
            if (Time.timeScale == newSpeed) return;
            var oldSpeed = Time.timeScale;
            Time.timeScale = newSpeed;
            Time.fixedDeltaTime = newSpeed >= 1.0f ? _defaultTimeStep : _defaultTimeStep * newSpeed;

            EventManager.Instance.RaiseOnTimeSpeedChanged(oldSpeed, newSpeed);
        }


        private void OnDestroy()
        {
        }
    }
}