using UnityEngine;

public class ClassesTestScript : MonoBehaviour {

    Human humanA;

    void Start () {
        //Debug.LogFormat("Population: {0}", Human.population);

        //humanA = new Human();
        //humanA = new Human();
        //humanA = new Human();
        //humanA = new Human();
        //humanA = new Human();

        //Debug.LogFormat("Population: {0}", Human.population);

        // float vs. double
        // float myFloat   = 3.14f;
        // double myDouble = 3.14;


        //// Value Types
        //Debug.Log("Value Types");

        //Vector3 myFirstVector = new Vector3(10.0f, 0, 50.0f);
        //Debug.LogFormat("1st: {0}", myFirstVector);

        //myFirstVector.y = 20.0f;
        //Debug.LogFormat("1st: {0}", myFirstVector);

        //Vector3 mySecondVector = myFirstVector;
        //Debug.LogFormat("2nd: {0}", mySecondVector);

        //myFirstVector.x = 8000.0f;
        //Debug.LogFormat("1st: {0}", myFirstVector);
        //Debug.LogFormat("2nd: {0}", mySecondVector);


        //// Reference Types
        //Debug.Log("Reference Types");
        //Debug.LogFormat("transform: {0}", transform.position);

        //transform.position = new Vector3(10.0f, 0, 0);
        //Debug.LogFormat("transform: {0}", transform.position);

        //Transform myTransform = transform;
        //Debug.LogFormat("myTransform: {0}", myTransform.position);

        //transform.position = new Vector3(-10.0f, 0, 0);
        //Debug.LogFormat("transform: {0}", transform.position);
        //Debug.LogFormat("myTransform: {0}", myTransform.position);

        MetaHuman superman = new MetaHuman("Superman", 900000);
        Debug.LogFormat("{0} is {1} years old.",
            superman.GetName(),
            superman.GetAgeInYears());

        superman.Rejuvenate(10000);

        Debug.LogFormat("{0} is {1} years old.",
            superman.GetName(),
            superman.GetAgeInYears());


        Debug.LogFormat("{0} is {1} days old.",
            superman.GetName(),
            superman.GetAgeInDays());

        superman.Age();

        Debug.LogFormat("{0} is {1} days old.",
            superman.GetName(),
            superman.GetAgeInDays());
    }
}
