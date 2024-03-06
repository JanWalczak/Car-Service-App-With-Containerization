::docker login -u mikolajuaim
:: -p haslouaim

docker rmi mikolajuaim/application:ssjw-eautoservice-webmechanicapplication_linux

docker build -f ../Ssjw.EAutoService.WebMechanicApp.BlazorServer/Dockerfile.prod -t mikolajuaim/application:ssjw-eautoservice-webmechanicapplication_linux ..

docker images

docker image ls --filter label=stage=ssjw-eautoservice-webmechanicapplication_build

docker image prune --filter label=stage=ssjw-eautoservice-webmechanicapplication_build --force

docker push mikolajuaim/application:ssjw-eautoservice-webmechanicapplication_linux

docker images

::docker logout

pause
