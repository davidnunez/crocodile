using UnityEngine;
using System.Collections;
using System;
using System.IO;
public class Funf {
	
	
	static string FILE_NAME = "worldliteracyapp.txt";

	public static void Log(string key, string value) {
		Log ("\"" + key + "\":\"" + value + "\"");
		
	}
	
	
	public static void Log(string json) {
		/*
		long millis = (DateTime.UtcNow-new DateTime (1970, 1, 1)).Ticks/10000;
		//string fileName = Application.persistentDataPath + "/" + FILE_NAME;
		string fileName = "/mnt/sdcard/" + FILE_NAME;
		StreamWriter fileWriter = File.AppendText(fileName);
		string log = millis + "\t" + "{" + json + "}";
		fileWriter.WriteLine(log);
		
		fileWriter.Close();
		 
		Debug.Log (log);
		*/
	}		
		
	
	
}


