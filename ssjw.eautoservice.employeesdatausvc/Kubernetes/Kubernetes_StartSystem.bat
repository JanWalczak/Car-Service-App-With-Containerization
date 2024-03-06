kubectl apply -f carpartsusvc-deployment.yaml,carpartsusvc-service.yaml,carsusvc-deployment.yaml,carsusvc-service.yaml,clientsusvc-deployment.yaml,clientsusvc-service.yaml,compose2-default-networkpolicy.yaml,employeesusvc-deployment.yaml,employeesusvc-service.yaml,servicesusvc-deployment.yaml,servicesusvc-service.yaml,webapplication-deployment.yaml,webapplication-service.yaml,webmechanicapp-deployment.yaml,webmechanicapp-service.yaml,webclientapplication-deployment.yaml,webclientapplication-service.yaml,webclientapp-deployment.yaml,webclientapp-service.yaml

start http://localhost:30080
start http://localhost:30081

pause

kubectl get services

kubectl get deployments

kubectl get pods

pause


