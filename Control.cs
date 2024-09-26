using UnityEngine;
using System.IO.Ports;

public class Control : MonoBehaviour
{

    SerialPort stream = new SerialPort("/dev/tty.usbmodem21101", 9600);
    public string received_string;

    public GameObject player; 

    // Left, Right, Jump, Crouch
    public Vector4 movement_vector;    

    void Start()
    {
        stream.Open(); //Open the Serial Stream.  

        if (stream.IsOpen){
            Debug.Log("Opened");
        }
        else{
            Debug.Log("Nope");
        }
    }

    void Update()
    {
        received_string = stream.ReadLine(); //Read the information
        stream.BaseStream.Flush(); //Clear the serial information so we assure we get new information.

        string[] recieved_values  = received_string.Split(",");

        if (recieved_values[0] != "" && recieved_values[1] != "" && recieved_values[2] != "" && recieved_values[3] != "" /*&& recieved_values[4] != ""*/ )
        {
            movement_vector[0] = float.Parse(recieved_values[0]);
            movement_vector[1] = float.Parse(recieved_values[1]);
            movement_vector[2] = float.Parse(recieved_values[2]);
            movement_vector[3] = float.Parse(recieved_values[3]);

            stream.BaseStream.Flush(); //Clear the serial information so we assure we get new information.
        }
    }


}