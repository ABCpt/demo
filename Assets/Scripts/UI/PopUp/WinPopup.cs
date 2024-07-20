using GameStates;
using GameStates.States;

namespace UI.PopUp
{
   public class WinPopup : BasePopup
   {
      protected override void OnChangeState(BaseGameState gameState)
      {
         base.OnChangeState(gameState);

         if (gameState is WinGameState)
            gameObject.SetActive(true);
      }
   }
}
