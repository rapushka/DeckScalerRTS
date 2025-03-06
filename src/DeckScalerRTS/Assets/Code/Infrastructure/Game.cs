using UnityEngine;

namespace DeckScaler
{
    public class Game
    {
        private static Game _instance;

        public static Game Instance => _instance ??= new();

        private Game() { }

        private static IGameStateMachine StateMachine => ServiceLocator.Resolve<IGameStateMachine>();

        public void Start()
        {
            StateMachine.ToState<BootstrapGameState>();
        }

        public void Quit()
        {
#if UNITY_EDITOR
            Debug.Log("Quitting the game...");
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}