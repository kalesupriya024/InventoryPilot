pipeline {
    agent any
    tools {
        dotnetsdk 'dotnet-sdk-9'
    }

    stages {
        stage('Environment Check') {
            steps {
                bat 'dotnet --info'
                bat 'dir'
            }
        }

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
