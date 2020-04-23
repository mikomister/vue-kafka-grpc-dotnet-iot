FROM node:lts-alpine

RUN apk add --update --no-cache bash curl git grpc protoc protobuf && \
  rm -rf /var/cache/apk/*

ENV GRPC_WEB_VERSION=1.0.7
RUN curl -sSL \
  https://github.com/grpc/grpc-web/releases/download/${GRPC_WEB_VERSION}/protoc-gen-grpc-web-${GRPC_WEB_VERSION}-linux-x86_64 \
  -o /usr/local/bin/protoc-gen-grpc-web && \
  chmod +x /usr/local/bin/protoc-gen-grpc-web


RUN npm install -g http-server && npm install -g node-pre-gyp

WORKDIR /app
COPY package*.json ./

RUN npm install
COPY . .

EXPOSE 8080
