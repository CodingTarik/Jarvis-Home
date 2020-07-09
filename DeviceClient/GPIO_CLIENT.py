
import socket
import RPi.GPIO as GPIO
    
def waitForMessage():
    s = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
    s.bind(("0.0.0.0",333))
    s.listen(5)
    while True:
        clientsocket, address = s.accept()
        msg = clientsocket.recv(1024)
        print(msg)
        msgsplit = msg.split(":")
        print(msgsplit)

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
    GPIO.setup(gpioToCheck, GPIO.OUT)
    if GPIO.input(gpioToCheck) == True:
        return "High"
    else:
        return "Low"
        print(GPIO.input(gpioToCheck))

def switchGPIOState(toSwitch):
    GPIO.setup(toSwitch, GPIO.OUT)
    if getGPIOState(toSwitch) == "High":
        GPIO.output(toSwitch, GPIO.LOW)
    else:
        GPIO.output(toSwitch, GPIO.HIGH)
  
GPIO.setmode(GPIO.BCM)   
waitForMessage()
