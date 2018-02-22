rem start "CommunicationServer" ".\..\CommunicationServer\CommunicationServer\CommunicationServer\bin\Debug\CommunicationServer.exe" "17-EN-04-cs" "--port" "8000" "--conf" ".\..\CommunicationServer\CommunicationServer\CommunicationServer\CommunicationServerSettingsTest.xml"
timeout 1
rem start "GameMaster" ".\..\GameMaster\GameMaster\GameMaster\bin\Debug\GameMaster.exe" "17-EN-04-cs" "--address" "127.0.0.1" "--port" "8000" "--conf" ".\..\GameMaster\GameMaster\GameMaster\GameMasterSettingsTest.xml"

start "Player" ".\..\Player\Player\Player\bin\Debug\Player.exe" "17-EN-04-cs" "--address" "192.168.143.100" "--port" "8001" "--conf" ".\PlayerSettings.xml" "--game" "ChampionshipEn" "--team" "red" "--role" "member"
timeout 1
start "Player" ".\..\Player\Player\Player\bin\Debug\Player.exe" "17-EN-04-cs" "--address" "192.168.143.100" "--port" "8001" "--conf" ".\PlayerSettings.xml" "--game" "ChampionshipEn" "--team" "blue" "--role" "member"
