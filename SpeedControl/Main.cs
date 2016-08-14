using UnityEngine;

namespace SpeedControl
{
    public class Main : IMod
    {
        private GameObject _gameObject;

        #region Implementation of IMod

        public void onEnabled()
        {
            if (_gameObject != null)
                return;

            _gameObject = new GameObject();
            _gameObject.AddComponent<SpeedControl>();
        }

        public void onDisabled()
        {
            Object.Destroy(_gameObject);
            _gameObject = null;
        }

        public string Identifier { get; set; }
        
        public string Name
        {
            get { return "Speed Control"; }
        }

        public string Description
        {
            get { return Name; }
        }

        #endregion
    }
}
