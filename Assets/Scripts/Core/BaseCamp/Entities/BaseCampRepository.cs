using Core.BaseCamp.Configs;
using UnityEngine;

namespace Core.BaseCamp.Entities
{
    public class BaseCampRepository
    {
        private readonly BaseCampConfig _baseCampConfig;
        private readonly BaseCampEntity _baseCampEntity;

        public BaseCampRepository(BaseCampConfig baseCampConfig)
        {
            _baseCampConfig = baseCampConfig;
            _baseCampEntity = new BaseCampEntity();
            
            _baseCampEntity.CurrentHealth = _baseCampConfig.InitialHealth;
        }

        public float GetBaseHealth()
        {
            return _baseCampEntity.CurrentHealth;
        }

        public void UpdateBaseHealth(float damage)
        {
            var newHealth = _baseCampEntity.CurrentHealth -= damage;
            var newHealthClamped = Mathf.Max(newHealth, 0);

            _baseCampEntity.CurrentHealth = newHealthClamped;
        }
    }
}