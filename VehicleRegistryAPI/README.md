# Fleet of Knowledge

How to run this project locally: 

- Login into docker with command
```shell
docker login
```

run the image application with 

```shell
docker run natalialele/fleet-of-knowledge
```

run the command with `-p` flag to correctly map the docker container's **port** to my local machine 

`docker run -p 8080:8080 natalialele/fleet-of-knowledge
`

Access with the following link:
http://localhost:8080/swagger/index.html