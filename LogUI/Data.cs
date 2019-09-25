using System;
using UnityEngine;

namespace LogUI
{
	[Serializable]
	public struct Data
	{
		public string text;
		public long time;
		public string timeString;
		public LogType logType;
		public string stackTrace;
		public string guid;

		public Data(string text, string stackTrace, LogType logType = LogType.Log, string timeFormat = "MM-dd HH:mm:ss.fff")
		{
			this.text = text;
			this.time = DateTime.Now.Ticks;
			this.timeString = new DateTime(this.time).ToString(timeFormat);
			this.logType = logType;
			this.stackTrace = stackTrace;
			this.guid = Client.GUID;
		}

		public override string ToString()
		{
			return string.Format("{0}\n{1}", text, stackTrace);
		}
	}
}