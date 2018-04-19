using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FmodEventParameterController : MonoBehaviour {

    [SerializeField] private string paramName;
    [SerializeField] private float paramValue;

    [SerializeField, FMODUnity.EventRef]
    private string eventRef;
    private FMOD.Studio.EventInstance eventInstance;

    private Dictionary<string, FMOD.Studio.ParameterInstance> paramDict;

    private void Awake()
    {
        paramDict = new Dictionary<string, FMOD.Studio.ParameterInstance>();

        eventInstance = FMODUnity.RuntimeManager.CreateInstance(eventRef);

        LoadParameters(eventInstance);
    }

    private void Start()
    {
        eventInstance.start();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SetParameter(paramName, paramValue);
        }
    }

    private void LoadParameters(FMOD.Studio.EventInstance eventInstance)
    {
        int paramCount;
        eventInstance.getParameterCount(out paramCount);

        for (int i = 0; i < paramCount; i++)
        {
            FMOD.Studio.ParameterInstance paramInstance;
            FMOD.Studio.PARAMETER_DESCRIPTION paramDescription;

            eventInstance.getParameterByIndex(i, out paramInstance);
            paramInstance.getDescription(out paramDescription);

            paramDict.Add((string)paramDescription.name, paramInstance);

            Debug.LogFormat("Param: {0} | Type: {1} | Default value: {2}",
                (string)paramDescription.name,
                paramDescription.type.ToString(),
                paramDescription.defaultvalue
                );
        }
    }

    public void SetParameter(string paramName, float paramValue)
    {
        FMOD.Studio.ParameterInstance paramInstance;

        if (paramDict.TryGetValue(paramName, out paramInstance))
        {
            paramInstance.setValue(paramValue);
        } else
        {
            Debug.LogErrorFormat("Parameter {0} not found!", paramName);
        }
    }

}
