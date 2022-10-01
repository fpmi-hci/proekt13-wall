FROM golang:1.18-alpine AS builder

WORKDIR /app

ADD . ./

RUN apk update && apk add git

RUN go mod download && go mod verify

RUN go build -o gateway ./cmd

FROM alpine:latest

WORKDIR /app
COPY --from=builder /app/gateway  /app/

CMD ["./gateway"]