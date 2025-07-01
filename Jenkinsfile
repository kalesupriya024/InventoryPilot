pipeline {
    agent any
    tools {
        dotnet 'dotnet-sdk-9'
    }

    stages {
        stage('Restore') {
            steps {
                bat 'dotnet restore InventoryPilot.Domain.sln'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build InventoryPilot.Domain.sln --configuration Release'
            }
        }

        stage('Test') {
            steps {
                bat 'dotnet test InventoryPilot.Domain.sln --no-build'
            }
        }
    }
}