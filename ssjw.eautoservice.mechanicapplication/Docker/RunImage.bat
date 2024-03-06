::docker login -u mikolajuaim

docker ps -a

docker stop webmechanicapplication

docker ps 

docker images

::docker pull mikolajuaim/application:ssjw-eautoservice-webmechanicapplication

docker run --name webmechanicapplication -p 5000:80 -it mikolajuaim/application:ssjw-eautoservice-webmechanicapplication

pause

docker stop webmechanicapplication

docker rm webmechanicapplication

pause
