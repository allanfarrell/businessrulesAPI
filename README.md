# businessrulesAPI

## Docker Build Instructions

### Build image from Dockerfile
```script
sudo docker build -t rulesengine .
```

### Run docker image
```script
sudo docker run -d -p 8080:80 --name rulesengine rulesengine
```

### Access image
http://localhost:8080/swagger/index.html

# Docker Cheatsheet

### List docker containers
```script
sudo docker ps
```

### View log for a container
```script
sudo docker logs <container_id>
```

### Stop running container
```script
sudo docker stop <container_id>
```

### Remove container
```script
sudo docker rm <container_id>
```