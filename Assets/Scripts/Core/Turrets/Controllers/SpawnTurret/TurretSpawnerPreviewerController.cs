using Core.Turrets.UseCases;
using UnityEngine;

namespace Core.Turrets.Controllers.SpawnTurret
{
    public class TurretSpawnerPreviewerController : MonoBehaviour
    {
        public Camera Camera;
        public LayerMask LayerMask;
        private string _turretId;
        private SpawnTurretUseCase _spawnTurretUseCase;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void Init(SpawnTurretUseCase spawnTurretUseCase)
        {
            _spawnTurretUseCase = spawnTurretUseCase;
        }

        public void ThumbnailPressed(string turretId)
        {
            _turretId = turretId;
        }
        
        //TODO: create an input config
        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 1000, LayerMask))
                {
                    _spawnTurretUseCase.Spawn(_turretId, hit.point); 
                    gameObject.SetActive(false);
                }
            }
        }
    }
}