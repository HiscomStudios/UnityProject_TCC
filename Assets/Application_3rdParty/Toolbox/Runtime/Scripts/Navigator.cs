namespace Toolbox.Runtime.Scripts
{
    using System;
    using UnityEngine.SceneManagement;
    
    public static class Navigator
    {
        #region Methods

        #region Public Methods

        /// <summary>
        /// Loads a scene.
        /// </summary>
        /// <param name="sceneIndex"> The index of the scene to load </param>
        /// <param name="loadSceneMode"> The load scene mode to use </param>
        /// <param name="onSceneLoaded"> Action to be executed when loaded scene finishes loading </param>
        /// <param name="onSceneUnloaded"> Action to be executed when the current scene is unloaded </param>
        public static void Navigate(int sceneIndex, LoadSceneMode loadSceneMode, Action onSceneLoaded = null, Action onSceneUnloaded = null)
        {
            var currentScene = SceneManager.GetActiveScene();
            
            SceneManager.sceneLoaded += OnSceneLoaded;
            void OnSceneLoaded(Scene scene, LoadSceneMode mode)
            {
                onSceneLoaded?.Invoke();
                SceneManager.SetActiveScene(scene);
                SceneManager.UnloadSceneAsync(currentScene);
                SceneManager.sceneLoaded -= OnSceneLoaded;
            }
            
            SceneManager.sceneUnloaded += OnSceneUnloaded;
            void OnSceneUnloaded(Scene scene)
            {
                onSceneUnloaded?.Invoke();
                SceneManager.sceneUnloaded -= OnSceneUnloaded;
            }

            SceneManager.LoadScene(sceneIndex, loadSceneMode);
        }

        /// <summary>
        /// Loads a scene.
        /// </summary>
        /// <param name="sceneName"> The name of the scene to load </param>
        /// <param name="loadSceneMode"> The load scene mode to use </param>
        /// <param name="onSceneLoaded"> Action to be executed when loaded scene finishes loading </param>
        /// <param name="onSceneUnloaded"> Action to be executed when the current scene is unloaded </param>
        public static void Navigate(string sceneName, LoadSceneMode loadSceneMode, Action onSceneLoaded = null, Action onSceneUnloaded = null)
        {
            var currentScene = SceneManager.GetActiveScene();
            
            SceneManager.sceneLoaded += OnSceneLoaded;
            void OnSceneLoaded(Scene scene, LoadSceneMode mode)
            {
                onSceneLoaded?.Invoke();
                SceneManager.SetActiveScene(scene);
                SceneManager.UnloadSceneAsync(currentScene);
                SceneManager.sceneLoaded -= OnSceneLoaded;
            }
            
            SceneManager.sceneUnloaded += OnSceneUnloaded;
            void OnSceneUnloaded(Scene scene)
            {
                onSceneUnloaded?.Invoke();
                SceneManager.sceneUnloaded -= OnSceneUnloaded;
            }

            SceneManager.LoadScene(sceneName, loadSceneMode);
        }

        #endregion

        #endregion
    }
}