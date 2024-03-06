::docker login -u mikolajuaim
:: -p haslouaim

docker rmi mikolajuaim/application:ssjw-eautoservice-webclientapplication

docker build -f ../Dockerfile -t mikolajuaim/application:ssjw-eautoservice-webclientapplication ..

docker images

docker image ls --filter label=stage=mikolajuaim/application:ssjw-eautoservice-webclientapplication_build

docker image prune --filter label=stage=mikolajuaim/application:ssjw-eautoservice-webclientapplication_build --force

docker push mikolajuaim/application:ssjw-eautoservice-webclientapplication

docker images

::docker logout

pause
