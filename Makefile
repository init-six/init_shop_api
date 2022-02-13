VERSION := $(shell git describe --tags --always --dirty)
REGISTRY := evanfordocker/init-api-server

image:
	docker build -t $(REGISTRY) -f Dockerfile .

push:
	docker image push $(REGISTRY):$(VERSION)

clean:
	dotnet clean

test:
	dotnet test

format:
	dotnet format
