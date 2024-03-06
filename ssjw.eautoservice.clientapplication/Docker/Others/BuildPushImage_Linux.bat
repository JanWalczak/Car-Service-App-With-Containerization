::docker login -u mikolajuaim
:: -p <password>

docker rmi mikolajuaim/application:ssjw-eautoservice-webclientapplication_linux

docker build -f ../Ssjw.EAutoService.ClientApplication.BlazorServer/Dockerfile.prod -t mikolajuaim/application:ssjw-eautoservice-webclientapplication_linux ..

docker images

docker image ls --filter label=stage=ssjw-eautoservice-webclientapplication_build

docker image prune --filter label=stage=ssjw-eautoservice-webclientapplication_build --force

docker push mikolajuaim/application:ssjw-eautoservice-webclientapplication_linux

docker images

::docker logout

pause
