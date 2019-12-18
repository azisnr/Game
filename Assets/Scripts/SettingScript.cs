using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingScript : MonoBehaviour
{

    public GameObject settingPanel;
    public bool settingStatus;
	public KeyCode esq;

    void Start ()
    {
        settingStatus = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(settingStatus == false){
            if (Input.GetKeyDown(esq)) {
                if (GameManager.instance.gamestatus == GameManager.GameStatus.Wait){
                    openPengaturan();
                }if (GameManager.instance.gamestatus == GameManager.GameStatus.GameOver){
                    openPengaturan();
                }
            }
        }else if(settingStatus == true){
            if (Input.GetKeyDown(esq)) {
                if (GameManager.instance.gamestatus == GameManager.GameStatus.Wait){ 
                    closePengaturan();
                }if (GameManager.instance.gamestatus == GameManager.GameStatus.GameOver){
                    closePengaturan();
                }
            }
		}
    }

    public void openPengaturan(){
        settingPanel.SetActive(true);
        settingStatus = true;
    }

    public void closePengaturan(){
        settingPanel.SetActive(false);
        settingStatus = false;
    }
}
