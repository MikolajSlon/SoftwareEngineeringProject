rem start "CommunicationServer" ".\..\CommunicationServer\CommunicationServer\CommunicationServer\bin\Debug\CommunicationServer.exe" "17-EN-04-cs" "--port" "8000" "--conf" ".\..\CommunicationServer\CommunicationServer\CommunicationServer\CommunicationServerSettingsTest.xml"
rem timeout 1
start "GameMaster" ".\..\GameMaster\GameMaster\GameMaster\bin\Debug\GameMaster.exe" "17-EN-04-cs" "--address" "192.168.143.100" "--port" "8001" "--conf" ".\Championship.xml"
rem timeout 2
rem start "Player" ".\..\Player\Player\Player\bin\Debug\Player.exe" "17-EN-04-cs" "--address" "192.168.0.14" "--port" "8000" "--conf" ".\..\Player\Player\Player\PlayerSettingsTest.xml" "--game" "Initial test game" "--team" "red" "--role" "member"
rem start "Player" ".\..\Player\Player\Player\bin\Debug\Player.exe" "17-EN-04-cs" "--address" "192.168.0.14" "--port" "8000" "--conf" ".\..\Player\Player\Player\PlayerSettingsTest.xml" "--game" "Initial test game" "--team" "blue" "--role" "member"
