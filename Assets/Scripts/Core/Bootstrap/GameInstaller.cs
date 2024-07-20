using Core.Enemy.Bootstrap;
using Core.Input.Bootstrap;
using Core.Level.Bootstrap;
using Core.Player.Bootstrap;
using Core.Projectile.Bootstrap;
using Core.Weapon.Bootstrap;
using Zenject;

namespace Core.Bootstrap
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Install<LevelInstaller>();
            Container.Install<PlayerInstaller>();
            Container.Install<InputInstaller>();
            Container.Install<ProjectileInstaller>();
            Container.Install<EnemyInstaller>();
            Container.Install<WeaponInstaller>();
        }
    }
}

