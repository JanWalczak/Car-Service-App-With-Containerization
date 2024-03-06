::docker login -u mikolajuaim
:: -p haslouaim

docker rmi mikolajuaim/application:ssjw-eautoservice-employeesusvc

docker build -f ../Dockerfile -t mikolajuaim/application:ssjw-eautoservice-employeesusvc ..

docker images

docker image ls --filter label=stage=mikolajuaim/application:ssjw-eautoservice-employeesusvc_build

docker image prune --filter label=stage=mikolajuaim/application:ssjw-eautoservice-employeesusvc_build --force

docker push mikolajuaim/application:ssjw-eautoservice-employeesusvc

docker images

::docker logout

pause
