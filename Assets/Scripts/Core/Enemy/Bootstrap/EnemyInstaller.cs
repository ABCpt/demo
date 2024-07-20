using Core.Enemy.Model;
using Core.Enemy.Rules;
using Core.Enemy.Services;
using Zenject;

namespace Core.Enemy.Bootstrap
{
    public class EnemyInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<EnemyPool>().AsSingle().NonLazy();
            Container.Bind<EnemyFactory>().AsSingle().NonLazy();
            
            Container.Bind<EnemyModel>().AsTransient().NonLazy();
            
            Container.BindInterfacesAndSelfTo<EnemiesService>().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<SpawnEnemyRule>().AsSingle().NonLazy();
            Container.BindInterfacesTo<MoveEnemiesRule>().AsSingle().NonLazy();
            Container.BindInterfacesTo<DamageEnemyOnPlayerRule>().AsSingle().NonLazy();
        }
    }
}

