# UnityBuildManager
Utility for running builds sequence &amp; pushing them to itch.io

## Description
'UnityBuildManager' is an asset that can:
 * Run multiple builds
 * Archivate build
 * Push build to itch.io
 * Push build to Github releases
 * Auto optimize release builds for better performace and testing builds for faster build time
 * Maintain defines and options for each build and sequence
 * Keep changelog and readme files
 * Auto add changelog and readme to game folders

![1](https://user-images.githubusercontent.com/30273693/107130827-f99dea80-68d9-11eb-877c-d0240f9ff8ad.png)
![2](https://user-images.githubusercontent.com/30273693/107130826-f86cbd80-68d9-11eb-8e64-586213253870.png)


## Installation
### (For Unity 2018.3 or later) Using OpenUPM  
This package is available on [OpenUPM](https://openupm.com).  
You can install it via [openupm-cli](https://github.com/openupm/openupm-cli).  
```
openupm add com.teamon.buildmanager
```

### (For Unity 2018.3 or later) Using Git
Find the manifest.json file in the Packages folder of your project and add a line to `dependencies` field.
`"com.teamon.buildmanager": "https://github.com/Team-on/UnityBuildManager.git"`
Or, use [UpmGitExtension](https://github.com/mob-sakai/UpmGitExtension) to install and update the package.

#### For Unity 2018.2 or earlier
1. Download a source code zip this page
2. Extract it
3. Import it into the following directory in your Unity project
   - `Packages` (It works as an embedded package. For Unity 2018.1 or later)
   - `Assets` (Legacy way. For Unity 2017.1 or later)
   
#### From Unity Asset Store
1. https://assetstore.unity.com/packages/slug/188940
2. Add it to project as usual


## Usage
1. From the menu, click `Window > Build manager(Alt + B)`.
2. Configurate sequences
3. Enjoy!
