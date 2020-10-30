using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class PredefinedBuildConfigs {
	public static BuildSequence testingSequence;
	public static BuildSequence releaseLocalSequence;
	public static BuildSequence releaseLocalZipSequence;
	public static BuildSequence releaseLocalZipItchSequence;
	public static BuildSequence passbySequence;

	public static BuildData[] standaloneData = new BuildData[] { 
		new BuildData(UnityEditor.BuildTargetGroup.Standalone, UnityEditor.BuildTarget.StandaloneWindows){ itchChannel = "windows-32" },
		new BuildData(UnityEditor.BuildTargetGroup.Standalone, UnityEditor.BuildTarget.StandaloneWindows64){ itchChannel = "windows-64" },
		new BuildData(UnityEditor.BuildTargetGroup.Standalone, UnityEditor.BuildTarget.StandaloneLinux64){ itchChannel = "linux-universal" },
		new BuildData(UnityEditor.BuildTargetGroup.Standalone, UnityEditor.BuildTarget.StandaloneOSX){ itchChannel = "osx-universal" },
	};

	public static BuildData[] webData = new BuildData[] {
		new BuildData(UnityEditor.BuildTargetGroup.WebGL, UnityEditor.BuildTarget.WebGL){ middlePath = "$NAME_$VERSION_$PLATFORM/", itchChannel = "webgl"},
	};

	public static BuildData[] androidData = new BuildData[] {
		new BuildData(UnityEditor.BuildTargetGroup.Android, UnityEditor.BuildTarget.Android){ middlePath = "$NAME_$VERSION_$PLATFORM$EXECUTABLE", itchDirPath = "$NAME_$VERSION_$PLATFORM$EXECUTABLE", itchChannel = "android"},
	};

	static PredefinedBuildConfigs() {
		EditorApplication.update += Init;
	}

	public static void Init() {
		EditorApplication.update -= Init;

		List<BuildData> data = new List<BuildData>();
		foreach (BuildData buildData in standaloneData) {
			data.Add(buildData.Clone() as BuildData);
		}
		foreach (BuildData buildData in webData) {
			data.Add(buildData.Clone() as BuildData);
		}
		foreach (BuildData buildData in androidData) {
			data.Add(buildData.Clone() as BuildData);
		}

		testingSequence = new BuildSequence("Testing", $"teamon/{BuildManager.GetProductName()}", data.ToArray());

		for (int i = 0; i < data.Count; ++i) {
			data[i] = data[i].Clone() as BuildData;
		}
		releaseLocalSequence = new BuildSequence("Release", $"teamon/{BuildManager.GetProductName()}", data.ToArray());

		for (int i = 0; i < data.Count; ++i) {
			data[i] = data[i].Clone() as BuildData;
			data[i].needZip = true;
		}
		releaseLocalZipSequence = new BuildSequence("Release + zip", $"teamon/{BuildManager.GetProductName()}", data.ToArray());

		for (int i = 0; i < data.Count; ++i) {
			data[i] = data[i].Clone() as BuildData;
			data[i].needZip = true;
			data[i].needItchPush = true;
		}
		releaseLocalZipItchSequence = new BuildSequence("Release full", $"teamon/{BuildManager.GetProductName()}", data.ToArray());

		for (int i = 0; i < data.Count; ++i) {
			data[i] = data[i].Clone() as BuildData;
			data[i].isPassbyBuild = true;
			data[i].needZip = true;
			data[i].needItchPush = true;
		}
		passbySequence = new BuildSequence("Passby local release", $"teamon/{BuildManager.GetProductName()}", data.ToArray());
	}
}
