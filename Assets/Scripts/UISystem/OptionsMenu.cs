using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : Menu<OptionsMenu> {

    #region Menu Controls

    public static void Show()
    {
        Open();
    }

    public static void Hide()
    {
        Close();
    }

    #endregion
}
