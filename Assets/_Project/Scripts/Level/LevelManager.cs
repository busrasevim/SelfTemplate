using _Project.Scripts.Data;
using _Project.Scripts.Level.Signals;
using _Project.Scripts.Pools;
using _Project.Scripts.SaveSystem;
using Zenject;

namespace _Project.Scripts.Level
{
    public class LevelManager : IInitializable
    {
        public int CurrentLevelNo { get; private set; }
        
        private LevelGenerator _generator;
        private DataManager _dataManager;
        private SignalBus _signalBus;
        
        public void Initialize()
        {
            //level number value, generating etc
            SetInitialLevel();
        }

        [Inject]
        private void SpecialInit(DataManager dataManager, ObjectPool pool, 
            GameSettings settings, SignalBus signal)
        {
            _dataManager = dataManager;
            _signalBus = signal;
            
            _generator = new LevelGenerator();
        }
        
        public void SetUpLevel()
        {
            _generator.GenerateLevel();
        }

        public void NextLevel()
        {
            OnLevelCompleted(CurrentLevelNo);
            CurrentLevelNo++;
        }
        
        private void SetInitialLevel()
        {
            CurrentLevelNo = _dataManager.GameData.currentLevelNumber;
        }
        
        private void OnLevelCompleted(int completedLevelIndex)
        {
            _signalBus.TryFire(new OnLevelCompletedSignal(completedLevelIndex));
        }
    }
}