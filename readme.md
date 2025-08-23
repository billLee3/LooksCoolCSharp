C# REST API used to store color palletes for various PowerApps developed in my day job. 

API will reside in AWS and communicates with a Postgres database (free tier).

CI/CD pipeline will be through CodeDeploy. 

TODO1: Configure ECR Instance of my docker image. 
TODO2: Connect the database with the ECR instance running on app runner via VPC connector
TODO3: Congifure CodeDeploy.
