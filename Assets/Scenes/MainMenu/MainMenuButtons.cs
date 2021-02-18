using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuButtons : MonoBehaviour
{
    public Button devRoom;

    void Start()
    {
        devRoom.onClick.AddListener(LoadDevRoom);
    }

    public void LoadDevRoom()
    {
        GameManager.instance.LoadGame();
    }
}
