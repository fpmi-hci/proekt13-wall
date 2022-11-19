FROM golang:1.18-alpine AS builder

WORKDIR /app

ADD . ./

RUN go mod download && go mod verify

RUN go build -o notification ./cmd

FROM alpine:latest

WORKDIR /app
COPY --from=builder /app/notification  /app/

CMD ["./notification"]