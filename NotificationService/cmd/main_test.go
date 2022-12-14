package main

import "testing"

// TestHello tests hello
func TestHello(t *testing.T) {
	tests := []struct {
		name string
		want string
	}{
		{
			"Hello",
			"Hello",
		},
	}
	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			if got := Hello(); got != tt.want {
				t.Errorf("Hello() = %v, want %v", got, tt.want)
			}
		})
	}
}
