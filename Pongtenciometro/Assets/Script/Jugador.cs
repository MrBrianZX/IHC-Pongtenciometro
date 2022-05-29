using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Jugador : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private float bounds = 4.5f;

    public static SerialPort puerto = new SerialPort("COM5",9600);

    // Start is called before the first frame update
    void Start()
    {
        puerto.ReadTimeout = 30;
        if(puerto.IsOpen){
            puerto.Close();
        }
        puerto.Open();
    }

    // Update is called once per frame
    void Update()
    {
        Move(inputDuino());
    }

    private void Move(int dir){
        float moveInput = Input.GetAxisRaw("Horizontal");

        Vector2 playerPosition = transform.position;
        playerPosition.x = Mathf.Clamp(playerPosition.x + dir * moveSpeed * Time.deltaTime, -bounds ,bounds);
        transform.position = playerPosition;
    }

    public int inputDuino(){
        int dir = 0;
        string dato = "D";
        try{
            if(puerto.IsOpen){
                dato = puerto.ReadLine();
                Debug.Log(dato);
            }
        }catch(System.Exception Ex){}

        if(dato.Equals("L"))
            dir = -1;
        else if(dato.Equals("R"))
            dir = 1;
        return dir;
    }

        static public bool buttonDuino(){
        bool state = false;
        string dato = "D";
        try{
            if(puerto.IsOpen){
                dato = puerto.ReadLine();
                Debug.Log(dato);
            }
        }catch(System.Exception Ex){}

        if(dato.Equals("B"))
            state = true;
        return state;
    }
}
