using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

namespace LogUI
{
	public class Client
	{
		private const string IP = "127.0.0.1";
		private const int PORT = 12997;

		private static string guid = null;

		public static string GUID
		{
			get
			{
				if (string.IsNullOrEmpty(guid))
				{
					var ticks = DateTime.Now.Ticks.ToString();
					guid = ticks.Substring(ticks.Length - 4, 4);
				}

				return guid;
			}
		}

		private static NetworkClient client;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		public static void Initialize()
		{
			client = new NetworkClient();
			client.RegisterHandler(MsgType.Connect, OnConnected);
			client.RegisterHandler(MsgType.Error, OnError);
			client.Connect(IP, PORT);
		}

		private static void Application_logMessageReceived(string condition, string stackTrace, LogType type)
		{
			//var data = new Data(condition, StackTraceUtility.ExtractStackTrace(), type);
			var data = new Data(condition, stackTrace, type);
			Log(data);
		}

		private static void Log(Data data)
		{
			string jsonStr = JsonUtility.ToJson(data);
			client.Send(MsgType.Highest + 1, new StringMessage(jsonStr));
		}

		private static void OnError(NetworkMessage netMsg)
		{
			var msg = netMsg.ReadMessage<StringMessage>();
			Debug.Log("Connected Failed - " + msg.value);
		}

		private static void OnConnected(NetworkMessage netMsg)
		{
			Application.logMessageReceived += Application_logMessageReceived;
			Debug.developerConsoleVisible = false;

			Debug.Log("LogUI Initialize - " + GUID);
		}
	}
}