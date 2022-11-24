using Core.Creeps.UseCase;
using Core.Turrets.Configs;
using Core.Turrets.Views;
using Events;

namespace Core.Turrets.UseCases
{
    public class ProjectileFactory
    {
        private readonly ProjectilesConfiguration _configuration;
        private readonly AssetCatalog.AssetCatalog _assetCatalog;

        public ProjectileFactory(ProjectilesConfiguration configuration)
        {
            _assetCatalog = ServiceLocator.Instance.GetService<AssetCatalog.AssetCatalog>();
            _configuration = configuration;
        }

        public IGameElementRepresentation Get<T>(T projectileConfiguration) where T : ProjectileConfiguration
        {
            ProjectileView view;
            switch (projectileConfiguration)
            {
                case FrozenProjectile _:
                    view = _assetCatalog.LoadResource<ProjectileView>(_configuration.RegularProjectile.PrefabPath);
                    return GameRepresentationObjectFactory
                        .GameRepresentationObject<ProjectileFrozenGameElementRepresentation>(view);
                
                case RegularProjectile _:
                default:
                    view = _assetCatalog.LoadResource<ProjectileView>(_configuration.RegularProjectile.PrefabPath);
                    return GameRepresentationObjectFactory
                        .GameRepresentationObject<ProjectileRegularGameElementRepresentation>(view);
            }
        }
    }
}