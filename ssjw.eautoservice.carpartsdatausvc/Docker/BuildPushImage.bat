::docker login -u mikolajuaim
:: -p haslouaim

docker rmi mikolajuaim/application:ssjw-eautoservice-carpartsusvc

docker build -f ../Dockerfile -t mikolajuaim/application:ssjw-eautoservice-carpartsusvc .

docker images

docker push mikolajuaim/application:ssjw-eautoservice-carpartsusvc

docker images

::docker logout

pause
