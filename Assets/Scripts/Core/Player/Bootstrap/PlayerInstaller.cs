using Core.Player.Model;
using Zenject;

namespace Core.Player.Bootstrap
{
    public class PlayerInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerModel>().AsSingle().NonLazy();
        }
    }
}

