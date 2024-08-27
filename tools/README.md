1. If you are running on Linux, run command below to set permissions
```
chown 10001:0 ../data/
```

2. Start necessary tools
```
docker network create keyboard-network
docker compose up -d
```
