using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class PacketReceiver : MonoBehaviour {

    [SerializeField]
    private int port = 8080;

    private Thread readThread;
    private UdpClient client;
    private string text;
    private IPEndPoint remoteEP;
    private bool flag = false;

    public String Data
    {
        get { return text; }
    }

    private void Start()
    {
        readThread = new Thread(new ThreadStart(ReceiveData));
        readThread.IsBackground = true;
        readThread.Start();
    }

    private void ReceiveData()
    {
        remoteEP = new IPEndPoint(IPAddress.Any, 0);
        client = new UdpClient(port);

        while(true)
        {
            byte[] receivedBytes = client.Receive(ref remoteEP);
            text = Encoding.ASCII.GetString(receivedBytes);
        }
    }

    private void OnApplicationQuit()
    {
        stopThread();
    }

    private void stopThread()
    {
        if (readThread.IsAlive)
        {
            readThread.Abort();
        }
        client.Close();
    }
}
