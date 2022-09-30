package main

import (
	"fmt"
	"net/http"
)

func Hello() string {
	return "Hello"
}

type handler struct{}

func (h handler) ServeHTTP(w http.ResponseWriter, r *http.Request) {
	_, err := w.Write([]byte("Hello"))
	if err != nil {
		w.WriteHeader(500)
	}
}

func main() {
	fmt.Println("Hello...")
	http.ListenAndServe(":8081", handler{})
}
