using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private int _activeSceneBuildIndex = 0;

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        _activeSceneBuildIndex = activeScene.buildIndex;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(_activeSceneBuildIndex + 1);
        Time.timeScale = 1;
    }

    public void LoadLevel(string level){
        SceneManager.LoadScene(level);
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
