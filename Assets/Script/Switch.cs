using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    public int storyCount = 0;

    public Animator storyMan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void right()
    {
        
    }

    public void lift()
    {

    }

    public void skip()
    {
        SceneManager.LoadScene(2);
    }
}
