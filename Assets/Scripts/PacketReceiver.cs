using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class PacketReceiver : MonoBehaviour {

    [SerializeField]
    private int port = 8080;
    [SerializeField]
    private string host = "192.168.0.2";

    private UdpClient client;
    private string text;
    private IPEndPoint remoteEP;
    private bool flag = false;

    public String Data
    {
        get { return text; }
    }

    void Start()
    {
        Debug.Log("Starting Client");
        remoteEP = new IPEndPoint(IPAddress.Any, 0);
        client = new UdpClient(port);
        //client.JoinMulticastGroup(groupIP);
        client.Client.Blocking = false;
        client.BeginReceive(new AsyncCallback(ReceiveServerInfo), null);

    }

    private void Update()
    {
        if(flag)
        {
            client.BeginReceive(new AsyncCallback(ReceiveServerInfo), null);
            flag = false;
        }
    }

    void ReceiveServerInfo(IAsyncResult result)
    {
        //Debug.Log("Received Server Info");
        byte[] receivedBytes = client.EndReceive(result, ref remoteEP);

        text = Encoding.ASCII.GetString(receivedBytes);

        // show received message
        //if (text != null && text != "")
        //    Debug.Log(">> " + text);
        flag = true;
    }
}
