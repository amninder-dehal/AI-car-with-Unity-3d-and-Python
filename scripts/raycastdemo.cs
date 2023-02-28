// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.Net;
// using System.Net.Sockets;
// using System.Text;
// using System.Threading;
// // 

// public class raycastdemo : MonoBehaviour
// {
//     public float range= 7;
//     public GUIStyle style;
//     public float Distance;
//     public float a1, a2, a3;

//     // Socket variables
//     // private Socket sender;
//     // private IPAddress ipAddress;
//     // private IPEndPoint remoteEP;
//     // private IPEndPoint endPoint;


//     void Start()
//     {



//         // string server = "192.168.1.10";
//         // int port = 4000;
//         // sender = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
//         // endPoint = new IPEndPoint(IPAddress.Parse(server), port);
        

//     }

//     void Update()
//     {
//         // List<int> numbers = new List<int>();
//         float angleDegrees = 0;
//         Quaternion rotation = Quaternion.Euler(0f, angleDegrees, 0f);
//         Vector3 rayDirection = rotation * transform.forward;

//         Ray ray_angle = new Ray(transform.position, rayDirection);

//         if (Physics.Raycast(ray_angle, out RaycastHit hit , range))
//         {
//             Debug.DrawRay(ray_angle.origin, ray_angle.direction * range, Color.red);
//             a1 = (float)Math.Round(hit.distance-2,2);
        
//         }
//         else
//         {
//             Debug.DrawRay(ray_angle.origin, ray_angle.direction * range, Color.green);
//             a1=10;
//         }

//         float angleDegrees1 = 25;
//         Quaternion rotation1 = Quaternion.Euler(0f, angleDegrees1, 0f);
//         Vector3 rayDirection1 = rotation1 * transform.forward;

//         Ray ray_angle1 = new Ray(transform.position, rayDirection1);

//         if (Physics.Raycast(ray_angle1, out RaycastHit hit1 , range))
//         {
//             Debug.DrawRay(ray_angle1.origin, ray_angle1.direction * range, Color.red);
//             a2 =(float)Math.Round(hit1.distance-2,2);
//         }
//         else
//         {
//             Debug.DrawRay(ray_angle1.origin, ray_angle1.direction * range, Color.green);
//             a2=10;
//         }

//         float angleDegrees2 = -25;
//         Quaternion rotation2 = Quaternion.Euler(0f, angleDegrees2, 0f);
//         Vector3 rayDirection2 = rotation2 * transform.forward;

//         Ray ray_angle2 = new Ray(transform.position, rayDirection2);

//         if (Physics.Raycast(ray_angle2, out RaycastHit hit2 , range))
//         {
//             Debug.DrawRay(ray_angle2.origin, ray_angle2.direction * range, Color.red);
//             a3 = (float)Math.Round(hit2.distance-2,2);
//         }
//         else
//         {
//             Debug.DrawRay(ray_angle2.origin, ray_angle2.direction * range, Color.green);
//             a3=10;
//         }


//         string message = string.Format("{0},{1},{2}", a1, a2, a3);

//         // byte[] data = Encoding.UTF8.GetBytes(message);
//         // sender.SendTo(data, endPoint);
//         // Thread.Sleep(10);

                
//     }

  

//     void OnDestroy () 
//     {

//     }
// }

 