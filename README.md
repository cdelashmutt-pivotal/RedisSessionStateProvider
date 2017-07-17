# Redis Session Provider Example

This repo contains an example solution for using Redis as a session provider with an ASP.NET 4 app in Cloud Foundry.

## Building
1. Build the solution in Visual Studio.
2. Publish the `RedisSessionStateProvider` project using the `FolderProfile` profile.

## Deploying

### Create a Redis Service Instance
Create either a Redis Enterprise or a Pivotal Redis Service instance called `session-replication`.
Here's an example for using Pivotal Redis:
```
cf create-service p-redis shared-vm session-replication
```
### Deploy the application
From the `publish` directory under the RedisSessionStateProvider solution:
```
cf push
```

## Testing
Navigate to the URL bound to your app in the browser.  The returned page will show the instance ID of the application your browser was routed to.  You can add some data to the session by entering a value in the text field and clicking "Save".

Next, you can scale up your app to multiple instances with the following command:
```
cf scale redis-session -i 2
```
Once the second instance is started and healthy, refresh your browser a few times until you can see the index id changing.  You should see your session data across both instances of your app, and changing using once instance should show the data updated in all instances.