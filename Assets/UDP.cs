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
    private Emoji emoji;

    void Start()
    {
        udpClient = new UdpClient(5005);
        endPoint = new IPEndPoint(IPAddress.Any, 5005);
        udpClient.BeginReceive(new AsyncCallback(OnUdpDataReceived), null);

        alphabet = GetComponent<alphabet>();
        emoji = GetComponent<Emoji>();

        if (alphabet == null && emoji == null)
        {
            Debug.LogError("Alphabet or Emoji script is required.");
        }
        else if (alphabet != null)
        {
            Debug.Log("アルファベットシーン");
        }
        else if (emoji != null)
        {
            Debug.Log("絵文字シーン");
        }
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
                        if (receivedCounts[i] > 30)
                        {
                            receivedCounts[i] = 30;
                        }
                        if (alphabet != null)
                        {
                            alphabet.CreateAlphabet(i + 1, receivedCounts[i]);
                        }
                        else if (emoji != null)
                        {
                            emoji.CreateEmoji(i + 1, receivedCounts[i]);
                        }
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
