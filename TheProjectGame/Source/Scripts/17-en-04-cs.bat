start "CommunicationServer" ".\..\CommunicationServer\CommunicationServer\CommunicationServer\bin\Debug\CommunicationServer.exe" "17-EN-04-cs" "--port" "8001" "--conf" ".\CommunicationServerSettings.xml"
rem timeout 1
rem start "GameMaster" ".\..\GameMaster\GameMaster\GameMaster\bin\Debug\GameMaster.exe" "17-EN-04-cs" "--address" "192.168.0.14" "--port" "8000" "--conf" ".\..\GameMaster\GameMaster\GameMaster\GameMasterSettingsTest.xml"
rem timeout 2
rem start "Player" ".\..\Player\Player\Player\bin\Debug\Player.exe" "17-EN-04-cs" "--address" "192.168.0.14" "--port" "8000" "--conf" ".\..\Player\Player\Player\PlayerSettingsTest.xml" "--game" "Initial test game" "--team" "red" "--role" "member"
rem start "Player" ".\..\Player\Player\Player\bin\Debug\Player.exe" "17-EN-04-cs" "--address" "192.168.0.14" "--port" "8000" "--conf" ".\..\Player\Player\Player\PlayerSettingsTest.xml" "--game" "Initial test game" "--team" "blue" "--role" "member"
