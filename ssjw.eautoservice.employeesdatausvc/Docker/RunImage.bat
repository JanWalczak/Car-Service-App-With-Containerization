::docker login -u mikolajuaim

docker ps -a

docker stop employeesusvc

docker ps 

docker images

::docker pull mikolajuaim/application:ssjw-eautoservice-employeesusvc

docker run --name employeesusvc -p 5017:80 -p 5018:443 -it mikolajuaim/application:ssjw-eautoservice-employeesusvc

pause

docker stop employeesusvc

docker rm employeesusvc

pause
