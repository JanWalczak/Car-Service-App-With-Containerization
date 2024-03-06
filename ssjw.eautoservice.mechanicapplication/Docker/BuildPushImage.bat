::docker login -u mikolajuaim
:: -p haslouaim

docker rmi mikolajuaim/application:ssjw-eautoservice-webmechanicapplication

docker build -f ../Ssjw.EAutoService.WebMechanicApp.BlazorServer/Dockerfile -t mikolajuaim/application:ssjw-eautoservice-webmechanicapplication ..

docker images

docker image ls --filter label=stage=ssjw-eautoservice-webmechanicapplication_build

docker image prune --filter label=stage=ssjw-eautoservice-webmechanicapplication_build --force

docker push mikolajuaim/application:ssjw-eautoservice-webmechanicapplication

docker images

::docker logout

pause
