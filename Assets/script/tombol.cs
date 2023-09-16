using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tombol : MonoBehaviour
{
    // Start is called before the first frame update
    public void exit()
    {
        Application.Quit();
    }
    public void pindah(string scene_name)
    {
        Application.LoadLevel(scene_name);
        Time.timeScale = 1f;
    }
    public void ulangi()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void pause()
    {
        Time.timeScale = 0f;
    }
    public void resume()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame

}
