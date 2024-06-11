#!/bin/bash
docker compose -f docker-compose.yaml down
git pull
docker compose build workingtimeweb
docker compose -f docker-compose.yaml up -d
