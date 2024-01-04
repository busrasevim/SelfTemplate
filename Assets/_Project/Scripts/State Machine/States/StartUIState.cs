using _Project.Scripts.SaveSystem;
using _Project.Scripts.State_Machine.State_Machines;
using _Project.Scripts.UI;

namespace _Project.Scripts.State_Machine.States
{
    public class StartUIState : BaseState<UIStateMachine.UIState>
    {
        private StartUI _startUI;
        private DataManager _dataManager;

        public StartUIState(UIStateMachine.UIState key, UIStateMachine.UIState nextStateKey, StartUI startUI,
            DataManager dataManager) : base(key)
        {
            NextStateKey = nextStateKey;
            _startUI = startUI;
            _dataManager = dataManager;
        }

        public override void OnEnter()
        {
            _startUI.Show();
            _startUI.SetLevelText(_dataManager.GameData.currentLevelNumber + 1);
        }

        public override void OnExit()
        {
            _startUI.Hide();
        }
    }
}