FROM golang:1.18-alpine AS builder

WORKDIR /app

ADD . ./

RUN go mod download && go mod verify

RUN go build -o subscription ./cmd

FROM alpine:latest

WORKDIR /app
COPY --from=builder /app/subscription  /app/

CMD ["./subscription"]