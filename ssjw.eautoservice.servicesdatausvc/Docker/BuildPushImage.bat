::docker login -u mikolajuaim
:: -p haslouaim

docker rmi mikolajuaim/application:ssjw-eautoservice-servicesusvc

docker build -f ../Dockerfile -t mikolajuaim/application:ssjw-eautoservice-servicesusvc ..

docker images

docker image ls --filter label=stage=mikolajuaim/application:ssjw-eautoservice-servicesusvc_build

docker image prune --filter label=stage=mikolajuaim/application:ssjw-eautoservice-servicesusvc_build --force

docker push mikolajuaim/application:ssjw-eautoservice-servicesusvc

docker images

::docker logout

pause
