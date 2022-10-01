package config

import (
	"github.com/kelseyhightower/envconfig"
)

type Config struct {
	DrinkServiceAddr        string `split_words:"true" required:"true"`
	DiaryServiceAddr        string `split_words:"true" required:"true"`
	NotificationServiceAddr string `split_words:"true" required:"true"`
	SubscriptionServiceAddr string `split_words:"true" required:"true"`
	UserServiceAddr         string `split_words:"true" required:"true"`
}

// Load loads bot config.
func Load() (Config, error) {
	c := Config{}
	err := envconfig.Process("", &c)
	return c, err
}
