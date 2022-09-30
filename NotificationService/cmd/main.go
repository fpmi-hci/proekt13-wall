package main

import (
	"fmt"
	"log"
	"net/http"
)

type handler struct{}

// ServeHTTP serves HTTP!
func (h handler) ServeHTTP(w http.ResponseWriter, r *http.Request) {
	_, err := w.Write([]byte("Hello"))
	if err != nil {
		w.WriteHeader(500)
	}
}

// Hello returns hello
func Hello() string {
	return "Hello"
}

func main() {
	fmt.Println("Hello...")
	err := http.ListenAndServe(":8081", handler{})
	if err != nil {
		log.Fatal("server failed")
	}
}
