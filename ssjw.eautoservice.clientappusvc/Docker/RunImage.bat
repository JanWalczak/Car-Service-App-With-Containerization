::docker login -u mikolajuaim

docker ps -a

docker stop webclientapp

docker ps 

docker images

::docker pull mikolajuaim/application:ssjw-eautoservice-webclientapp

docker run --name webclientapp -p 5002:80 -p 5003:443 -it mikolajuaim/application:ssjw-eautoservice-webclientapp

pause

docker stop webclientapp

docker rm webclientapp

pause
