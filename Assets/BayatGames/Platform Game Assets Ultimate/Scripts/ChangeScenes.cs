using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{   
    public List<string> names;
    void Start() {
        List<string> names = new List<string>();
        names.Add("MainMenu");
        names.Add("RedAdventures");
    }
    
    public void NextScene (int numScene)
    {
        SceneManager.LoadScene(names[numScene]);
    }
}
