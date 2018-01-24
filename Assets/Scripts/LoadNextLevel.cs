using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        // Debug.LogFormat("childCount: {0}", transform.childCount);
        if (transform.childCount <= 0)
        {
            // get index of active scene
            int targetSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // increment scene index
            targetSceneIndex++; // += 1;

            // scene index in valid range?
            if (targetSceneIndex >= SceneManager.sceneCountInBuildSettings)
            {
                // scene index not in valid range -> wrap index
                targetSceneIndex = 0;
            }

            // load target scene
            SceneManager.LoadScene(targetSceneIndex);

            
        }
	}
}
