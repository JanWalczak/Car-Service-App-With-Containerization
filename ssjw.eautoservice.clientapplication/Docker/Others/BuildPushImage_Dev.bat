::docker login -u mikolajuaim
:: -p <password>

docker rmi mikolajuaim/application:ssjw-eautoservice-webclientapplication_dev

docker build -f ../Ssjw.EAutoService.ClientApplication.BlazorServer/Dockerfile.dev -t mikolajuaim/application:ssjw-eautoservice-webclientapplication_dev ..

docker images

docker image ls --filter label=stage=ssjw-eautoservice-webclientapplication_dev_build

docker image prune --filter label=stage=ssjw-eautoservice-webclientapplication_dev_build --force

docker push mikolajuaim/application:ssjw-eautoservice-webclientapplication_dev

docker images

::docker logout

pause
