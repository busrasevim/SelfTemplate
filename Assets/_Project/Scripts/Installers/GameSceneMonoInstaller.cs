using _Project.Scripts.Level;
using _Project.Scripts.Level.Signals;
using _Project.Scripts.Managers;
using _Project.Scripts.Pools;
using _Project.Scripts.SaveSystem;
using _Project.Scripts.State_Machine.State_Machines;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Installers
{
    //If there is a need, open the object pool lines.
    public class GameSceneMonoInstaller : MonoInstaller
    {
       // [SerializeField] private GameObject objectPoolObject;

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<OnLevelCompletedSignal>().OptionalSubscriber();
            Container.DeclareSignal<OnLevelEndSignal>().OptionalSubscriber();
            Container.DeclareSignal<OnLevelStartSignal>().OptionalSubscriber();

            Container.Bind<ISaveSystem>().To<JsonSaveSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<DataManager>().AsSingle();
          //  Container.Bind<ObjectPool>().FromComponentInNewPrefab(objectPoolObject).AsSingle();
            Container.BindInterfacesAndSelfTo<MainStateMachine>().AsSingle();
            Container.BindInterfacesAndSelfTo<UIStateMachine>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<FXManager>().AsSingle();
        }
    }
}