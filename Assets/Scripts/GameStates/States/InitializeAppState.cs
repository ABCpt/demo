using System.Threading.Tasks;
using SceneLoader;
using UnityEngine;
using Zenject;

namespace GameStates.States
{
    public class InitializeAppState : BaseGameState
    {
        private readonly ZenjectSceneLoader _sceneLoader;
        
        public InitializeAppState(ZenjectSceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        public override async Task Enter()
        {
            await base.Enter();
            
            Application.targetFrameRate = 60;

            await Task.Delay(1000);
            
            var asyncLoad = _sceneLoader.LoadSceneAsync(SceneConst.Game);
            
            while (!asyncLoad.isDone)
            {
                await Task.Yield();
            }
        }
    }
}