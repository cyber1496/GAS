# Unity project that receives spreadsheet information from Google API on Json

## This program needs to download some Asset from AssetStore. Check the following files.
- "Assets/WanzyeeStudio/README.md"

## How to prepare and execute the sample.

### basic configuration.
	- 1. Upload "Assets/Cyber/GAS/Examples/TestData.xlsx" to GoogleDrive.
	- 2. Write the URL of [1.] In the ID of "Resources/GAS/SettingData.asset"
	- 3. Register "Assets/Cyber/GAS/Scripts/GoogleAppsScript/GetJson.gs" in the ScriptEditor of [1].
	- 4. Publish [3] as a Web application from ScriptEditor.
	- 5. Write the URL of Web Application in the URL "Resources/GAS/SettingData.asset".

### When receiving spreadsheet information using UnityWebRequest during scene playback.
	- 1. Execute "Assets/Cyber/GAS/Examples/SheetToSimpleClass.unity".

### In case of receiving spreadsheet information using ScriptableObject from WWW from editor program.
	- 1. Select "Cyber/GAS/Examples/SyncScriptableObject" from the menu bar.
	- 2. Press the "Sync" button in the editor window opened with [1.].
	- 3. * The following logs are displayed at execution. Clear solutions have not been found so far.
	- Unsupported encoding: 'UTF - 8, application/json'

[JPN]
# GoogleAPIScriptからスプレッドシートの情報をJsonで受け取るUnityプロジェクト

## このプログラムは一部AssetStoreからAssetダウンロードする必要があります。以下のファイルを確認してください。
	 - "Assets/WanzyeeStudio/README.md"

## サンプルの準備および実行方法。

### 基本設定。
	 - 1."Assets/Cyber/GAS/Examples/TestData.xlsx" を GoogleDriveにアップロードする。
	 - 2.[1.]のURLを"Resources/GAS/SettingData.asset"のIDに記入する
	 - 3."Assets/Cyber/GAS/Scripts/GoogleAppsScript/GetJson.gs" を [1.]の ScriptEditorに登録する。
	 - 4.ScriptEditorから [3.]をWebApplicationとして公開する。
	 - 5.WebApplicationのURLを"Resources/GAS/SettingData.asset"のURLに記入する。

### シーン再生時にUnityWebRequestを用いてスプレッドシートの情報を受け取る場合。
	 - 1."Assets/Cyber/GAS/Examples/SheetToSimpleClass.unity" を実行する。

### エディタプログラムからScriptableObjectをWWWを用いてスプレッドシートの情報を受け取る場合。
	 - 1.メニューバーから"Cyber/GAS/Examples/SyncScriptableObject"を選択する。
	 - 2.[1.]で開いたエディタウインドウの"Sync"ボタンを押す。
	 - 3.※実行時、次のログが表示されます。明確な解決策が今のところ見つかっておりません。
		 - Unsupported encoding: 'UTF-8,application/json'