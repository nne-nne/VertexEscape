using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VertexEscape.Core
{
    public class SceneSwitcher : MonoBehaviour
    {
        public void LoadNextScene()
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if(nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
            {
                Debug.Log("No more scenes");
                return;
            }

            Debug.Log("Loading next scene");
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
