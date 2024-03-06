::docker login -u mikolajuaim

docker ps -a

docker stop webclientapplication

docker ps 

docker images

::docker pull mikolajuaim/application:ssjw-eautoservice-webclientapplication

docker run --name webclientapplication -p 5000:80 -p 5001:443 -it mikolajuaim/application:ssjw-eautoservice-webclientapplication

pause

docker stop webclientapplication

docker rm webclientapplication

pause
