using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Duoshooter
{
    public class MenuController : MonoBehaviour
    {
        public Button playButton;
        public Button exitButton;

        public void OnPlayButtonPress()
        {
            SceneManager.LoadScene("Lobby");  // Connects to the online lobby
        }

        public void OnExitButtonPress()
        {
            Application.Quit();  // Exit the game
        }
    }
}