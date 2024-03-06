::docker login -u mikolajuaim
:: -p haslouaim

docker rmi mikolajuaim/application:ssjw-eautoservice-webclientapp

docker build -f ../Dockerfile -t mikolajuaim/application:ssjw-eautoservice-webclientapp ..

docker images

docker image ls --filter label=stage=mikolajuaim/application:ssjw-eautoservice-webclientapp_build

docker image prune --filter label=stage=mikolajuaim/application:ssjw-eautoservice-webclientapp_build --force

docker push mikolajuaim/application:ssjw-eautoservice-webclientapp

docker images

::docker logout

pause
