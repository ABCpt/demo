using Core.Weapon.Model;
using Core.Weapon.Rules;
using Zenject;

namespace Core.Weapon.Bootstrap
{
    public class WeaponInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<WeaponModel>().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<WeaponAttackRule>().AsSingle().NonLazy();
        }
    }
}

