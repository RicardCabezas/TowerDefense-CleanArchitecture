namespace Core.Creeps.UseCase
{
    public interface ICreepReceivedProjectile
    {
        void Execute(int creepInstanceId, int projectileInstanceId);
    }
}