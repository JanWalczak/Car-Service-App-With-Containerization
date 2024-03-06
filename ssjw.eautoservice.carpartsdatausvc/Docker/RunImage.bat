::docker login -u mikolajuaim

docker ps -a

docker stop carpartsusvc

docker ps 

docker images

::docker pull mikolajuaim/application:ssjw-eautoservice-carpartsusvc

docker run --name carpartsusvc -p 5011:80 -p 5012:443 -it mikolajuaim/application:ssjw-eautoservice-carpartsusvc

pause

docker stop carpartsusvc

docker rm carpartsusvc

pause
