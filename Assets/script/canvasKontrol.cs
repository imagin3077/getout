using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class canvasKontrol : MonoBehaviour
{
    public static canvasKontrol ck;
    public GameObject panel_gameover;
    public GameObject announcement;
    public GameObject panel_selesai;
   
    void Awake()
    {
        if(canvasKontrol.ck == null) {
           canvasKontrol.ck = this; 
        }
    }
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        panel_gameover.SetActive(true);
    }

    public void Selesai()
    {
        panel_selesai.SetActive(true);
    }

    public void kasihtau()
    {
        announcement.SetActive(true);
    }

    public void kasihtu()
    {
        announcement.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
