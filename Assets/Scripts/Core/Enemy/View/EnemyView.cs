using Common.Pool.View;
using Core.Enemy.Model;

namespace Core.Enemy.View
{
    public class EnemyView : BasePoolable
    {
        public EnemyModel Model { get; private set; }

        public void Initialize(EnemyModel model)
        {
            Model = model;
            Model.UpdatePosition += OnUpdatePosition;

            OnUpdatePosition();
        }

        private void OnUpdatePosition()
        {
            transform.position = Model.Position;
        }
    }
}

