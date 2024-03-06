::docker login -u mikolajuaim

docker ps -a

docker stop carsusvc

docker ps 

docker images

::docker pull mikolajuaim/application:ssjw-eautoservice-carsusvc

docker run --name carsusvc -p 5013:80 -p 5014:443 -it mikolajuaim/application:ssjw-eautoservice-carsusvc

pause

docker stop carsusvc

docker rm carsusvc

pause
