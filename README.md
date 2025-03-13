# Overview

The clime repository demonstrates how to call a .net console application using GitHub Action workflows and composite actions.  Composite actions were used to demonstrate how to run the clistub tool in a step.  The composite action can be easily converted to a GitHub workflow and ran as a job.  See the official GitHub documentation on workflows and composite actions [here](https://docs.github.com/en/actions/sharing-automations/avoiding-duplication).

## Prerequisites
- Microsoft Entra ID app (documentation [here](https://learn.microsoft.com/en-us/rest/api/fabric/articles/get-started/create-entra-app))
- Create GitHub repository secrets (info [here](#github-repository-environments) and [here](#github-repository-secrets))

###
At this time, you must grant *Contributor* access to all Microsoft Fabric Workspaces in which the Microsoft Entra ID app will access (more infor [here](https://stackoverflow.com/a/78230630)).
- For relevant Fabric Grant Contributor Access to Microsoft Entra ID app

## Workflows

### deploy-develop-push.yml
GitHub workflow that checkouts out the repository and calls the [action-run-deployment-cli-tool/action.yml](.github/actions/action-run-deployment-cli-tool/action.yml).  This workflow is triggered on push to the develop branch or any branches that begin with ```feature```.

### deploy-main-push.yml
GitHub workflow that checkouts out the repository and calls the [action-run-deployment-cli-tool/action.yml](.github/actions/action-run-deployment-cli-tool/action.yml).  This workflow is triggered on push to the main branch.

## Composite Actions

### action-run-deployment-cli-tool
GitHub composite action that installs dotnet based upon an environment variable, prints out the dotnet version installed and runs the ```clistub``` command-line interface.

## Application

### clistub
clistub is a very basic/stub ```.net 8``` application that accepts two parameters and prints them out.

### clistub Parameters
- name - A name.
- age - An age.

## GitHub Repository Environments
- development
- production

### GitHub Repository Secrets
- SERVICE_PRINCIPAL_AUTH_TENANT_ID
- SERVICE_PRINCIPAL_AUTH_CLIENT_ID
- SERVICE_PRINCIPAL_AUTH_CLIENT_SECRET
