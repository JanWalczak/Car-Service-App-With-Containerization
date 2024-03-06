::docker login -u mikolajuaim

docker ps -a

docker stop clientsusvc

docker ps 

docker images

::docker pull mikolajuaim/application:ssjw-eautoservice-clientsusvc

docker run --name clientsusvc -p 5015:80 -p 5016:443 -it mikolajuaim/application:ssjw-eautoservice-clientsusvc

pause

docker stop clientsusvc

docker rm clientsusvc

pause
