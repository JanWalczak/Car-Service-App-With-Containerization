::docker login -u mikolajuaim
:: -p haslouaim

docker rmi mikolajuaim/application:ssjw-eautoservice-webmechanicapplication_dev

docker build -f ../Ssjw.EAutoService.WebMechanicApp.BlazorServer/Dockerfile.dev -t mikolajuaim/application:ssjw-eautoservice-webmechanicapplication_dev ..

docker images

docker image ls --filter label=stage=ssjw-eautoservice-webmechanicapplication_dev_build

docker image prune --filter label=stage=ssjw-eautoservice-webmechanicapplication_dev_build --force

docker push mikolajuaim/application:ssjw-eautoservice-webmechanicapplication_dev

docker images

::docker logout

pause
