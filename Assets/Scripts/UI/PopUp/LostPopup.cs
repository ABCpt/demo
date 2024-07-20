using GameStates;
using GameStates.States;

namespace UI.PopUp
{
   public class LostPopup : BasePopup
   {
      protected override void OnChangeState(BaseGameState gameState)
      {
         base.OnChangeState(gameState);

         if (gameState is LostGameState)
            gameObject.SetActive(true);
      }
   }
}
