
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
        s.close
        print(getGPIOState(int(msgsplit[1])))
        se = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
        se.connect((address[0],int(msgsplit[2])))
        if msgsplit[0] == "Switch":
            switchGPIOState(int(msgsplit[1]))
            print(msgsplit)
            state = getGPIOState(int(msgsplit[1]))
            se.send(state)

        elif msgsplit[0] == "Status":
            print(msgsplit)
            state = getGPIOState(int(msgsplit[1]))
            print(getGPIOState(int(msgsplit[1])))
            se.send(state)
        else:
            se.send(str.encode("Layer-8-Error"))
       
        
def getGPIOState(gpioToCheck):
    GPIO.setup(gpioToCheck, GPIO.OUT)
    if GPIO.input(gpioToCheck) == True:
        return "1"
    else:
        return "0"
        print(GPIO.input(gpioToCheck))

def switchGPIOState(toSwitch):
    GPIO.setup(toSwitch, GPIO.OUT)
    if getGPIOState(toSwitch) == "High":
        GPIO.output(toSwitch, GPIO.LOW)
    else:
        GPIO.output(toSwitch, GPIO.HIGH)
  
GPIO.setmode(GPIO.BCM)   
waitForMessage()
