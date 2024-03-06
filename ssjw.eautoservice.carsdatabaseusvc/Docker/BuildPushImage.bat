::docker login -u mikolajuaim
:: -p haslouaim

docker rmi mikolajuaim/application:ssjw-eautoservice-carsusvc

docker build -f ../Dockerfile -t mikolajuaim/application:ssjw-eautoservice-carsusvc ..

docker images

docker push mikolajuaim/application:ssjw-eautoservice-carsusvc

docker images

::docker logout

pause
