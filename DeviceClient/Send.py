import socket

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

my_str = "Switch:2"
my_str_as_bytes = str.encode(my_str)

s.connect((socket.gethostname(),333))

s.send(my_str_as_bytes)
msg = s.recv(1024)
s.close()
