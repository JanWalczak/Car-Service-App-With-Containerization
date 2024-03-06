::docker login -u mikolajuaim
:: -p haslouaim

docker rmi mikolajuaim/application:ssjw-eautoservice-webmechanicapp

docker build -f ../Dockerfile -t mikolajuaim/application:ssjw-eautoservice-webmechanicapp ..

docker images

docker image ls --filter label=stage=mikolajuaim/application:ssjw-eautoservice-webmechanicapp_build

docker image prune --filter label=stage=mikolajuaim/application:ssjw-eautoservice-webmechanicapp_build --force

docker push mikolajuaim/application:ssjw-eautoservice-webmechanicapp

docker images

::docker logout

pause
