using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Level.Interface;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core.Level.Rules
{
    public class UpdateLevelRule : ILevelStartable, ILevelFinishable
    {
        private readonly DiContainer _container;
        
        private List<ILevelUpdatable> _updatables = new List<ILevelUpdatable>();
        private IDisposable _updateDisposable;

        public UpdateLevelRule(DiContainer container)
        {
            _container = container;
        }
        
        public void StartLevel()
        {
            _updatables = _container.ResolveAll<ILevelUpdatable>();
            
            _updateDisposable = Observable.EveryUpdate().Subscribe(_ =>
            {
               Update();
            }); 
        }

        private void Update()
        {
            foreach (var updatable in _updatables)
            {
                updatable.UpdateLevel();
            }
        }

        public async void FinishLevel()
        {
            _updateDisposable?.Dispose();
            
            await Task.Yield();
            
            _updatables?.Clear();
        }
    }
}
