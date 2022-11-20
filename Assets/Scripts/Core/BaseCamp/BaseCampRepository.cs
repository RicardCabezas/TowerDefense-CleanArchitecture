using UnityEngine;

namespace Core.Base
{
    public class BaseCampRepository
    {
        private readonly BaseCampConfig _baseCampConfig;
        private readonly BaseCampModel _baseCampModel;

        public BaseCampRepository(BaseCampConfig baseCampConfig)
        {
            _baseCampConfig = baseCampConfig;
            _baseCampModel = new BaseCampModel();
            
            _baseCampModel.CurrentHealth = _baseCampConfig.InitialHealth;
        }

        public float GetBaseHealth()
        {
            return _baseCampModel.CurrentHealth;
        }

        public void UpdateBaseHealth(float damage)
        {
            var newHealth = _baseCampModel.CurrentHealth -= damage;
            var newHealthClamped = Mathf.Max(newHealth, 0);

            _baseCampModel.CurrentHealth = newHealthClamped;
        }
    }
}