using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGravityPoint : MonoBehaviour {

    #region Private Static Fields

    private static List<Vector3> gravityPointsList = new List<Vector3>();

    #endregion


    #region Exposed Static Properties

    public static bool HasCenterOfGravity { get { return gravityPointsList.Count > 0; } }
    public static Vector3 CenterOfGravity { get; private set; }

    #endregion


    #region Private Fields

    [SerializeField] private int mass;

    #endregion


    #region Exposed Properties

    #endregion


    #region Unity Messages

    private void OnEnable()
    {
        RegisterPoint();
        UpdateCenterOfGravity();
    }

    private void OnDisable()
    {
        UnregisterPoint();
        UpdateCenterOfGravity();
    }

    #endregion


    #region Private Functions

    private void UpdateCenterOfGravity()
    {

    }

    private void RegisterPoint()
    {

    }

    private void UnregisterPoint()
    {

    }

    #endregion


    #region Public Functions

    #endregion


    #region Interface Functions

    public string GetData()
    {
        return "" + mass;
    }

    public void SetData(string data)
    {
        if (!int.TryParse(data, out mass))
        {
            Debug.LogError("Could not parse data from LevelData");
        }
    }

    #endregion
}
