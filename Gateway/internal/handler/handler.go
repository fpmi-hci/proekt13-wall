package handler

import (
	"fmt"
	"net/http"
	"strings"

	"github.com/fpmi-hci/proekt13-wall/gateway/internal/config"
	"github.com/gin-gonic/gin"
)

const msgNotFound = "404 Not Found"

// Handler handles all the API requests
type Handler struct {
	config config.Config
}

// New creates a new handler for API Gateway
func New(config config.Config) *Handler {
	return &Handler{config: config}
}

// Handle handles HTTP requests
func (h Handler) Handle(c *gin.Context) {
	splitPath := strings.Split(c.Param("service"), "/")
	if len(splitPath) < 2 {
		c.String(http.StatusNotFound, msgNotFound)
		return
	}
	fmt.Println(splitPath)

	newURL := redirectURL(h.config, splitPath[1])
	fmt.Println("newURL: ", newURL)
	if newURL == "" {
		c.String(http.StatusNotFound, msgNotFound)
		return
	}
	c.Redirect(http.StatusPermanentRedirect, fmt.Sprintf("https://%s", newURL))
}

func redirectURL(config config.Config, service string) string {
	switch service {
	case "diary":
		return config.DiaryServiceAddr
	case "drink":
		return config.DrinkServiceAddr
	case "user":
		return config.UserServiceAddr
	case "subscription":
		return config.SubscriptionServiceAddr
	case "notification":
		return config.NotificationServiceAddr
	}
	return ""
}
