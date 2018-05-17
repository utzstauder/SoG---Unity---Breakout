using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleMenu : Menu<SimpleMenu> {

    [SerializeField] private Button button;


    #region Unity Messages

    protected override void Awake()
    {
        base.Awake();

        // do stuff here
    }

    #endregion


    #region Menu Controls

    public static void Show()
    {
        Open();

        Instance.button.onClick.AddListener(
                delegate
                {
                    Instance.ShowOptionsMenu();
                }
            );
    }

    public static void Hide()
    {
        Close();
    }

    #endregion


    #region Button Handler

    public void ShowOptionsMenu()
    {
        OptionsMenu.Show();
    }

    #endregion
}
