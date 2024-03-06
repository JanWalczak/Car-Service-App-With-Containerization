kubectl apply -f carpartsusvc-deployment.yaml,carpartsusvc-service.yaml,carsusvc-deployment.yaml,carsusvc-service.yaml,clientsusvc-deployment.yaml,clientsusvc-service.yaml,compose2-default-networkpolicy.yaml,employeesusvc-deployment.yaml,employeesusvc-service.yaml,servicesusvc-deployment.yaml,servicesusvc-service.yaml,webclientapplication-deployment.yaml,webclientapplication-service.yaml,webclientapp-deployment.yaml,webclientapp-service.yaml,webapplication-deployment.yaml,webapplication-service.yaml,webmechanicapp-deployment.yaml,webmechanicapp-service.yaml



kubectl rollout restart deployment/carpartsusvc
kubectl rollout restart deployment/carsusvc
kubectl rollout restart deployment/clientsusvc
kubectl rollout restart deployment/employeesusvc
kubectl rollout restart deployment/servicesusvc
kubectl rollout restart deployment/webclientapplication
kubectl rollout restart deployment/webclientapp
kubectl rollout restart deployment/webapplication
kubectl rollout restart deployment/webmechanicapp

pause


