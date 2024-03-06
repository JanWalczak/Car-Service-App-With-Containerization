::docker login -u mikolajuaim

docker ps -a

docker stop servicesusvc

docker ps 

docker images

::docker pull mikolajuaim/application:ssjw-eautoservice-servicesusvc

docker run --name servicesusvc -p 5019:80 -p 5020:443 -it mikolajuaim/application:ssjw-eautoservice-servicesusvc

pause

docker stop servicesusvc

docker rm servicesusvc

pause
