using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private static LevelLoader instance;
    public static LevelLoader Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LevelLoader>();
                if (instance == null)
                {
                    GameObject ob = new GameObject();
                    ob.hideFlags = HideFlags.HideAndDontSave;
                    instance = ob.AddComponent<LevelLoader>();
                }
            }
            return instance;
        }
    }

    public Animator transition;
    public float transitionTime = 0.5f;
    public bool canReload = true;

    private void Update()
    {
        if (canReload && Input.GetKeyDown(KeyCode.R)) {
            ReloadLevel();
        }
    }

    public void LoadNextLevel() {
        StartCoroutine(TransitionLevel(sceneNumber: SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadLevel(string sceneName) {
        StartCoroutine(TransitionLevel(sceneName: sceneName));
    }

    public void ReloadLevel() {
        StartCoroutine(TransitionLevel(sceneNumber: SceneManager.GetActiveScene().buildIndex));
    }

    private IEnumerator TransitionLevel(string sceneName = null, int sceneNumber = -1) {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        if (sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }
        else if (sceneNumber != -1)
        {
            SceneManager.LoadScene(sceneNumber);
        }
        else {
            Debug.LogError("Set a level to load");
        }
    }
}
