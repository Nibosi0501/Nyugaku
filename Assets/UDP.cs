using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;
using System.Collections.Generic;

public class UdpReceiver : MonoBehaviour
{
    private UdpClient udpClient;
    private IPEndPoint endPoint;
    private Queue<int[]> receivedDataQueue = new Queue<int[]>(); // 受信データを保持するキュー
    private object queueLock = new object(); // マルチスレッド対応のロック

    private bool isClosing = false; // クラス変数として追加

    private alphabet alphabet;

    void Start()
    {
        udpClient = new UdpClient(5005);
        endPoint = new IPEndPoint(IPAddress.Any, 5005);
        udpClient.BeginReceive(new AsyncCallback(OnUdpDataReceived), null);

        alphabet = GetComponent<alphabet>();
    }

    void OnUdpDataReceived(IAsyncResult result)
    {
        try
        {
            if (isClosing || udpClient == null)
            {
                return; // クローズ中なら処理しない
            }

            byte[] data = udpClient.EndReceive(result, ref endPoint);
            int[] receivedCounts = new int[14];

            for (int i = 0; i < 14; i++)
            {
                receivedCounts[i] = BitConverter.ToInt32(data, i * 4);
            }

            lock (queueLock)
            {
                receivedDataQueue.Enqueue(receivedCounts);
            }

            // もう一度受信を開始する（nullチェックを追加）
            if (!isClosing && udpClient != null)
            {
                udpClient.BeginReceive(new AsyncCallback(OnUdpDataReceived), null);
            }
        }
        catch (Exception ex)
        {
            if (!isClosing) // クローズ中ならエラーを無視
            {
                Debug.LogError($"Error receiving UDP data: {ex.Message}");
            }
        }
    }

    void Update()
    {
        lock (queueLock)
        {
            while (receivedDataQueue.Count > 0)
            {
                int[] receivedCounts = receivedDataQueue.Dequeue();
                for (int i = 0; i < receivedCounts.Length; i++)
                {
                    if (receivedCounts[i] > 0)
                    {
                        alphabet.CreateAlphabet(i + 1, receivedCounts[i]);
                    }
                }
            }
        }
    }

    void OnDestroy()
    {
        CloseUdpClient();
    }

    void OnApplicationQuit()
    {
        CloseUdpClient();
    }

    private void CloseUdpClient()
    {
        if (udpClient != null)
        {
            udpClient.Close();
            udpClient = null;
        }
    }
}
