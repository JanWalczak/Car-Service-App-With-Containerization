::docker login -u mikolajuaim

docker ps -a

docker stop webmechanicapp

docker ps 

docker images

::docker pull mikolajuaim/application:ssjw-eautoservice-webmechanicapp

docker run --name webmechanicapp -p 5002:80 -p 5003:443 -it mikolajuaim/application:ssjw-eautoservice-webmechanicapp

pause

docker stop webmechanicapp

docker rm webmechanicapp

pause
