# businessrulesAPI

### Build image
```script
sudo docker build -t rulesengine .
```

### Run docker image
```script
sudo docker run -d -p 8080:80 --name rulesengine rulesengine
```

### List docker containers
```script
sudo docker container ls -a
```