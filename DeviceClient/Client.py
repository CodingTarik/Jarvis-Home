import socket
#import RPI.GPIO as GPIO
    
def waitForMessage():
    s = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
    s.bind((socket.gethostname(),333))
    s.listen(5)
    while True:
        clientsocket, address = s.accept()
        msg = clientsocket.recv(1024)
        msgsplit = str(msg).split("'")
        msgsplit = msgsplit[1].split(":")

        # 'Switch:4'
        if msgsplit[0] == "Switch":
            switchGPIOState(int(msgsplit[1]))
            print(msgsplit)
            state = getGPIOState(int(msgsplit[1]))
            clientsocket.send(str.encode(state))

        elif msgsplit[0] == "Status":
            print(msgsplit)
            state = getGPIOState(int(msgsplit[1]))
            clientsocket.send(str.encode(state))
        else:
            clientsocket.send(str.encode("Layer-8-Error"))
       
        
def getGPIOState(gpioToCheck):
    if gpio[int(gpioToCheck)-1] == "High":
        return "TRUE"
    else:
        return "FALSE"

def switchGPIOState(toSwitch):
    if getGPIOState(toSwitch) == "TRUE":
        gpio[toSwitch-1] = "Low"
    else:
        gpio[toSwitch-1] ="High"


gpio = ["Low"]
i = 1
while i < 10:
    gpio.append("Low")       
    i = i+1
   
waitForMessage()
