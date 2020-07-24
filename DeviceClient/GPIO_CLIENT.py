
import socket
import RPi.GPIO as GPIO
#from RPiSim import GPIO 


def waitForMessage():
    s = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
    s.bind(("0.0.0.0",333))
    s.listen(5)
    while True:
        clientsocket, address = s.accept()
        msg = clientsocket.recv(1024).decode()
        print(msg)
        msgsplit = msg.split(":")
        s.close
        print("Getting GPIO-State for: " + msgsplit[1])
        print(getGPIOState(int(msgsplit[1])))
        se = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
        print("Connecting to " + address[0] + " with port " + msgsplit[2])
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
        elif msgsplit[0] == "Sensor":
            print(msgsplit[2])
            sensorValue = exec(msgsplit[2])
            se.send(str.encode(sensorValue))
        else:
            se.send(str.encode("Layer-8-Error"))
        se.close()
             
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
