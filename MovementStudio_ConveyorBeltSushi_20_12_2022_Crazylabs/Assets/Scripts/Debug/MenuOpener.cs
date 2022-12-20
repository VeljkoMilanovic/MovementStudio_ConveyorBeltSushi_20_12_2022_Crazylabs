using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpener : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject menuButton;
    public GameObject backButton;
    // Start is called before the first frame update
    public void openMenu()
    {
        if (MenuPanel != null)
        {
            MenuPanel.SetActive(true);
            menuButton.SetActive(false);
            backButton.SetActive(true);
        }
    }

    public void closeMenu()
    {
        if (MenuPanel != null)
        {
            MenuPanel.SetActive(false);
            menuButton.SetActive(true);
            backButton.SetActive(false);
        }
    }
}
