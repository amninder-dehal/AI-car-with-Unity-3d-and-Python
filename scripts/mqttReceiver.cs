using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

public class mqttReceiver : MonoBehaviour
{
    public float range= 7;
    public GUIStyle style;
    public float Distance;
    public float a1, a2, a3,a4;

    private MqttClient mqttClient;
    private string brokerAddress = "mqtt.eclipseprojects.io"; // Replace with your MQTT broker address
    private string clientId = "UnityPublisher";
    private string topic = "testtopic";
    private bool messageReceived = true;

    Vector3 car ;

    void Start()

    {
        // Create new instance of MqttClient
        mqttClient = new MqttClient(brokerAddress);

        // Register to message received event
        mqttClient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

        // Connect to broker
        mqttClient.Connect(clientId);

        // Subscribe to topic
        mqttClient.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
    }
    void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {
        string message = Encoding.UTF8.GetString(e.Message);
        Debug.Log("Received message: " + message);
        messageReceived = true;
        if (message=="reset")
        {
            
            transform.position = car;
 
        }
    }

    void reset()
    {
        transform.position= car;
    }

    void Update()
    {

      if (messageReceived)
      {
        // List<int> numbers = new List<int>();
        float angleDegrees = 0;
        Quaternion rotation = Quaternion.Euler(0f, angleDegrees, 0f);
        Vector3 rayDirection = rotation * transform.forward;

        Ray ray_angle = new Ray(transform.position, rayDirection);

        if (Physics.Raycast(ray_angle, out RaycastHit hit , range))
        {
            Debug.DrawRay(ray_angle.origin, ray_angle.direction * range, Color.red);
            a1 = (float)Math.Round(hit.distance-2,2);
        
        }
        else
        {
            Debug.DrawRay(ray_angle.origin, ray_angle.direction * range, Color.green);
            a1=10;
        }

        float angleDegrees1 = 25;
        Quaternion rotation1 = Quaternion.Euler(0f, angleDegrees1, 0f);
        Vector3 rayDirection1 = rotation1 * transform.forward;

        Ray ray_angle1 = new Ray(transform.position, rayDirection1);

        if (Physics.Raycast(ray_angle1, out RaycastHit hit1 , range))
        {
            Debug.DrawRay(ray_angle1.origin, ray_angle1.direction * range, Color.red);
            a2 =(float)Math.Round(hit1.distance-2,2);
        }
        else
        {
            Debug.DrawRay(ray_angle1.origin, ray_angle1.direction * range, Color.green);
            a2=10;
        }

        float angleDegrees2 = -25;
        Quaternion rotation2 = Quaternion.Euler(0f, angleDegrees2, 0f);
        Vector3 rayDirection2 = rotation2 * transform.forward;

        Ray ray_angle2 = new Ray(transform.position, rayDirection2);

        if (Physics.Raycast(ray_angle2, out RaycastHit hit2 , range))
        {
            Debug.DrawRay(ray_angle2.origin, ray_angle2.direction * range, Color.red);
            a3 = (float)Math.Round(hit2.distance-2,2);
        }
        else
        {
            Debug.DrawRay(ray_angle2.origin, ray_angle2.direction * range, Color.green);
            a3=10;
        }

        string message = string.Format("{0},{1},{2}", a1, a2, a3);

        // string positionString = transform.position.x.ToString() + "," + transform.position.y.ToString() + "," + transform.position.z.ToString();      
        
        a4 = (float)Math.Round(transform.position.z);
        
        string positionString = a4.ToString();
        byte[] messageBytes = Encoding.UTF8.GetBytes(positionString);

        byte[] messages = Encoding.UTF8.GetBytes(message);

        mqttClient.Publish("topic", messages);
        Thread.Sleep(50);
        mqttClient.Publish("topic", messageBytes);
        Thread.Sleep(50);

        messageReceived = false;

      }
      
    }
    void OnDestroy()
    {
        mqttClient.Disconnect();
    }
   

}

 