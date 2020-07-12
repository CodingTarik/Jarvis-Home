import socket

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

my_str = "hello world"
my_str_as_bytes = str.encode(my_str)

s.connect(("127.0.0.1",334))

s.send(my_str_as_bytes)
