/*
 * Author:          Tiffany Nguyen
 * Date:            December 13, 2020
 * Description:     This script handles the buttons on the main menu.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;

    public void OnPlayButtonPress()
    {
        SceneManager.LoadScene("Game");  // Play the game
    }

    public void OnExitButtonPress()
    {
        Application.Quit();  // Exit the game
    }
}
