package main

import (
	"log"
	"net"

	"github.com/fpmi-hci/proekt13-wall/gateway/internal/config"
	"github.com/fpmi-hci/proekt13-wall/gateway/internal/handler"
	"github.com/gin-gonic/gin"
)

func main() {
	cfg, err := config.Load()
	if err != nil {
		log.Fatal("unable to load config")
	}

	apiHandler := handler.New(cfg)

	eng := gin.New()
	eng.Any("/v1/*service", apiHandler.Handle)
	lis, err := net.Listen("tcp", ":8080")
	if err != nil {
		log.Fatal("cannot listen API Gateway")
	}

	if err = eng.RunListener(lis); err != nil {
		log.Fatal("cannot run API Gateway listener")
	}
}
